using Contracts.Dto.Security;
using Contracts.Dto.SystemNav.Users;
using Contracts.Entities.Security;
using Contracts.Interface.Security;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Encryption;
using AutoMapper;
using Infrastructure.Resources;

namespace Service.Service.Security
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly ICustomEncryption customEncryption;
        private readonly IAuthenticationRepository authenticationRepository;
        public AuthenticateService(ICustomEncryption customEncryption, IAuthenticationRepository authenticationRepository)
        {
            this.customEncryption = customEncryption;
            this.authenticationRepository = authenticationRepository;

        }

        public void Logout(Guid userId)
        {
            authenticationRepository.setRefreshToken(string.Empty, userId);
        }
        public async Task<GSActionResult<object>> Refresh(UserRefreshModel model)
        {
            var config = new MapperConfiguration(cfg => { });
            var mapper = config.CreateMapper();
            var result = new GSActionResult<object>();
            var res = await authenticationRepository.GetUser(model.UserName);
            var user = mapper.Map<List<User>>(res[0])[0];
            var permissionList = mapper.Map<List<MenuPermission>>(res[1]);
            if (model.RefreshToken != user.RefreshToken || user.UserName == null || string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(user.RefreshToken) || string.IsNullOrEmpty(model.RefreshToken))
            {
                result.IsSuccess = false;
                result.Message = Messages.InvalidUserNameOrPassword;
                return result;
            }
            user.RefreshToken = customEncryption.GenerateRefreshToken();
            user.Token = customEncryption.GenerateToken(user.UserId);

            var moduleList = permissionList.GroupBy(r => r.ModuleId).Select(moduleId => moduleId.First()).Select(w => w.ModuleId);
            var list = new List<Permission>();
            foreach (var item in moduleList)
            {
                BaseMenuPermission[] t = permissionList.Where(z => z.ModuleId == item).ToArray();
                var j = new Permission();
                j.roleId = item;
                j.permissionTypeList = t.ToList();
                list.Add(j);
            }
            user.MenuPermissionList = list;
            result.Data = new { user.UserName, user.FirstName, user.LastName, user.RefreshToken, user.ThemeId, user.UserTypeId, user.Ext, user.MenuPermissionList, user.Token, user.IsWhAsc, user.IsWh2017 };
            result.IsSuccess = true;
            await authenticationRepository.setUserToRedis(user, user.UserId);
            await authenticationRepository.setRefreshToken(user.RefreshToken, user.UserId);
            return result;
        }

        public async Task<GSActionResult<object>> Login(UserLoginModel model)
        {
            //step 1 : checkuser name & password from db & isActive

            var config = new MapperConfiguration(cfg => { });
            var mapper = config.CreateMapper();

            var result = new GSActionResult<object>();
            var res = await authenticationRepository.GetUser(model.UserName);
            var user = mapper.Map<List<User>>(res[0])[0];
            var permissionList = mapper.Map<List<MenuPermission>>(res[1]);

            if (user.UserName == null)
            {
                result.IsSuccess = false;
                result.Message = Messages.InvalidUserNameOrPassword;
                return result;
            }
            var hashPassword = customEncryption.EncodePassword(model.Password, user.PasswordFormat, user.PasswordSalt);
            if (hashPassword != user.Password)
            {
                result.IsSuccess = false;
                result.Message = Messages.InvalidUserNameOrPassword;
                return result;
            }
            //var authenticateModel = new AuthenticateDto();
            //authenticateModel.RefreshToken = customEncryption.GenerateRefreshToken();
            //authenticateModel.Token = customEncryption.GenerateToken(user.UserId);
            //authenticateModel.FirstName = user.FirstName;
            //authenticateModel.LastName = user.LastName;
            //authenticateModel.UserName = user.UserName;
            //authenticateModel.ThemeId = user.ThemeId;
            user.RefreshToken = customEncryption.GenerateRefreshToken();
            user.Token = customEncryption.GenerateToken(user.UserId);

            var moduleList = permissionList.GroupBy(r => r.ModuleId).Select(moduleId => moduleId.First()).Select(w => w.ModuleId);
            var list = new List<Permission>();
            foreach (var item in moduleList)
            {
                //object[] t = permissionList.Where(z => z.ModuleId == item).Select(x => new { x.PermissionId, x.PermissionName }).ToArray();
                BaseMenuPermission[] t = permissionList.Where(z => z.ModuleId == item).ToArray();
                var j = new Permission();
                j.roleId = item;
                j.permissionTypeList = t.ToList();
                list.Add(j);

            }
            //user.MenuPermissionList = list;//permissionList.Select(x => new { x.ModuleId, x.PermissionId,x.PermissionName });
            user.MenuPermissionList = list;
            result.Data = new { user.UserName, user.FirstName, user.LastName, user.RefreshToken, user.ThemeId, user.UserTypeId, user.Token, user.Ext, user.IsWhAsc, user.IsWh2017, user.MenuPermissionList }; ;
            result.IsSuccess = true;
           // await authenticationRepository.setUserToRedis(user, user.UserId);
            await authenticationRepository.setRefreshToken(user.RefreshToken, user.UserId);
            return result;

        }
        public async Task<User> getCurrentUSer(Guid userId)
        {
            return await authenticationRepository.getUserFromRedis(userId);
        }
    }

}

using Contracts.Entities.Security;
using Contracts.InputModels.DataEntryModels.SystemNav.Users;
using Contracts.Interface.Security;
using Contracts.Interface.Shared;
using Contracts;
using Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.FormatConvertor;

namespace Service.Service.Security
{
    public class PermissionService : IPermissionService
    { 

        private readonly IAuthenticationRepository authenticationRepository;
    private IGenericRepository<UserInfo, UserInfo> _repo;
    private IGenericRepository<UserDataAccess, UserDataAccess> _repoUserDataAccess;
    private IUtility _utility;
    public PermissionService(IAuthenticationRepository authenticationRepository, IGenericRepository<UserInfo, UserInfo> repo, IUtility utility, IGenericRepository<UserDataAccess, UserDataAccess> repoUserDataAccess)
    {
        this.authenticationRepository = authenticationRepository;
        this._repo = repo;
        this._utility = utility;
        _repoUserDataAccess = repoUserDataAccess;
    }
    public async Task<GSActionResult<IEnumerable<MenuPermission>>> GetPermissionsByMenuId(int menuId, string userName)
    {
        var result = new GSActionResult<IEnumerable<MenuPermission>>();
        result.Data = await authenticationRepository.GetPermissionsByMenuId(menuId, userName); ;
        result.IsSuccess = true;
        return result;

    }
    public async Task<GSActionResult<IEnumerable<UserDataAccess>>> GetUserDataAccess(string conceptName, string currentUserName, string userName)
    {
        var result = new GSActionResult<IEnumerable<UserDataAccess>>();
        result.Data = await _repoUserDataAccess.GetAllSingle("", new { currentUserName, userName, conceptName });
        result.IsSuccess = true;
        return result;
    }
    public virtual async Task<GSActionResult<object>> Save(UserInfo obj)
    {
        var result = new GSActionResult<object>();
        result.Data = await _repo.Insert(SPNames.Pharmacy_UserMenuPermission_CU, new { obj.CreateBy, obj.UserName, permissionList = _utility.ConvertToDataTable(obj.UserMenuPermissionList.Select(x => new { x.PermissionId, x.PermissionValue })) });
        result.IsSuccess = true;
        return result;
    }
    public virtual async Task<GSActionResult<object>> SaveDataAccess(ICollection<UserDataAccess> permissionList, int permissionTypeId, Guid userId, string userName)
    {
        var result = new GSActionResult<object>();
        try
        {
            result.Data = await _repo.Insert("", new { userId, userName, permissionTypeId, permissionList = _utility.ConvertToDataTable(permissionList.Select(w => new { permissionId = w.Id, permissionValue = (w.Permission) })) });
            result.IsSuccess = true;
            return result;
        }
        catch (Exception ex)
        {
            result.Message = ex.Message.Substring(1, 100);
            result.IsSuccess = false;
            return result;
        }

    }
}


}

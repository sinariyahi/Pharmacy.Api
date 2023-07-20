using Common.FormatConvertor;
using Contracts.Dto.SystemNav.Users;
using Contracts.InputModels.DataEntryModels.SystemNav.Users;
using Contracts.Interface.Base;
using Contracts.Interface.Shared;
using Infrastructure.Resources;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.SystemNav
{
    public class UserService : GenericService<UserDto, UserInfo>, IUserService
    {
        private IGenericRepository<UserDto, UserInfo> _repo;
        private IUtility _utility;
        public UserService(IGenericRepository<UserDto, UserInfo> repository, IUtility utility) : base(repository, SPNames.Pharmacy_GetAllUser, SPNames.Pharmacy_GetAllUserByCase, SPNames.Pharmacy_GetUserInfo, "")
        {
            _repo = repository;
            _utility = utility;
        }

    }
}

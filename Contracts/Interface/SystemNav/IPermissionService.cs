using Contracts.Entities.Security;
using Contracts.InputModels.DataEntryModels.SystemNav.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.SystemNav
{
    public interface IPermissionService
    {
        Task<GSActionResult<IEnumerable<MenuPermission>>> GetPermissionsByMenuId(int id, string userName);
        Task<GSActionResult<IEnumerable<UserDataAccess>>> GetUserDataAccess(string conceptName, string currentUserName, string userName);
        Task<GSActionResult<object>> Save(UserInfo obj);
        Task<GSActionResult<object>> SaveDataAccess(ICollection<UserDataAccess> permissionList, int permissionTypeId, Guid userId, string userName);

    }
}

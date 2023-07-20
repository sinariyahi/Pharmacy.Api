using Contracts.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.Security
{
    public interface IAuthenticationRepository
    {
        Task<bool> setUserToRedis(User user, Guid userId);
        Task<User> getUserFromRedis(Guid userId);
        Task<List<object>> GetUser(string userName);
        Task<IEnumerable<MenuPermission>> GetPermissionsByMenuId(int menuId, string userName);
        Task<bool> setRefreshToken(string refreshToken, Guid userId);
    }
}

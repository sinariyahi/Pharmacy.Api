using Contracts.Dto.SystemNav.Users;
using Contracts.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.Security
{
    public interface IAuthenticateService
    {
        Task<GSActionResult<object>> Login(UserLoginModel model);
        Task<User> getCurrentUSer(Guid userId);
        Task<GSActionResult<object>> Refresh(UserRefreshModel model);
        void Logout(Guid userId);
    }
}

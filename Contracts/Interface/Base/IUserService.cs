using Contracts.Dto.SystemNav.Users;
using Contracts.InputModels.DataEntryModels.SystemNav.Users;
using Contracts.Interface.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.Base
{
    public interface IUserService : IGenericService<UserDto, UserInfo>
    {
    }
}

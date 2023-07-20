using Contracts.Dto.SystemNav.Roles;
using Contracts.InputModels.DataEntryModels.SystemNav.Role;
using Contracts.Interface.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.SystemNav
{
    public interface IRoleService : IGenericService<RoleDto, RoleInfo>
    {
        Task<GSActionResult<IEnumerable<RoleDto>>> GetAllByUserId(Guid userId);
    }
}

using Contracts.Dto.SystemNav.Roles;
using Contracts.InputModels.DataEntryModels.SystemNav.Role;
using Contracts.Interface.Shared;
using Contracts.Interface.SystemNav;
using Contracts;
using Infrastructure.Resources;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.SystemNav
{
    public class RoleService : GenericService<RoleDto, RoleInfo>, IRoleService
    {
        private readonly IGenericRepository<RoleDto, RoleInfo> _repository;
        public RoleService(IGenericRepository<RoleDto, RoleInfo> repository) : base(repository, SPNames.Pharmacy_GetAllUser, SPNames.Pharmacy_GetAllPersonel, SPNames.Pharmacy_GetPersonelInfo, SPNames.Pharmacy_GetAllUser)
        {
            _repository = repository;
        }

        public async Task<GSActionResult<IEnumerable<RoleDto>>> GetAllByUserId(Guid userId)
        {
            var result = new GSActionResult<IEnumerable<RoleDto>>();
            (result.Data) = await _repository.GetAllSingle(SPNames.Pharmacy_Roles_ByUserId, new { userId = userId });
            result.IsSuccess = true;
            return result;
        }

    }
}


using Contracts;
using Contracts.Dto.Base;
using Contracts.Interface.Base;
using Contracts.Interface.Shared;
using Infrastructure.Resources;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Base
{
    public class MenuService: GenericService<MenuDto, MenuDto>, IMenuService
    {
        private readonly IGenericRepository<MenuDto, MenuDto> repository;
        public MenuService(IGenericRepository<MenuDto, MenuDto> repository) : base(repository, SPNames.Pharmacy_Menu_GetAll, "", "", "")
        {
            this.repository = repository;
        }

        public async Task<GSActionResult<IEnumerable<MenuDto>>> GetAllShortcut(Guid userId)
        {
            var result = new GSActionResult<IEnumerable<MenuDto>>();
            result.Data = await repository.GetAllSingle(SPNames.Pharmacy_Menu_GetAllShortcut, new { userId = userId });
            result.IsSuccess = true;
            return result;
        }
        public async Task<GSActionResult<IEnumerable<MenuDto>>> GetAllMenu(Guid userId)
        {
            var result = new GSActionResult<IEnumerable<MenuDto>>();
            result.Data = await repository.GetAllSingle(SPNames.Pharmacy_Menu_GetAll, new { userId = userId });
            result.IsSuccess = true;
            return result;
        }
    }
}

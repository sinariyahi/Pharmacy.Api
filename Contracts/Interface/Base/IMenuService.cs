using Contracts.Dto.Base;
using Contracts.Interface.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.Base
{
    public interface IMenuService: IGenericService<MenuDto, MenuDto>
    {
        Task<GSActionResult<IEnumerable<MenuDto>>> GetAllShortcut(Guid userId);
        Task<GSActionResult<IEnumerable<MenuDto>>> GetAllMenu(Guid userId);

    }
}

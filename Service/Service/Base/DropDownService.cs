using Contracts;
using Contracts.Dto.Base;
using Contracts.InputModels.FilterModels.Base;
using Contracts.Interface.Base;
using Contracts.Interface.Shared;
using Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Base
{
    public class DropDownService : IDropDownService
    {
        private readonly IGenericRepository<DropDownDto, DropDownDto> repository;
        public DropDownService(IGenericRepository<DropDownDto, DropDownDto> repository)
        {
            this.repository = repository;
        }

        public async Task<GSActionResult<IEnumerable<DropDownDto>>> GetAll(DropDownFilter filter)
        {
            var result = new GSActionResult<IEnumerable<DropDownDto>>();
            result.Data = await repository.GetAllSingle(SPNames.Pharmacy_DropDown, filter);
            result.IsSuccess = true;
            return result;
        }

    }
}

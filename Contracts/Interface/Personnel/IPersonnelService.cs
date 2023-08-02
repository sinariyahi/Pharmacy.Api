using Contracts.Dto.Patient;
using Contracts.Dto.Personnel;
using Contracts.InputModels.DataEntryModels.Patient;
using Contracts.InputModels.DataEntryModels.Personnel;
using Contracts.InputModels.FilterModels.Patient;
using Contracts.InputModels.FilterModels.Personnel;
using Contracts.Interface.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.Personnel
{
    public interface IPersonnelService : IGenericService<PersonnelDto, PersonnelInfo>, IGenericAttachmentService
    {
        Task<GSActionResult<IEnumerable<WarehousePersonnelHistory>>> WarehousePersonnelHistoryPopUp(WarehousePersonnelFilterModel filter);
        Task<GSActionResult<IEnumerable<PharmacyPersonnelHistory>>> PharmacyPersonnelHistoryPopUp(PharmacyPersonnelFilterModel filter);

    }
}

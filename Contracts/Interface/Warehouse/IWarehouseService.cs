using Contracts.Dto.Base;
using Contracts.Dto.Pharmacy;
using Contracts.Dto.Warehouse;
using Contracts.InputModels.DataEntryModels.Pharmacy;
using Contracts.InputModels.DataEntryModels.Warehouse;
using Contracts.InputModels.FilterModels.Pharmacy;
using Contracts.InputModels.FilterModels.Warehouse;
using Contracts.Interface.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicineHistory = Contracts.InputModels.DataEntryModels.Warehouse.MedicineHistory;
using MedicineHistoryFilterModel = Contracts.InputModels.FilterModels.Warehouse.MedicineHistoryFilterModel;
using PersonnelHistory = Contracts.InputModels.DataEntryModels.Warehouse.PersonnelHistory;
using PersonnelHistoryFilterModel = Contracts.InputModels.FilterModels.Warehouse.PersonnelHistoryFilterModel;

namespace Contracts.Interface.Warehouse
{
    public interface IWarehouseService : IGenericService<WarehouseDto, WarehouseInfo>, IGenericAttachmentService
    {
        Task<GSActionResult<IEnumerable<AutocompleteDto>>> GetAllAutoComplete(string term, int cityId);
        Task<GSActionResult<IEnumerable<PersonnelHistory>>> PersonnelHistoryPopUp(PersonnelHistoryFilterModel filter);
        Task<GSActionResult<IEnumerable<PharmacyHistory>>> PharmacyHistoryPopUp(PharmacyHistoryFilterModel filter);
        Task<GSActionResult<IEnumerable<MedicineHistory>>> MedicineHistoryPopUp(MedicineHistoryFilterModel filter);
    }
}

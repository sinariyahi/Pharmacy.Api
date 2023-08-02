using Contracts;
using Contracts.Dto.Base;
using Contracts.Dto.Personnel;
using Contracts.Dto.Warehouse;
using Contracts.InputModels.DataEntryModels.Warehouse;
using Contracts.InputModels.FilterModels.Pharmacy;
using Contracts.InputModels.FilterModels.Warehouse;
using Contracts.Interface.Personnel;
using Contracts.Interface.Shared;
using Contracts.Interface.Warehouse;
using Infrastructure.Resources;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MedicineHistory = Contracts.InputModels.DataEntryModels.Warehouse.MedicineHistory;
using MedicineHistoryFilterModel = Contracts.InputModels.FilterModels.Warehouse.MedicineHistoryFilterModel;
using PersonnelHistory = Contracts.InputModels.DataEntryModels.Warehouse.PersonnelHistory;
using PersonnelHistoryFilterModel = Contracts.InputModels.FilterModels.Warehouse.PersonnelHistoryFilterModel;

namespace Service.Service.Warehouse
{
    public class WarehouseService : GenericService<WarehouseDto, WarehouseInfo>, IWarehouseService, IBaseService
    {

        private readonly IGenericRepository<WarehouseDto, WarehouseInfo> repo;
        private readonly IGenericRepository<ParishDto, ParishDto> parish;
        private readonly IGenericRepository<PersonnelHistory, PersonnelHistory> personnel;
        private readonly IGenericRepository<PharmacyHistory, PharmacyHistory> pharmacy;
        private readonly IGenericRepository<MedicineHistory, MedicineHistory> medicine;
        public WarehouseService(IGenericRepository<WarehouseDto, WarehouseInfo> repository, IGenericRepository<ParishDto, ParishDto> _parish
            , IGenericRepository<PersonnelHistory, PersonnelHistory> _personnel, IGenericRepository<PharmacyHistory, PharmacyHistory> _pharmacy, IGenericRepository<MedicineHistory, MedicineHistory> _medicine)
        : base(repository, SPNames.Pharmacy_Warehouse_GetAll, SPNames.Pharmacy_Warehouse_ByCase, SPNames.Pharmacy_Warehouse_GetInfo, SPNames.Pharmacy_Warehouse_CU)
        {
            this.repo = repository;
            parish = _parish;
            personnel = _personnel;
            pharmacy = _pharmacy;
            medicine = _medicine;
        }
        #region

        public async Task<GSActionResult<IEnumerable<PersonnelHistory>>> PersonnelHistoryPopUp(PersonnelHistoryFilterModel filter)
        {
            var result = new GSActionResult<IEnumerable<PersonnelHistory>>();
            (result.Data, result.RowCount) = await personnel.GetAll("GetAllPersonnelHistoryPopUp", filter);
            result.IsSuccess = true;
            result.Page = filter.PageNumber;
            return result;
        }


        public async Task<GSActionResult<IEnumerable<PharmacyHistory>>> PharmacyHistoryPopUp(PharmacyHistoryFilterModel filter)
        {
            var result = new GSActionResult<IEnumerable<PharmacyHistory>>();
            (result.Data, result.RowCount) = await pharmacy.GetAll("GetAllPharmacyHistoryPopUp", filter);
            result.IsSuccess = true;
            result.Page = filter.PageNumber;
            return result;
        }


        public async Task<GSActionResult<IEnumerable<MedicineHistory>>> MedicineHistoryPopUp(MedicineHistoryFilterModel filter)
        {
            var result = new GSActionResult<IEnumerable<MedicineHistory>>();
            (result.Data, result.RowCount) = await medicine.GetAll("GetAllMedicineHistoryPopUp", filter);
            result.IsSuccess = true;
            result.Page = filter.PageNumber;
            return result;
        }

        #endregion
        #region Save
        public override async Task<GSActionResult<object>> Save(object warehouse)
        {
            var result = new GSActionResult<object>();
            try
            {
                var t = (WarehouseInfo)warehouse;
                result.Data = await repo.Insert(SPNames.Pharmacy_Warehouse_CU, new
                {
                    t.Id,
                    t.StartDate,
                    t.FirstName,
                    t.MedicineNumber,
                    t.PersonnelNumber,
                    t.Address,
                    t.Province,
                    t.Mobile,
                    t.Tel
                });

                result.IsSuccess = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message.Substring(0, (ex.Message.Length > 100) ? 100 : ex.Message.Length);
                result.Data = result.Message;
                result.IsSuccess = false;
                return result;

            }

        }

        #endregion
        #region Parish

        public async Task<GSActionResult<IEnumerable<AutocompleteDto>>> GetAllAutoComplete(string term, int cityId)
        {
            var result = new GSActionResult<IEnumerable<AutocompleteDto>>();
            var list = new List<AutocompleteDto>();
            IEnumerable<ParishDto>[] x = (await Task.WhenAll(parish.GetAllSingle(SPNames.Pharmacy_GetParishs, new { term, cityId })));

            foreach (ParishDto item in x[0])
            {
                list.Add(new AutocompleteDto { Id = item.Id, Label = item.ParishName });

            }
         (result.Data) = list;
            result.IsSuccess = true;
            return result;
        }

        #endregion
        #region attachments
        public string getAttachmentProcedure()
        {
            return "GetWarehouseAttachment";
        }

        public string removeAttachmentProcedure()
        {
            return "RemoveWarehouseAttachment";
        }

        public string setAttachmentProcedure()
        {
            return "SetWarehouseAttachment";
        }
        #endregion
    }
}

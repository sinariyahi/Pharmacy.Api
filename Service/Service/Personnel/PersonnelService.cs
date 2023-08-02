using Contracts;
using Contracts.Dto.Patient;
using Contracts.Dto.Personnel;
using Contracts.InputModels.DataEntryModels.Patient;
using Contracts.InputModels.DataEntryModels.Personnel;
using Contracts.InputModels.FilterModels.Patient;
using Contracts.InputModels.FilterModels.Personnel;
using Contracts.Interface.Patient;
using Contracts.Interface.Personnel;
using Contracts.Interface.Shared;
using Infrastructure.Resources;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Personnel
{
    public class PersonnelService : GenericService<PersonnelDto, PersonnelInfo>, IPersonnelService, IBaseService
    {

        private readonly IGenericRepository<PersonnelDto, PersonnelInfo> repo;
        private readonly IGenericRepository<WarehousePersonnelHistory, WarehousePersonnelHistory> warehouse;
        private readonly IGenericRepository<PharmacyPersonnelHistory, PharmacyPersonnelHistory> pharmacy;
        public PersonnelService(IGenericRepository<PersonnelDto, PersonnelInfo> repository, IGenericRepository<WarehousePersonnelHistory, WarehousePersonnelHistory> _warehouse
            , IGenericRepository<PharmacyPersonnelHistory, PharmacyPersonnelHistory> _pharmacy)
        : base(repository, SPNames.Pharmacy_Personnel_GetAll, SPNames.Pharmacy_Personnel_ByCase, SPNames.Pharmacy_Personnel_GetInfo, SPNames.Pharmacy_Personnel_CU)
        {
            this.repo = repository;
            warehouse = _warehouse;
            pharmacy = _pharmacy;
        }
        #region
        public async Task<GSActionResult<IEnumerable<WarehousePersonnelHistory>>> WarehousePersonnelHistoryPopUp(WarehousePersonnelFilterModel filter)
        {
            var result = new GSActionResult<IEnumerable<WarehousePersonnelHistory>>();
            (result.Data, result.RowCount) = await warehouse.GetAll("GetAllWarehousePersonnelHistoryPopUp", filter);
            result.IsSuccess = true;
            result.Page = filter.PageNumber;
            return result;
        }

        public async Task<GSActionResult<IEnumerable<PharmacyPersonnelHistory>>> PharmacyPersonnelHistoryPopUp(PharmacyPersonnelFilterModel filter)
        {
            var result = new GSActionResult<IEnumerable<PharmacyPersonnelHistory>>();
            (result.Data, result.RowCount) = await pharmacy.GetAll("GetAllPharmacyPersonnelHistoryPopUp", filter);
            result.IsSuccess = true;
            result.Page = filter.PageNumber;
            return result;
        }

        #endregion
        #region Save
        public override async Task<GSActionResult<object>> Save(object personnel)
        {
            var result = new GSActionResult<object>();
            try
            {
                var t = (PersonnelInfo)personnel;
                result.Data = await repo.Insert(SPNames.Pharmacy_Personnel_CU, new
                {
                    t.Id,
                    t.FirstName,
                    t.LastName,
                    t.Mobile,
                    t.HomeTel,
                    t.NationalCode,
                    t.Address,
                    t.Province,
                    t.City,
                    t.PharmacyName,
                    t.WarehouseName
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
        #region attachments
        public string getAttachmentProcedure()
        {
            return "GetPersonnelAttachment";
        }

        public string removeAttachmentProcedure()
        {
            return "RemovePersonnelAttachment";
        }

        public string setAttachmentProcedure()
        {
            return "SetPersonnelAttachment";
        }
        #endregion
    }
}

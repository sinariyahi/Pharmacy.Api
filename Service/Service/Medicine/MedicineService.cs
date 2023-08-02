using AutoMapper;
using Contracts;
using Contracts.Dto.Medicine;
using Contracts.InputModels.DataEntryModels.Medicine;
using Contracts.InputModels.FilterModels.Medicine;
using Contracts.Interface.Medicine;
using Contracts.Interface.Shared;
using Infrastructure.Resources;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Medicine
{
    public class MedicineService : GenericService<MedicineDto, MedicineInfo>, IMedicineService, IBaseService
    {
        private readonly IGenericRepository<MedicineDto, MedicineInfo> repo;
        private readonly IGenericRepository<PatientMedicinePurchase, PatientMedicinePurchase> patient;
        private readonly IGenericRepository<PharmacyMedicinePurchase, PharmacyMedicinePurchase> pharmacy;
        private readonly IGenericRepository<MedicineExpiration, MedicineExpiration> expiration;
        private readonly IGenericRepository<OrderMedicineInfo, OrderMedicineInfo> order;
        public MedicineService(IGenericRepository<MedicineDto, MedicineInfo> repository, IGenericRepository<PatientMedicinePurchase, PatientMedicinePurchase> _patient
        ,IGenericRepository<PharmacyMedicinePurchase, PharmacyMedicinePurchase> _pharmacy, IGenericRepository<MedicineExpiration, MedicineExpiration> _expiration
            , IGenericRepository<OrderMedicineInfo, OrderMedicineInfo> _order)
        : base(repository, SPNames.Pharmacy_Medicine_GetAll, SPNames.Pharmacy_Medicine_ByCase, SPNames.Pharmacy_Medicine_GetInfo, SPNames.Pharmacy_Medicine_CU)
        {
            this.repo = repository;
            patient = _patient;
            pharmacy = _pharmacy;
            expiration = _expiration;
            order = _order;
        }
        #region Save
        public override async Task<GSActionResult<object>> Save(object medicine)
        {
            var result = new GSActionResult<object>();
            try
            {
                var t = (MedicineInfo)medicine;
                result.Data = await repo.Insert(SPNames.Pharmacy_Medicine_CU, new
                {
                    t.Id,
                    t.PharmacyName,
                    t.WarehouseName,
                    t.PatientName,
                    t.StartDate,
                    t.EndDate,
                    t.MedicineName

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
        #region PopUp

        public async Task<GSActionResult<IEnumerable<PatientMedicinePurchase>>> PatientPurchasePopUp(PatientMedicinePurchaseFilterModel filter)
        {
            var result = new GSActionResult<IEnumerable<PatientMedicinePurchase>>();
            (result.Data, result.RowCount) = await patient.GetAll("GetAllPatientPurchasePopUp", filter);
            result.IsSuccess = true;
            result.Page = filter.PageNumber;
            return result;
        }

        public async Task<GSActionResult<IEnumerable<PharmacyMedicinePurchase>>> PharmacyPurchasePopUp(PharmacyMedicinePurchaseFilterModel filter)
        {
            var result = new GSActionResult<IEnumerable<PharmacyMedicinePurchase>>();
            (result.Data, result.RowCount) = await pharmacy.GetAll("GetAllPharmacyPurchasePopUp", filter);
            result.IsSuccess = true;
            result.Page = filter.PageNumber;
            return result;
        }

        public async Task<GSActionResult<IEnumerable<MedicineExpiration>>> MedicineExpirationPopUp(MedicineExpirationFilterModel filter)
        {
            var result = new GSActionResult<IEnumerable<MedicineExpiration>>();
            (result.Data, result.RowCount) = await expiration.GetAll("GetAllMedicineExpirationPopUp", filter);
            result.IsSuccess = true;
            result.Page = filter.PageNumber;
            return result;
        }

        public async Task<GSActionResult<object>> SaveOrderMedicine(object obj)
        {
            var result = new GSActionResult<object>();
            try
            {
                var t = (OrderMedicineInfo)obj;
                result.Data = await order.InsertWithTran(SPNames.Medicine_OrderMedicine, new
                {
                    t.PharmacyName,
                    t.StartDate,
                    t.MedicineName,
                    t.MedicineNumber
                    
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
            return "GetMedicineAttachment";
        }

        public string removeAttachmentProcedure()
        {
            return "RemoveMedicineAttachment";
        }

        public string setAttachmentProcedure()
        {
            return "SetMedicineAttachment";
        }
        #endregion
    }
}

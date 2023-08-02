using Contracts;
using Contracts.Dto.Medicine;
using Contracts.InputModels.DataEntryModels.Medicine;
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
        public MedicineService(IGenericRepository<MedicineDto, MedicineInfo> repository)
        : base(repository, SPNames.Pharmacy_Medicine_GetAll, SPNames.Pharmacy_Medicine_ByCase, SPNames.Pharmacy_Medicine_GetInfo, SPNames.Pharmacy_Medicine_CU)
        {
            this.repo = repository;
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

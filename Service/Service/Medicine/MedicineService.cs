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

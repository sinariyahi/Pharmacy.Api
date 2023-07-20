using Contracts.Dto.Personnel;
using Contracts.Dto.Pharmacy;
using Contracts.InputModels.DataEntryModels.Personnel;
using Contracts.InputModels.DataEntryModels.Pharmacy;
using Contracts.Interface.Personnel;
using Contracts.Interface.Pharmacy;
using Contracts.Interface.Shared;
using Infrastructure.Resources;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Pharmacy
{
    public class PharmacyService : GenericService<PharmacyDto, PharmacyInfo>, IPharmacyService, IBaseService
    {
        private readonly IGenericRepository<PharmacyDto, PharmacyInfo> repo;
        public PharmacyService(IGenericRepository<PharmacyDto, PharmacyInfo> repository)
        : base(repository, SPNames.DB_Pharmacy_GetAll, SPNames.DB_Pharmacy_ByCase, SPNames.DB_Pharmacy_GetInfo, SPNames.DB_Pharmacy_CU)
        {
            this.repo = repository;
        }
        #region attachments
        public string getAttachmentProcedure()
        {
            return "GetPharmacyAttachment";
        }

        public string removeAttachmentProcedure()
        {
            return "RemovePharmacyAttachment";
        }

        public string setAttachmentProcedure()
        {
            return "SetPharmacyAttachment";
        }
        #endregion
    }
}

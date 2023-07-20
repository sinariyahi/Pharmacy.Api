using Contracts.Dto.Patient;
using Contracts.Dto.Personnel;
using Contracts.InputModels.DataEntryModels.Patient;
using Contracts.InputModels.DataEntryModels.Personnel;
using Contracts.Interface.Patient;
using Contracts.Interface.Personnel;
using Contracts.Interface.Shared;
using Infrastructure.Resources;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Personnel
{
    public class PersonnelService : GenericService<PersonnelDto, PersonnelInfo>, IPersonnelService, IBaseService
    {

        private readonly IGenericRepository<PersonnelDto, PersonnelInfo> repo;
        public PersonnelService(IGenericRepository<PersonnelDto, PersonnelInfo> repository)
        : base(repository, SPNames.Pharmacy_Personnel_GetAll, SPNames.Pharmacy_Personnel_ByCase, SPNames.Pharmacy_Personnel_GetInfo, SPNames.Pharmacy_Personnel_CU)
        {
            this.repo = repository;
        }
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

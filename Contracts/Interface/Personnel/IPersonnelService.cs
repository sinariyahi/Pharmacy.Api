using Contracts.Dto.Patient;
using Contracts.Dto.Personnel;
using Contracts.InputModels.DataEntryModels.Patient;
using Contracts.InputModels.DataEntryModels.Personnel;
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

    }
}

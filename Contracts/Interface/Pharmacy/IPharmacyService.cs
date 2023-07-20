using Contracts.Dto.Personnel;
using Contracts.Dto.Pharmacy;
using Contracts.InputModels.DataEntryModels.Personnel;
using Contracts.InputModels.DataEntryModels.Pharmacy;
using Contracts.Interface.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.Pharmacy
{
    public interface IPharmacyService : IGenericService<PharmacyDto, PharmacyInfo>, IGenericAttachmentService
    {

    }
}

using Contracts.Dto.Medicine;
using Contracts.Entities.Security;
using Contracts.InputModels.DataEntryModels.Medicine;
using Contracts.Interface.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.Medicine
{
    public interface IMedicineService : IGenericService<MedicineDto, MedicineInfo>, IGenericAttachmentService
    {
      
    }
}

using Contracts.Dto.Medicine;
using Contracts.Entities.Security;
using Contracts.InputModels.DataEntryModels.Medicine;
using Contracts.InputModels.FilterModels.Medicine;
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
      Task<GSActionResult<IEnumerable<PatientMedicinePurchase>>> PatientPurchasePopUp(PatientMedicinePurchaseFilterModel filter);
      Task<GSActionResult<IEnumerable<PharmacyMedicinePurchase>>> PharmacyPurchasePopUp(PharmacyMedicinePurchaseFilterModel filter);
      Task<GSActionResult<IEnumerable<MedicineExpiration>>> MedicineExpirationPopUp(MedicineExpirationFilterModel filter);
      Task<GSActionResult<object>> SaveOrderMedicine(object obj);
        

    }
}

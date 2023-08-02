using Contracts.Dto.Personnel;
using Contracts.Dto.Pharmacy;
using Contracts.InputModels.DataEntryModels.Patient;
using Contracts.InputModels.DataEntryModels.Personnel;
using Contracts.InputModels.DataEntryModels.Pharmacy;
using Contracts.InputModels.FilterModels.Patient;
using Contracts.InputModels.FilterModels.Personnel;
using Contracts.InputModels.FilterModels.Pharmacy;
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
        Task<GSActionResult<IEnumerable<PersonnelHistory>>> PersonnelHistoryPopUp(PersonnelHistoryFilterModel filter);
        Task<GSActionResult<IEnumerable<MedicineHistory>>> MedicineHistoryPopUp(MedicineHistoryFilterModel filter);
        Task<GSActionResult<IEnumerable<patientHistory>>> PatientHistoryPopUp(patientHistoryFilterModel filter);

    }
}

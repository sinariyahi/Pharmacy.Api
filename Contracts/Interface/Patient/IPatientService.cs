using Contracts.Dto.Medicine;
using Contracts.Dto.Patient;
using Contracts.InputModels.DataEntryModels.Medicine;
using Contracts.InputModels.DataEntryModels.Patient;
using Contracts.InputModels.FilterModels.Medicine;
using Contracts.InputModels.FilterModels.Patient;
using Contracts.Interface.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.Patient
{
    public interface IPatientService : IGenericService<PatientDto, PatientInfo>, IGenericAttachmentService
    {
        Task<GSActionResult<IEnumerable<PatientHistory>>> PatientHistoryPopUp(PatientHistoryFilterModel filter);
    }
}

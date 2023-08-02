using Contracts;
using Contracts.Dto.Medicine;
using Contracts.Dto.Patient;
using Contracts.InputModels.DataEntryModels.Medicine;
using Contracts.InputModels.DataEntryModels.Patient;
using Contracts.InputModels.FilterModels.Medicine;
using Contracts.InputModels.FilterModels.Patient;
using Contracts.Interface.Medicine;
using Contracts.Interface.Patient;
using Contracts.Interface.Shared;
using Infrastructure.Resources;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Patient
{
    public class PatientService : GenericService<PatientDto, PatientInfo>, IPatientService, IBaseService
    {
        private readonly IGenericRepository<PatientDto, PatientInfo> repo;
        private readonly IGenericRepository<PatientHistory, PatientHistory> patient;
        public PatientService(IGenericRepository<PatientDto, PatientInfo> repository, IGenericRepository<PatientHistory, PatientHistory> _patient)
        : base(repository, SPNames.Pharmacy_Patient_GetAll, SPNames.Pharmacy_Patient_ByCase, SPNames.Pharmacy_Patient_GetInfo, SPNames.Pharmacy_Patient_CU)
        {
            this.repo = repository;
            patient = _patient;
        }
        #region
        public async Task<GSActionResult<IEnumerable<PatientHistory>>> PatientHistoryPopUp(PatientHistoryFilterModel filter)
        {
            var result = new GSActionResult<IEnumerable<PatientHistory>>();
            (result.Data, result.RowCount) = await patient.GetAll("GetAllPatientHistoryPopUp", filter);
            result.IsSuccess = true;
            result.Page = filter.PageNumber;
            return result;
        }

        #endregion
        #region Save
        public override async Task<GSActionResult<object>> Save(object patient)
        {
            var result = new GSActionResult<object>();
            try
            {
                var t = (PatientInfo)patient;
                result.Data = await repo.Insert(SPNames.Pharmacy_Patient_CU, new
                {

                    t.Id,
                    t.FirstName,
                    t.LastName,
                    t.Mobile,
                    t.HomeTel,
                    t.NationalCode,
                    t.Address,
                    t.Province,
                    t.City,
                    t.PharmacyName,
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
            return "GetPatientAttachment";
        }

        public string removeAttachmentProcedure()
        {
            return "RemovePatientAttachment";
        }

        public string setAttachmentProcedure()
        {
            return "SetPatientAttachment";
        }
        #endregion
    }
}

using Contracts;
using Contracts.Dto.Personnel;
using Contracts.Dto.Pharmacy;
using Contracts.InputModels.DataEntryModels.Personnel;
using Contracts.InputModels.DataEntryModels.Pharmacy;
using Contracts.InputModels.FilterModels.Personnel;
using Contracts.InputModels.FilterModels.Pharmacy;
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
using System.Xml.Linq;

namespace Service.Service.Pharmacy
{
    public class PharmacyService : GenericService<PharmacyDto, PharmacyInfo>, IPharmacyService, IBaseService
    {
        private readonly IGenericRepository<PharmacyDto, PharmacyInfo> repo;
        private readonly IGenericRepository<PersonnelHistory, PersonnelHistory> personnel;
        private readonly IGenericRepository<MedicineHistory, MedicineHistory> medicine;
        private readonly IGenericRepository<patientHistory, patientHistory> patient;
        public PharmacyService(IGenericRepository<PharmacyDto, PharmacyInfo> repository, IGenericRepository<PersonnelHistory, PersonnelHistory> _personnel
            , IGenericRepository<MedicineHistory, MedicineHistory> _medicine, IGenericRepository<patientHistory, patientHistory> _patient)
        : base(repository, SPNames.DB_Pharmacy_GetAll, SPNames.DB_Pharmacy_ByCase, SPNames.DB_Pharmacy_GetInfo, SPNames.DB_Pharmacy_CU)
        {
            this.repo = repository;
                personnel = _personnel;
            medicine = _medicine;
            patient = _patient;
        }
        #region

        public async Task<GSActionResult<IEnumerable<PersonnelHistory>>> PersonnelHistoryPopUp(PersonnelHistoryFilterModel filter)
        {
            var result = new GSActionResult<IEnumerable<PersonnelHistory>>();
            (result.Data, result.RowCount) = await personnel.GetAll("GetAllPersonnelHistoryPopUp", filter);
            result.IsSuccess = true;
            result.Page = filter.PageNumber;
            return result;
        }


        public async Task<GSActionResult<IEnumerable<MedicineHistory>>> MedicineHistoryPopUp(MedicineHistoryFilterModel filter)
        {
            var result = new GSActionResult<IEnumerable<MedicineHistory>>();
            (result.Data, result.RowCount) = await medicine.GetAll("GetAllMedicineHistoryPopUp", filter);
            result.IsSuccess = true;
            result.Page = filter.PageNumber;
            return result;
        }


        public async Task<GSActionResult<IEnumerable<patientHistory>>> PatientHistoryPopUp(patientHistoryFilterModel filter)
        {
            var result = new GSActionResult<IEnumerable<patientHistory>>();
            (result.Data, result.RowCount) = await patient.GetAll("GetAllPatientHistoryPopUp", filter);
            result.IsSuccess = true;
            result.Page = filter.PageNumber;
            return result;
        }

        #endregion
        #region Save
        public override async Task<GSActionResult<object>> Save(object pharmacy)
        {
            var result = new GSActionResult<object>();
            try
            {
                var t = (PharmacyInfo)pharmacy;
                result.Data = await repo.Insert(SPNames.DB_Pharmacy_CU, new
                {
                    t.Id,
                    t.Name,
                    t.Province,
                    t.City,
                    t.Mobile,
                    t.Tel,
                    t.MedicineNumber,
                    t.PatientNumber,
                    t.PersonnelNumber

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

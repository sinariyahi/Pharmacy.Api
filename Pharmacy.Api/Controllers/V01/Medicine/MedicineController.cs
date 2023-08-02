using Contracts.InputModels.DataEntryModels.Medicine;
using Contracts.InputModels.DataEntryModels.Patient;
using Contracts.InputModels.FilterModels.Base;
using Contracts.InputModels.FilterModels.Medicine;
using Contracts.InputModels.FilterModels.Patient;
using Contracts.Interface.Medicine;
using Contracts.Interface.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Service.Shared;
using System.Threading.Tasks;

namespace Pharmacy.Api.Controllers.V01.Medicine
{
    
    public class MedicineController :  AuthBaseWithAttachmentController<long>
    {
        private readonly IMedicineService service;

        private readonly IUploadService _uploadService;
        private readonly string[] filteTypes = { "jpg", "jpeg", "png", "rar", "zip" };
        private readonly string destinationPath = "\\Mod_Project\\medicine";

        public MedicineController(IMedicineService service, IAuthenticateService _authenticateService, IUploadService uploadService, IAttachmentService attachmentService) : base(_authenticateService, attachmentService, service)
        {
            this.service = service;
            _uploadService = uploadService;
        }

        /// <summary>
        /// Display list of medicine
        /// <summary>
        /// 
        [HttpGet("list")]
        public async Task<IActionResult> Get([FromQuery] string filterModel, bool searchAll = true)
        {

            {
                var c = JsonConvert.DeserializeObject<MedicineFilterModel>(filterModel);
                return Ok((searchAll)
                    ? await service.GetAll(JsonConvert.DeserializeObject<MedicineFilterModel>(filterModel))
                    : await service.GetAllByCase(JsonConvert.DeserializeObject<CaseSearchFilter>(filterModel)));
            }

        }
        /// <summary>
        /// Save the new medicines
        /// <summary>
        /// 
        [HttpPost("ce")]
        public async Task<IActionResult> Post(MedicineInfo pharmacy)
        {
            //warehouse.UserId = getCurrentUserId();
            var result = await service.Save(pharmacy);
            return Ok(result);
        }
        /// <summary>
        /// Show medicine information
        /// </summary>
        [HttpGet("showInfo")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await service.GetInfo(id);
            return Ok(result);
        }

        /// <summary>
        /// Patient purchase history
        /// </summary>
        [HttpGet("patientPurchasePopUp")]
        public async Task<IActionResult> PatientPurchasePopUp([FromQuery] string filterModel)
        {
            {
                var c = JsonConvert.DeserializeObject<PatientMedicinePurchaseFilterModel>(filterModel);
                return Ok(await service.PatientPurchasePopUp(c));
            }
        }

        /// <summary>
        /// pharmacy purchase history
        /// </summary>
        [HttpGet("pharmacyPurchasePopUp")]
        public async Task<IActionResult> PharmacyPurchasePopUp([FromQuery] string filterModel)
        {
            {
                var c = JsonConvert.DeserializeObject<PharmacyMedicinePurchaseFilterModel>(filterModel);
                return Ok(await service.PharmacyPurchasePopUp(c));
            }
        }

        /// <summary>
        /// History of Medicine expiration
        /// </summary>
        [HttpGet("medicineExpirationPopUp")]
        public async Task<IActionResult> MedicineExpirationPopUp([FromQuery] string filterModel)
        {
            {
                var c = JsonConvert.DeserializeObject<MedicineExpirationFilterModel>(filterModel);
                return Ok(await service.MedicineExpirationPopUp(c));
            }
        }

        /// <summary>
        /// Order Medicine
        /// </summary>
        [HttpPost("saveOrderMedicine")]
        public async Task<IActionResult> SaveOrderMedicine([FromBody] OrderMedicineInfo obj)
        {

            var result = await service.SaveOrderMedicine(obj);
            return Ok(result);


        }
        /// <summary>
        /// File upload
        /// <summary>
        [HttpPost("uploadFile")]
        public async Task<IActionResult> uploadFile(IFormFile file, [FromForm] long id, [FromForm] string fileType)
        {
            var uploadResult = _uploadService.Upload(filteTypes, file, destinationPath, 1000000);
            if (uploadResult.IsSuccess)
            {
                var setAttachResult = await SetAttachment(id, fileType, uploadResult.Data);
                uploadResult.Message = setAttachResult.Message;
                uploadResult.Data = string.Empty;
            }
            return Ok(uploadResult);
        }

    }
}

using Contracts.InputModels.DataEntryModels.Pharmacy;
using Contracts.InputModels.DataEntryModels.Warehouse;
using Contracts.InputModels.FilterModels.Base;
using Contracts.InputModels.FilterModels.Pharmacy;
using Contracts.InputModels.FilterModels.Warehouse;
using Contracts.Interface.Personnel;
using Contracts.Interface.Pharmacy;
using Contracts.Interface.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Service.Shared;
using System.Threading.Tasks;

namespace Pharmacy.Api.Controllers.V01.Pharmacy
{

    public class PharmacyController : AuthBaseWithAttachmentController<long>
    {
        private readonly IPharmacyService service;
        private readonly IUploadService _uploadService;
        private readonly string[] filteTypes = { "jpg", "jpeg", "png", "rar", "zip" };
        private readonly string destinationPath = "\\Mod_Project\\pharmacy";

        public PharmacyController(IPharmacyService service, IAuthenticateService _authenticateService, IUploadService uploadService, IAttachmentService attachmentService) : base(_authenticateService, attachmentService, service)
        {
            this.service = service;
            _uploadService = uploadService;
        }
        /// <summary>
        /// Display list of pharmacies
        /// <summary>
        /// 
        [HttpGet("list")]
        public async Task<IActionResult> Get([FromQuery] string filterModel, bool searchAll = true)
        {

            {
                var c = JsonConvert.DeserializeObject<PharmacyFilterModel>(filterModel);
                return Ok((searchAll)
                    ? await service.GetAll(JsonConvert.DeserializeObject<PharmacyFilterModel>(filterModel))
                    : await service.GetAllByCase(JsonConvert.DeserializeObject<CaseSearchFilter>(filterModel)));
            }

        }
        /// <summary>
        /// Save the new pharmacy
        /// <summary>
        /// 
        [HttpPost("ce")]
        public async Task<IActionResult> Post(PharmacyInfo pharmacy)
        {
            //warehouse.UserId = getCurrentUserId();
            var result = await service.Save(pharmacy);
            return Ok(result);
        }
        /// <summary>
        /// Show pharmacy information
        /// </summary>
        [HttpGet("showInfo")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await service.GetInfo(id);
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

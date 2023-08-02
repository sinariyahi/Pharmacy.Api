using Contracts.InputModels.DataEntryModels.Personnel;
using Contracts.InputModels.DataEntryModels.Pharmacy;
using Contracts.InputModels.FilterModels.Base;
using Contracts.InputModels.FilterModels.Patient;
using Contracts.InputModels.FilterModels.Personnel;
using Contracts.InputModels.FilterModels.Pharmacy;
using Contracts.Interface.Patient;
using Contracts.Interface.Personnel;
using Contracts.Interface.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Service.Shared;
using System.Threading.Tasks;

namespace Pharmacy.Api.Controllers.V01.Personnel
{

    public class PersonnelController : AuthBaseWithAttachmentController<long>
    {
        private readonly IPersonnelService service;

        private readonly IUploadService _uploadService;
        private readonly string[] filteTypes = { "jpg", "jpeg", "png", "rar", "zip" };
        private readonly string destinationPath = "\\Mod_Project\\personnel";

        public PersonnelController(IPersonnelService service, IAuthenticateService _authenticateService, IUploadService uploadService, IAttachmentService attachmentService) : base(_authenticateService, attachmentService, service)
        {
            this.service = service;
            _uploadService = uploadService;
        }
        /// <summary>
        /// Display list of personnels
        /// <summary>
        /// 
        [HttpGet("list")]
        public async Task<IActionResult> Get([FromQuery] string filterModel, bool searchAll = true)
        {

            {
                var c = JsonConvert.DeserializeObject<PersonnelFilterModel>(filterModel);
                return Ok((searchAll)
                    ? await service.GetAll(JsonConvert.DeserializeObject<PersonnelFilterModel>(filterModel))
                    : await service.GetAllByCase(JsonConvert.DeserializeObject<CaseSearchFilter>(filterModel)));
            }

        }
        /// <summary>
        /// Save the new personnel
        /// <summary>
        /// 
        [HttpPost("ce")]
        public async Task<IActionResult> Post(PersonnelInfo pharmacy)
        {
            //warehouse.UserId = getCurrentUserId();
            var result = await service.Save(pharmacy);
            return Ok(result);
        }

        /// <summary>
        /// Warehouse Personnel History
        /// </summary>
        [HttpGet("warehousePersonnelHistoryPopUp")]
        public async Task<IActionResult> WarehousePersonnelHistoryPopUp([FromQuery] string filterModel)
        {
            {
                var c = JsonConvert.DeserializeObject<WarehousePersonnelFilterModel>(filterModel);
                return Ok(await service.WarehousePersonnelHistoryPopUp(c));
            }
        }

        /// <summary>
        /// pharmacy Personnel History
        /// </summary>
        [HttpGet("pharmacyPersonnelHistoryPopUp")]
        public async Task<IActionResult> PharmacyPersonnelHistoryPopUp([FromQuery] string filterModel)
        {
            {
                var c = JsonConvert.DeserializeObject<PharmacyPersonnelFilterModel>(filterModel);
                return Ok(await service.PharmacyPersonnelHistoryPopUp(c));
            }
        }

        /// <summary>
        /// Show personnel information
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

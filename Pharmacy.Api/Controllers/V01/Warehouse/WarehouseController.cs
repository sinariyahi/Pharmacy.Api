using Contracts.InputModels.DataEntryModels.Warehouse;
using Contracts.InputModels.FilterModels.Base;
using Contracts.InputModels.FilterModels.Warehouse;
using Contracts.Interface.Pharmacy;
using Contracts.Interface.Security;
using Contracts.Interface.Warehouse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Service.Shared;
using System.Threading.Tasks;

namespace Pharmacy.Api.Controllers.V01.Warehouse
{
   
    public class WarehouseController : AuthBaseWithAttachmentController<long>
    {
        private readonly IWarehouseService service;

        private readonly IUploadService _uploadService;
        private readonly string[] filteTypes = { "jpg", "jpeg", "png", "rar", "zip" };
        private readonly string destinationPath = "\\Mod_Project\\projectManagement";

        public WarehouseController(IWarehouseService service, IAuthenticateService _authenticateService, IUploadService uploadService, IAttachmentService attachmentService) : base(_authenticateService, attachmentService, service)
        {
            this.service = service;
            _uploadService = uploadService;
        }
        /// <summary>
        /// Display the list of warehouses
        /// <summary>
        /// 
        [HttpGet("list")]
        public async Task<IActionResult> Get([FromQuery] string filterModel, bool searchAll = true)
        {

            {
                var c = JsonConvert.DeserializeObject<WarehouseFilterModel>(filterModel);
                return Ok((searchAll)
                    ? await service.GetAll(JsonConvert.DeserializeObject<WarehouseFilterModel>(filterModel))
                    : await service.GetAllByCase(JsonConvert.DeserializeObject<CaseSearchFilter>(filterModel)));
            }

        }
        /// <summary>
        /// Save the new warehouse
        /// <summary>
        /// 
        [HttpPost("ce")]
        public async Task<IActionResult> Post(WarehouseInfo warehouse)
        {
            //warehouse.UserId = getCurrentUserId();
            var result = await service.Save(warehouse);
            return Ok(result);
        }
        /// <summary>
        /// Show warehouse information
        /// </summary>
        [HttpGet("showInfo")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await service.GetInfo(id);
            return Ok(result);
        }

        /// <summary>
        /// Show Parish 
        /// </summary>        
        [HttpGet("acList")]
        public async Task<IActionResult> Get(string term, int cityId)
        {
            return Ok(await service.GetAllAutoComplete(term, cityId));

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

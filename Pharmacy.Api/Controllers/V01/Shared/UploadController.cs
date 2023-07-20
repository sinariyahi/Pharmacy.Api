using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Net.Http.Headers;

namespace Pharmacy.Api.Controllers.V01.Shared
{
 
    public class UploadController : BaseController
    {
        private readonly Configs _configs;

        public UploadController(IOptions<Configs> configs)
        {
            _configs = configs.Value;
        }

        [HttpPost/*, RequestSizeLimit(2000)*/]
        public IActionResult Upload()
        {
            var result = new GSActionResult<object>();
            try
            {
                var file = Request.Form.Files[0];
                string moduleName = Request.Form["module"];
                string dest = Request.Form["dest"];
                var folderName = string.Concat("\\DataFile_Repository", dest);
                //string currDir = Directory.GetCurrentDirectory();
                string currDir = string.IsNullOrWhiteSpace(_configs.UploadPath) ? Directory.GetCurrentDirectory() : _configs.UploadPath;
                var pathToSave = string.Concat(currDir, folderName);

                if (file.Length > 0)
                {
                    var v = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                    string fileName = Guid.NewGuid().ToString() + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"')); ;
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    result.Data = dbPath;
                    result.IsSuccess = true;
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                // return StatusCode(500, $"Internal server error: {ex}");
                //result.Data = "Internal server error";
                //result.IsSuccess = false;
                //return StatusCode(500, result);
                return ShowError("Internal server error");
            }
        }

        /// <summary>
        /// ایمپورت اکسل
        /// </summary>
        [HttpPost("uploadExcel")]
        public async Task<IActionResult> UploadExcel()
        {
            var result = new GSActionResult<object>();
            try
            {
                var file = Request.Form.Files[0];
                if (file.ContentType != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                    return ShowError("فرمت فایل ورودی مناسب نیست");
                string moduleName = Request.Form["module"];
                var folderName = string.Concat("\\DataFile_Repository\\ImportedFile", moduleName);
                string currDir = Directory.GetCurrentDirectory();
                var pathToSave = string.Concat(currDir, folderName);
                if (file.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + moduleName + ".xlsx";//ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    result.Data = fileName;
                    result.IsSuccess = true;
                    return Ok(result);
                }
                else
                {
                    return ShowError("فرمت فایل ورودی مناسب نمی باشد");

                }


            }
            catch (Exception ex)
            {
                return ShowError("Internal server error");
            }
        }


        [HttpPost("uploadFileNew")]
        public IActionResult UploadFileNew(IFormFile file, string dest)
        {
            var result = new GSActionResult<object>();
            try
            {
                if (file != null)
                {
                    var folderName = string.Concat("\\DataFile_Repository", dest);
                    //string currDir = Directory.GetCurrentDirectory();
                    string currDir = string.IsNullOrWhiteSpace(_configs.UploadPath) ? Directory.GetCurrentDirectory() : _configs.UploadPath;
                    var pathToSave = string.Concat(currDir, folderName);
                    string fileName = Guid.NewGuid().ToString() + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(file.FileName);
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    result.Data = dbPath;
                    result.IsSuccess = true;
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                return ShowError("Internal server error");
            }


        }
    }
}


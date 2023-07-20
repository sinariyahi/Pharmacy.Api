using Contracts;
using FileTypeChecker;
using FileTypeChecker.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Service.Service.Shared
{
    public class UploadFileService : IUploadService, IBaseService
    {
        private readonly Configs _configs;
        public UploadFileService(IOptions<Configs> configs)
        {
            _configs = configs.Value;
        }
        public GSActionResult<string> Upload(string[] fileTypes, IFormFile file, string dest, int limitationSize)
        {
            var uploadResult = new GSActionResult<string>();
            string result = string.Empty;
            var folderName = string.Concat("\\DataFile_Repository\\", dest);
            string currDir = string.IsNullOrWhiteSpace(_configs.UploadPath) ? Directory.GetCurrentDirectory() : _configs.UploadPath;
            var pathToSave = string.Concat(currDir, folderName);

            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(file.FileName);
                var fullPath = Path.Combine(pathToSave, fileName);
                if (file.Length <= limitationSize)
                {
                    result = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        var isRecognizableType = FileTypeValidator.IsTypeRecognizable(stream);
                        if (!isRecognizableType)
                        {
                            uploadResult.IsSuccess = false;
                            uploadResult.Message = "فایل انتخابی مشکل دارد";
                            result = string.Empty;
                        }
                        else
                        {
                            IFileType fileType = FileTypeValidator.GetFileType(stream);
                            //string fileExtention = fileType.Extension.ToLower();
                            string fileExtention = Path.GetExtension(file.FileName).ToLower();
                            fileExtention = fileExtention.Substring(1, fileExtention.Length - 1);
                            if (/*!(stream.IsImage() &&*/ !fileTypes.Contains(fileExtention))
                            {
                                result = string.Empty;
                                uploadResult.IsSuccess = false;
                                uploadResult.Message = "لطفا فایل با فرمت صحیح انتخاب نمایید";
                            }
                        }
                    }
                    uploadResult.Data = result;
                    if (string.IsNullOrEmpty(result))
                    {
                        uploadResult.IsSuccess = false;
                        File.Delete(fullPath);
                    }
                    else
                        uploadResult.IsSuccess = true;
                }
                else
                {
                    uploadResult.IsSuccess = false;
                    uploadResult.Message = "حجم فایل بیش از اندازه است";
                }
            }
            else
            {
                uploadResult.IsSuccess = false;
                uploadResult.Message = "هیچ فایلی انتخاب نشده است";
            }
            return uploadResult;
        }


    }
}


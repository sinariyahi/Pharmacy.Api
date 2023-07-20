using Contracts.Interface.Shared;
using Contracts;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Dto.Base;
using System.IO;

namespace Service.Service.Shared
{
    public class AttachmentService:IAttachmentService, IBaseService
    {
        private readonly IGenericRepository<AttachmentDto, AttachmentDto> _repo;
    private readonly Configs _configs;
    public AttachmentService(IGenericRepository<AttachmentDto, AttachmentDto> repo, IOptions<Configs> configs)
    {
        _repo = repo;
        _configs = configs.Value;
    }
    public async Task<AttachmentDto> GetAttachment(dynamic id, string fieldName, string spName)
    {

        string currDir = string.IsNullOrWhiteSpace(_configs.UploadPath) ? Directory.GetCurrentDirectory() : _configs.UploadPath;
        var result = await _repo.GetAllSingle(spName, new { id = id, fieldName = fieldName });
        if (result != null)
        {
            if (result.Count() > 0)
            {
                var output = result.FirstOrDefault();
                output.AttachmentPath = string.Concat(currDir, output.AttachmentPath);
                return output;
            }
            else
                return null;
        }
        else
            return null;

    }
    public async Task<GSActionResult<object>> SetAttachment(dynamic id, string fieldName, string filePath, string spName)
    {
        var result = new GSActionResult<object>();
        try
        {
            result.Data = await _repo.Insert(spName, new { id = id, fieldName = fieldName, docPath = filePath });
            result.IsSuccess = true;
        }
        catch (Exception ex)
        {
            result.Message = "خطا";
            result.IsSuccess = false;
        }
        return result;

    }

}
}

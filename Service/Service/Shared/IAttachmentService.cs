using Contracts;
using Contracts.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Shared
{
    public interface IAttachmentService
    {
        Task<AttachmentDto> GetAttachment(object id, string fieldName, string spName);
        Task<GSActionResult<object>> SetAttachment(dynamic id, string fieldName, string filePath, string spName);

    }
}

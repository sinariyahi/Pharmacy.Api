using Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Shared
{
    public interface IUploadService
    {
        GSActionResult<string> Upload(string[] fileTypes, IFormFile file, string dest, int limitationSize);
    }
}

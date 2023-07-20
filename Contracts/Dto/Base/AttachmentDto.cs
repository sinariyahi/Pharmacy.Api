using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.Base
{
    public class AttachmentDto
    {
        public string AttachmentPath { get; set; }
        public string AttachmentName { get; set; }
        public string ContentType { get; set; }
    }
}

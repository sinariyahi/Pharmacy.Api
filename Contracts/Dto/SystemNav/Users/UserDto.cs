using Contracts.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.SystemNav.Users
{
    public class UserDto:BaseDto<Guid>
    {
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string UserTypeName { get; set; }
        public string ZoneName { get; set; }
        public string AscCode { get; set; }
        public string LastLogine { get; set; }
    }
}

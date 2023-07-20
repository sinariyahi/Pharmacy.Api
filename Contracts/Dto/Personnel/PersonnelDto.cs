using Contracts.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.Personnel
{
    public class PersonnelDto : BaseDto<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int NationalCode { get; set; }
        public int Mobile { get; set; }
        public int HomeTel { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        
    }
}

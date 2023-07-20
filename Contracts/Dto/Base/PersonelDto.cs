using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.Base
{
    public class PersonelDto:BaseDto<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string NationalCode { get; set; }
        public string CityName { get; set; }
        public string Gender { get; set; }
        public string CreateDate { get; set; }

    }
}

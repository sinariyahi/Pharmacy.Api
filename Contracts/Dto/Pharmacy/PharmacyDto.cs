using Contracts.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.Pharmacy
{
    public class PharmacyDto : BaseDto<int>
    {
        public string PharmacyName { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Mobile { get; set; }
        public Int64 PersonnelNumber { get; set; }
        public Int64 MedicineNumber { get; set; }
        public Int64 PatientNumber { get; set; }


    }
}

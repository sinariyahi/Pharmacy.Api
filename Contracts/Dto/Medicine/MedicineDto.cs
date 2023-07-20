using Contracts.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.Medicine
{
    public class MedicineDto : BaseDto<int>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TypeMedicine { get; set; }
        public string PharmacyName { get; set; }
        public string Province { get; set; }
        public string City { get; set; }

    }
}

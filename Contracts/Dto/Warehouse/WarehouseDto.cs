using Contracts.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.Warehouse
{
    public class WarehouseDto : BaseDto<int>
    {
        public string Name { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public int PersonnelNumber { get; set; }
        public int MedicineNumber { get; set; }

    }
}

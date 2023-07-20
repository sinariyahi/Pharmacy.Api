using Contracts.InputModels.DataEntryModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.DataEntryModels.Warehouse
{
    public class WarehouseInfo : BaseDataEntry<long>
    {
        public DateTime StartDate { get; set; }
        public string FirstName { get; set; }
        public int MedicineNumber { get; set; }
        public int PersonnelNumber { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public int Mobile { get; set; }
        public int Tel { get; set; }
    }
}

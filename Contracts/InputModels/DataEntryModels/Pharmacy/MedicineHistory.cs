using Contracts.InputModels.DataEntryModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.DataEntryModels.Pharmacy
{
    public class MedicineHistory : BaseDataEntry<long>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string MedicineName { get; set; }
        public Int64 MedicineNumber { get; set; }
    }
}

using Contracts.InputModels.DataEntryModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.DataEntryModels.Pharmacy
{
    public class PharmacyInfo : BaseDataEntry<long>
    {
        public string Name { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public int Mobile  { get; set; }
        public int Tel { get; set; }
        public int MedicineNumber { get; set; }
        public int PatientNumber { get; set; }
        public int PersonnelNumber { get; set; }

    }
}

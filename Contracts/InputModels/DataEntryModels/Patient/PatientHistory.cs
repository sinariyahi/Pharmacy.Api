using Contracts.InputModels.DataEntryModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.DataEntryModels.Patient
{
    public class PatientHistory : BaseDataEntry<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Mobile { get; set; }
        public int HomeTel { get; set; }
        public int NationalCode { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string PharmacyName { get; set; }
        public string MedicineName { get; set; }
        public Int64 MedicineNumber { get; set; }
    }
}

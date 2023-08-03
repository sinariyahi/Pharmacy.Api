using Contracts.InputModels.DataEntryModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.DataEntryModels.Medicine
{
    public class PatientMedicinePurchase : BaseDataEntry<long>
    {

        public string PharmacyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string MedicineName { get; set; }
    }
}

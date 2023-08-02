using Contracts.InputModels.FilterModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.FilterModels.Pharmacy
{
    public class patientHistoryFilterModel : BaseFilter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

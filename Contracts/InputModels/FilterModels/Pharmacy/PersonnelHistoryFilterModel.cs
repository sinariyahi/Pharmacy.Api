using Contracts.InputModels.FilterModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.FilterModels.Pharmacy
{
    public class PersonnelHistoryFilterModel : BaseFilter 
    {
        public string FirstName { get; set; }
        public string FullName { get; set; }
    }
}

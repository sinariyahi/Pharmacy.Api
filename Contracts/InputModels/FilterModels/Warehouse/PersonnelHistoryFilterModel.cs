using Contracts.InputModels.FilterModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.FilterModels.Warehouse
{
    public class PersonnelHistoryFilterModel : BaseFilter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

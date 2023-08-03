using Contracts.InputModels.FilterModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.FilterModels.Warehouse
{
    public class PharmacyHistoryFilterModel : BaseFilter
    {
        public string PharmacyName { get; set; }
    }
}

using Contracts.InputModels.FilterModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.FilterModels.Warehouse
{
    public class WarehouseFilterModel : BaseFilter
    {
        public DateTime StartDate { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        
    }
}

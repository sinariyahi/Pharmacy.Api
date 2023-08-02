using Contracts.InputModels.FilterModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.FilterModels.Personnel
{
    public class WarehousePersonnelFilterModel : BaseFilter
    {
        public string WarehouseName { get; set; }
    }
}

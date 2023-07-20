using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.FilterModels.Base
{
    public class DropDownFilter
    {
        public int parentId { get; set; }
        public int typeId { get; set; }
    }
}

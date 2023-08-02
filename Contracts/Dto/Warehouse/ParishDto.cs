using Contracts.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.Warehouse
{
    public class ParishDto : BaseDto<int>
    {
        public string ParishName { get; set; }
    }
}

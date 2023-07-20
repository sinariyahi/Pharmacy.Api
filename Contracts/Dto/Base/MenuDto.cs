using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.Base
{
    public class MenuDto
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public int ParentId { get; set; }

        public string route { get; set; }

    }
}

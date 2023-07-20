using Contracts.InputModels.FilterModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.FilterModels.SystemNav
{
    public class UserListFilterModel:BaseFilter
    {
        public string UserName { get; set; }
        public string LastName { get; set; }
    }
}

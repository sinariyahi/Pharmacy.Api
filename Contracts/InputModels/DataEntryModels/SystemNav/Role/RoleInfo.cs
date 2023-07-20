using Contracts.InputModels.DataEntryModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.DataEntryModels.SystemNav.Role
{
    public class RoleInfo:BaseDataEntry<long>
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
    }
}

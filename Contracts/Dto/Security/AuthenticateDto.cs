using Contracts.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.Security
{
    //public class AuthenticateDto
    //{

    //}
    public class Permission
    {
        public Guid roleId { get; set; }
        public virtual ICollection<BaseMenuPermission> permissionTypeList { get; set; }


    }
}

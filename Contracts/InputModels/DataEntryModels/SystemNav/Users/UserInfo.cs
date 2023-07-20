using Contracts.Dto.Base;
using Contracts.Dto.SystemNav.Roles;
using Contracts.Entities.Security;
using Contracts.InputModels.DataEntryModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.InputModels.DataEntryModels.SystemNav.Users
{
    public class UserInfo:BaseDataEntry<Guid>
    {
        public string UserName { get; set; }
        public PersonelDto Person { get; set; }
        public int UserTypeId { get; set; }
        public byte IpStatus { get; set; }
        public byte OrganizationId { get; set; }
        public bool IsDeny { get; set; }
        public bool Isclosed { get; set; }
        public int ShopId { get; set; }
        public int ProductWarehouseId { get; set; }
        public string UserAliasName { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public int PasswordFormat { get; set; }
        public bool ResetHardwareCode { get; set; }
        public string Gmail { get; set; }
        public virtual ICollection<RoleDto> UserRoles { get; set; }
        public virtual ICollection<SecurityIp> UserIpList { get; set; }
        public virtual ICollection<MenuPermission> UserMenuPermissionList { get; set; }

    }
    public class SecurityIp
    {
        public int Id { get; set; }
        public string Ip { get; set; }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Entities.Security
{
    //Id	CurrentMenuId	Ext	FirstName	LastName	Password	PasswordFormat	PasswordSalt	RefreshToken	ThemId	Token	UserId

    public class MenuPermission : BaseMenuPermission
    {
        public string PermissionTitle { get; set; }
        public int PermissionValue { get; set; }
    }
    public class BaseMenuPermission
    {
        public Guid ModuleId { get; set; }
        public Guid PermissionId { get; set; }
        public string PermissionName { get; set; }
    }
    public class UserDataAccess
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public bool Permission { get; set; }
    }
    public class UserDataAccessSave
    {
        public ICollection<UserDataAccess> PermissionList { get; set; }
        public int PermissionTypeId { get; set; }
        public string CurrentUserName { get; set; }
        public Guid UserId { get; set; }

    }
}

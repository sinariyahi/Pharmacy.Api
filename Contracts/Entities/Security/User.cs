using Contracts.Dto.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Entities.Security
{
    public class User
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid UserTypeId { get; set; }
        public short ThemeId { get; set; }
        public string PasswordSalt { get; set; }
        public string Password { get; set; }
        public int PasswordFormat { get; set; }
        public int CurrentMenuId { get; set; }
        public int Ext { get; set; }
        public bool IsWhAsc { get; set; }
        public bool IsWh2017 { get; set; }
        public DateTime ExpiredDate { get; set; }

        public virtual IEnumerable<Permission> MenuPermissionList { get; set; }

        public enum UserTypeCode
        {
            Admin,
            Normal,
            UserPharmacy,
            Doctor,
            Patient,


        }
        public class Attributes
        {
            public static Dictionary<int, Guid> Attribute = new Dictionary<int, Guid>()
            {
                {(int)UserTypeCode.Admin, Guid.Parse("04904F4F-6C22-4400-8E01-68B593630D03")},
                {(int)UserTypeCode.Normal, Guid.Parse("04904F5F-6C22-4400-8E01-68B593630D03")},
                {(int)UserTypeCode.UserPharmacy, Guid.Parse("04904F6F-6C22-4400-8E01-68B593630D03")},
                {(int)UserTypeCode.Doctor, Guid.Parse("04904F7F-6C22-4400-8E01-68B593630D03")},
                {(int)UserTypeCode.Patient, Guid.Parse("04904F7F-6C22-4400-8E01-68B593630D03")}

            };
        }
    }
}

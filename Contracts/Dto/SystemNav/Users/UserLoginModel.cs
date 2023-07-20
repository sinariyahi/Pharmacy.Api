using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dto.SystemNav.Users
{
    public class UserLoginModel
    {
        [DefaultValue("s-riahi")]
        public string UserName { get; set; }
        [DefaultValue("123456789")]
        public string Password { get; set; }
    }
    public class UserRefreshModel
    {
        public string UserName { get; set; }
        public string RefreshToken { get; set; }
    }
}

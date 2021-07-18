using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Mobile.Models.Entiries
{
    public class User : BaseModel.BaseEntity<string>
    {
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
        public string Status { get; set; }
        public string PasswordHesher { get; set; }
    }
}

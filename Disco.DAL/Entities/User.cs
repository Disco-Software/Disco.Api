using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace Disco.DAL.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public Role Role { get; set; }
        public string Status { get; set; }
    }
}

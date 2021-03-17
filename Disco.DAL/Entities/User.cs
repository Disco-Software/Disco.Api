using System;
using System.Collections.Generic;
using System.Text;
using Disco.DAL.Interfaces;
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
        public List<Post> Posts { get; set; }
    }
}

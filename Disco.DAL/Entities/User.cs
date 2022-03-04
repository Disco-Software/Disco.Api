using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.DAL.Entities
{
    public class User : IdentityUser<int>
    {        
        public Profile Profile { get; set; }
    }
}

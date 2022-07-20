using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Disco.DAL.Models
{
    public class User : IdentityUser<int>
    {
        public string RoleName { get; set; }
        public string RefreshToken { get; set; }
        [Column(TypeName = "date")]
        public DateTime RefreshTokenExpiress { get; set; }
        public Profile Profile { get; set; }

    }
}

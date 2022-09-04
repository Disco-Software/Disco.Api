using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disco.Domain.Models
{
    public class User : IdentityUser<int>
    {
        public string RoleName { get; set; }
        public string RefreshToken { get; set; }
        [Column(TypeName = "date")]
        public DateTime RefreshTokenExpiress { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfRegister { get; set; }
        public Profile Profile { get; set; }

    }
}

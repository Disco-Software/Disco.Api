using System;

namespace Disco.Tests.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiress { get; set; }
        public Profile Profile { get; set; }

    }
}
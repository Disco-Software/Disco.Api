using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;

namespace Disco.Business.Interfaces.Dtos.Account
{
    public class UserResponseDto
    {
        public User User { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int AccessTokenExpirce { get; set; }
    }
}

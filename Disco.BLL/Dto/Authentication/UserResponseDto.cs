using Disco.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Dto.Authentication
{
    public class UserResponseDto
    {
        public User User { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}

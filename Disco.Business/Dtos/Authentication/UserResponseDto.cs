﻿using Disco.Domain.Models;

namespace Disco.Business.Dtos.Authentication
{
    public class UserResponseDto
    {
        public User User { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
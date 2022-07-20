using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Business.Dto.Authentication
{
    public class RefreshTokenDto
    {
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
    }
}

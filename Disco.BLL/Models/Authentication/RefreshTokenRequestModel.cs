using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models
{
    public class RefreshTokenRequestModel
    {
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
    }
}

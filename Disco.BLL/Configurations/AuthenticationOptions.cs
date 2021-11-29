using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Configurations
{
    public class AuthenticationOptions
    {
        public string Issure { get; set; }
        public string Audience { get; set; }
        public int ExpiresAfterDays { get; set; }
        public string SigningKey { get; set; }
        public byte[] SigningKeyBytes => Convert.FromBase64String(SigningKey);
    }
}

using System;

namespace Disco.Business.Configurations
{
    public class AuthenticationOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiresAfterMitutes { get; set; }
        public string SigningKey { get; set; }
        public byte[] SigningKeyBytes => Convert.FromBase64String(SigningKey);
    }
}

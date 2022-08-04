using System;
using System.Threading.Tasks;

namespace Disco.Business.Dtos.Authentication
{
    public class RegistrationDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public static implicit operator Task<object>(RegistrationDto v)
        {
            throw new NotImplementedException();
        }
    }
}

using Disco.Business.Interfaces.Attributes;
using Disco.Business.Interfaces.Validators.Account;

namespace Disco.Business.Interfaces.Dtos.Account
{
    [ValidationType(typeof(LogInValidator))]
    public class LoginDto 
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

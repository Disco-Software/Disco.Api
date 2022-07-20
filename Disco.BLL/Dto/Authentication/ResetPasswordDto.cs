using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Dto.Authentication
{
    public class ResetPasswordDto
    {
        public string Email { get; set; }
        public string ConfirmationToken { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

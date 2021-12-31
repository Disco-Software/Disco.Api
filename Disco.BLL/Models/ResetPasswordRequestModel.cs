using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models
{
    public class ResetPasswordRequestModel
    {
        public string Email { get; set; }
        public string ConfirmationToken { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

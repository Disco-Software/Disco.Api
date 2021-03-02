using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.DTO
{
    public class RegisterDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

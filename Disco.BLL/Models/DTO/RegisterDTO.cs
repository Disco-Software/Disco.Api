using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models.DTO
{
    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

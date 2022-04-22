﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Models.Authentication
{
    public class RegistrationModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public static implicit operator Task<object>(RegistrationModel v)
        {
            throw new NotImplementedException();
        }
    }
}
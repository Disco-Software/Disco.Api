using Disco.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models.DTO
{
    public class ForgotPasswordDTO
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public ForgotPasswordResults ForgotPasswordResult { get; set; }
    }
}

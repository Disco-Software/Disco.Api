using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models.DTO
{
    public class ForgotPasswordResultDTO
    {
        public string Eamil { get; set; }
        public string Password { get; set; }
        public string ResponseMessage { get; set; }
    }
}

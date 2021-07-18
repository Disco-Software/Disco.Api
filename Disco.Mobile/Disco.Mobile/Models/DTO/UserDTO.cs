using Disco.Mobile.Models;
using Disco.Mobile.Models.Entiries;
using Disco.Mobile.Services.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.DTO
{
    public class UserDTO
    {
        public User User { get; set; }
        public VarificationResults VarificationResult { get; set; }
    }
}

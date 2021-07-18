using Disco.BLL.Infrastructure;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Models.DTO
{
    public class UserDTO
    {
        public User User { get; set; }
        public string VarificationResult { get; set; }
    }
}

using Disco.BLL.DTO;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Abstracts
{
    public abstract class UserDTOExtinsions
    {
        public static UserDTO Ok(User user, string varificationResult) => 
            new UserDTO{ User = user, VarificationResult = varificationResult };

        public static UserDTO Ok() =>
            new UserDTO();

        public static UserDTO BadRequest(string varificationResult) => new UserDTO { VarificationResult = varificationResult };
    }
}

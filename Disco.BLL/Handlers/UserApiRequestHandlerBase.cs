using Disco.BLL.DTO;
using Disco.BLL.Models.Authentication;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.BLL.Abstracts
{
    public abstract class UserRequestHandlerBase
    {
        public static UserResponseModel Ok(User user, string varificationResult) => 
            new UserResponseModel{ User = user, VarificationResult = varificationResult };

        public static UserResponseModel Ok() =>
            new UserResponseModel();

        public static UserResponseModel BadRequest(string varificationResult) => new UserResponseModel { VarificationResult = varificationResult };
    }
}

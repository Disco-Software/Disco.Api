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
        public static UserResponseModel Ok(User user, string accessToken = "", string refreshToken = "") => 
            new UserResponseModel{ User = user, AccessToken = accessToken, RefreshToken = refreshToken };

        public static UserResponseModel Ok() =>
            new UserResponseModel();

        public static UserResponseModel BadRequest(string varificationResult) => throw new Exception(varificationResult);
    }
}

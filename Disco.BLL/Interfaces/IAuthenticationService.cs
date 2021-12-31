﻿using Disco.BLL.DTO;
using Disco.BLL.Models;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UserDTO> LogIn(LoginModel model);
        Task<UserDTO> Register(RegistrationModel model);
        Task<UserDTO> RefreshToken(string email);
        Task<UserDTO> Facebook(string accessToken);
        Task<UserDTO> Apple(AppleLogInModel model);
        Task<string> ForgotPassword(string email);
        Task<UserDTO> ResetPassword(ResetPasswordRequestModel model);
        public string GenerateJwtToken(User user);
    }
}

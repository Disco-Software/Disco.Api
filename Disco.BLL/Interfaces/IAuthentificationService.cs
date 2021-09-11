﻿using Disco.BLL.DTO;
using Disco.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IAuthentificationService
    {
        Task<UserDTO> Login(LoginModel model);
        Task<UserDTO> Register(RegistrationModel model);
        Task<UserDTO> Facebook(string accessToken);
    }
}
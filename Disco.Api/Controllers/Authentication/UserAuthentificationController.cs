﻿using Disco.BLL.DTO;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Api.Controllers.Authentification
{
    [ApiController]
    [Route("api/user/authentication")]
    public class UserAuthentificationController : Controller
    {
        private readonly IServiceManager serviceManager;

        public UserAuthentificationController(IServiceManager _serviceManager) =>
            serviceManager = _serviceManager;

        /// <summary>
        /// User log in by email and password
        /// </summary>
        /// <param name="model">email and password</param>
        /// <returns>object: UserDto with user and varification result</returns>
        [HttpPost("log-in"), AllowAnonymous]
        public async Task<UserDTO> LogIn([FromForm] LoginModel model) =>
            await serviceManager.AuthentificationService.LogIn(model);

        [HttpPost("log-in/facebook"), AllowAnonymous]
        public async Task<UserDTO> Facebook([FromBody] FacebookRequestModel model) =>
            await serviceManager.AuthentificationService.Facebook(model.AccessToken);

        [HttpPost("log-in/google"), AllowAnonymous]
        public async Task<IActionResult> Google([FromBody] string accessToken) =>
            Ok("Google");

        [HttpPost("log-in/apple"), AllowAnonymous]
        public async Task<UserDTO> Apple([FromBody] AppleLogInModel model) =>
            await serviceManager.AuthentificationService.Apple(model);

        [HttpPut("refresh")]
        public async Task<UserDTO> RefreshToken([FromBody] RefreshTokenRequestModel model) =>
            await serviceManager.AuthentificationService.RefreshToken(model.Email);

        [HttpPost("registration"), AllowAnonymous]
        public async Task<UserDTO> Registration([FromForm] RegistrationModel model) =>
            await serviceManager.AuthentificationService.Register(model);

        [HttpPost("forgot_password")]
        public async Task<string> ForgotPassword([FromQuery] string email) =>
            await serviceManager.AuthentificationService.ForgotPassword(email);

        [HttpPut("reset-password")]
        public async Task<UserDTO> ResetPassword([FromBody] ResetPasswordRequestModel model) =>
            await serviceManager.AuthentificationService.ResetPassword(model);
    }
}

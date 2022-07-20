﻿using Disco.BLL.Dto;
using Disco.BLL.Interfaces;
using Disco.BLL.Dto;
using Disco.BLL.Dto.Apple;
using Disco.BLL.Dto.Authentication;
using Disco.BLL.Dto.Facebook;
using Disco.BLL.Dto.Google;
using Disco.BLL.Services;
using Google.Apis.Auth.AspNetCore3;
using Google.Apis.PeopleService.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Api.Controllers
{
    [ApiController]
    [Route("api/user/authentication")]
    public class UserAuthenticationController : Controller
    {
        private readonly IAuthenticationService authenticationService;

        public UserAuthenticationController(IAuthenticationService _authenticationService)
        {
            this.authenticationService = _authenticationService;
        }

        /// <summary>
        /// User log in by email and password
        /// </summary>
        /// <param name="model">email and password</param>
        /// <returns>object: UserDto with user and varification result</returns>
        [HttpPost("log-in"), AllowAnonymous]
        public async Task<IActionResult> LogIn([FromBody] LoginDto model)
        {
            return await authenticationService.LogIn(model);
        }

        [HttpPost("log-in/facebook"), AllowAnonymous]
        public async Task<IActionResult> Facebook([FromBody] FacebookRequestDto model)
        {
           return await authenticationService.Facebook(model);
        }

        [HttpPost("log-in/google"), AllowAnonymous, GoogleScopedAuthorize(PeopleServiceService.ScopeConstants.UserinfoProfile)]
        public async Task<IActionResult> Google([FromServices] IGoogleAuthProvider googleAuthProvider)
        {
            return await authenticationService.Google(googleAuthProvider);
        }

        [HttpPost("log-in/apple"), AllowAnonymous]
        public async Task<IActionResult> Apple([FromBody] AppleLogInDto model)
        {
            return await authenticationService.Apple(model);
        }

        [HttpPut("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto model)
        {
            return await authenticationService.RefreshToken(model);
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationDto model)
        {
            return await authenticationService.Register(model);
        }

        [HttpPost("forgot-password"), AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
        {
            return await authenticationService.ForgotPassword(model.Email);
        }

        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            return await authenticationService.ResetPassword(model);
        }
    }
}

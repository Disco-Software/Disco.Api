using AutoMapper;
using Disco.Business.Interfaces.Validators;
using Disco.Business.Constants;
using Disco.Business.Interfaces.Dtos.Apple;
using Disco.Business.Interfaces.Dtos.Account;
using Disco.Business.Interfaces.Dtos.Google;
using Disco.Business.Interfaces;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.Extensions.Hosting;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Integration.Interfaces.Dtos.Facebook;
using Disco.Integration.Interfaces.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Disco.ApiServices.Controllers;
using MediatR;
using Disco.ApiServices.Features.Account.User.RequestHandlers.LogIn;
using Disco.ApiServices.Features.Account.User.RequestHandlers.Facebook;
using Disco.ApiServices.Features.Account.User.RequestHandlers.Google;
using Disco.ApiServices.Features.Account.User.RequestHandlers.Apple;
using Disco.ApiServices.Features.Account.User.RequestHandlers.RefreshToken;
using Disco.ApiServices.Features.Account.User.RequestHandlers.Registration;

namespace Disco.ApiServices.Features.Account.User
{
    [AllowAnonymous]
    [Route("api/user/account")]
    public class AccountController : UserController
    {
        private readonly IMediator _mediator;

        public AccountController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("log-in")]
        public async Task<ActionResult<UserResponseDto>> LogInAsync([FromBody] LoginDto dto) =>
            await _mediator.Send(new LogInRequest(dto));

        [HttpPost("log-in/facebook")]
        public async Task<ActionResult<UserResponseDto>> Facebook([FromBody] FacebookRequestDto dto) =>
            await _mediator.Send(new FacebookRequest(dto));


        [HttpPost("log-in/google")]
        public async Task<ActionResult<UserResponseDto>> Google([FromBody] GoogleLogInDto dto) =>
            await _mediator.Send(new GoogleRequest(dto));

        [HttpPost("log-in/apple")]
        public async Task<ActionResult<UserResponseDto>> Apple([FromBody] AppleLogInDto dto) =>
            await _mediator.Send(new AppleRequest(dto));

        [HttpPut("refresh")]
        public async Task<ActionResult<UserResponseDto>> RefreshToken([FromBody] RefreshTokenDto dto) =>
            await _mediator.Send(new RefreshTokenRequest(dto));

        [HttpPost("registration")]
        public async Task<ActionResult<UserResponseDto>> Registration([FromBody] RegistrationDto dto) => 
            await _mediator.Send(new RegistrationRequest(dto));
    }
}

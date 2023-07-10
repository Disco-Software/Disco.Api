using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Dtos.Account;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Disco.Domain.Models;
using Disco.Business.Interfaces.Validators;
using Disco.Business.Constants;
using AutoMapper;
using System;
using Disco.Business.Interfaces.Interfaces;
using Disco.ApiServices.Controllers;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using Disco.ApiServices.Features.Account.Admin.RequestHandlers.LogIn;
using Disco.ApiServices.Features.Account.Admin.RequestHandlers.RefreshToken;

namespace Disco.ApiServices.Features.Account.Admin
{
    [Route("api/admin/account")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : AdminController
    {
        private readonly IMediator _mediator;

        public AccountController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("log-in")]
        public async Task<ActionResult<UserResponseDto>> LogIn([FromBody] LoginDto dto) =>
            await _mediator.Send(new LogInRequest(dto));

        [HttpPut("refresh")]
        public async Task<ActionResult<UserResponseDto>> RefreshToken([FromBody] RefreshTokenDto dto) =>
            await _mediator.Send(new RefreshTokenRequest(dto));
    }
}
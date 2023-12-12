using Disco.ApiServices.Controllers;
using Disco.ApiServices.Features.Account.Admin.RequestHandlers.LogIn;
using Disco.ApiServices.Features.Account.Admin.RequestHandlers.RefreshToken;
using Disco.Business.Interfaces.Dtos.Account;
using Disco.Business.Interfaces.Dtos.Account.Admin.LogIn;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<ActionResult<LogInResponseDto>> LogIn([FromBody] LogInRequestDto dto) =>
            await _mediator.Send(new LogInRequest(dto));

        [HttpPut("refresh")]
        public async Task<ActionResult<UserResponseDto>> RefreshToken([FromBody] RefreshTokenDto dto) =>
            await _mediator.Send(new RefreshTokenRequest(dto));
    }
}
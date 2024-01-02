using Disco.ApiServices.Controllers;
using Disco.ApiServices.Features.AccountPassword.Admin.RequestHandlers.ForgotPassword;
using Disco.ApiServices.Features.AccountPassword.Admin.RequestHandlers.RecoveryPassword;
using Disco.ApiServices.Features.AccountPassword.User.RequestHandlers.RecoveryPasswordCodeChecking;
using Disco.Business.Interfaces.Dtos.AccountPassword.Admin.ForgotPassword;
using Disco.Business.Interfaces.Dtos.AccountPassword.Admin.ResetPassword;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountPassword.User
{
    [Route("api/user/account/password")]
    public class AccountPasswordController : UserController
    {
        private readonly IMediator _mediator;

        public AccountPasswordController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("forgot"), AllowAnonymous]
        public async Task<ActionResult<string>> ForgotPassword([FromBody] ForgotPasswordDto dto) =>
            await _mediator.Send(new ForgotPasswordRequest(dto));

        [HttpPost("confirm/code"), AllowAnonymous]
        public async Task<ActionResult<bool>> ConfirmCodeAsync(
            [FromQuery] string email,
            [FromQuery] int code) =>
            await _mediator.Send(new RecoveryPasswordCodeCheckingRequest(email, code));

        [HttpPut("recovery"), AllowAnonymous]
        public async Task<ActionResult<string>> ResetPassword([FromBody] RecoveryPasswordRequestDto dto) =>
            await _mediator.Send(new RecoveryPasswordRequest(dto));
    }
}

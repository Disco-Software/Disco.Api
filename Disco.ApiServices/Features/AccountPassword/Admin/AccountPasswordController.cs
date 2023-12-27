using Disco.ApiServices.Features.AccountPassword.Admin.RequestHandlers.ChangeSelectedUserPassword;
using Disco.ApiServices.Features.AccountPassword.Admin.RequestHandlers.ForgotPassword;
using Disco.ApiServices.Features.AccountPassword.Admin.RequestHandlers.ResetPassword;
using Disco.Business.Interfaces.Dtos.AccountPassword.Admin.ChangeSelectedUserPassword;
using Disco.Business.Interfaces.Dtos.AccountPassword.Admin.ForgotPassword;
using Disco.Business.Interfaces.Dtos.AccountPassword.Admin.ResetPassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountPassword.Admin
{
    [Route("api/admin/account/password")]
    public class AccountPasswordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountPasswordController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("forgot")]
        public async Task<ActionResult<string>> ForgotPassword([FromBody] ForgotPasswordDto dto) =>
            await _mediator.Send(new ForgotPasswordRequest(dto));

        [HttpPut("reset")]
        public async Task<ActionResult<string>> ResetPassword([FromBody] ResetPasswordDto dto) =>
            await _mediator.Send(new ResetPasswordRequest(dto));

        [HttpPut("change/password")]
        public async Task<ActionResult<ChangeSelectedUserPasswordResponseDto>> ChangeAccountPasswordAsync(
            [FromBody] ChangeSelectedUserPasswordRequestDto changeSelectedUserPasswordRequestDto) =>
            await _mediator.Send(new ChangeSelectedUserPasswordRequest(changeSelectedUserPasswordRequestDto));
    }
}

using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Disco.Business.Interfaces.Interfaces;
using MediatR;
using Disco.ApiServices.Features.AccountPassword.Admin.RequestHandlers.ForgotPassword;
using Disco.ApiServices.Features.AccountPassword.Admin.RequestHandlers.ResetPassword;
using Disco.Business.Interfaces.Dtos.AccountPassword.Admin.ForgotPassword;
using Disco.Business.Interfaces.Dtos.AccountPassword.Admin.ResetPassword;

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

    }
}

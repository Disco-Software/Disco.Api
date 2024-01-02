using Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.ChangePhoto;
using Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.CheckEmailConfirmation;
using Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.ConfirmEmail;
using Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.GetCurrentUser;
using Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.GetUserById;
using Disco.Business.Interfaces.Dtos.AccountDetails.User.ChangePhoto;
using Disco.Business.Interfaces.Dtos.AccountDetails.User.CheckEmailConfirmation;
using Disco.Business.Interfaces.Dtos.AccountDetails.User.GetCurrentUser;
using Disco.Business.Interfaces.Dtos.AccountDetails.User.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.AccountDetails.User
{
    [Route("api/user/account/details")]
    public class AccountDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountDetailsController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("change/photo")]
        public async Task<ActionResult<ChangePhotoResponseDto>> ChangePhotoAsync([FromForm] ChangePhotoRequestDto dto) =>
            await _mediator.Send(new ChangePhotoRequest(dto));

        [HttpGet("user")]
        public async Task<ActionResult<GetCurrentUserResponseDto>> GetCurrentUserAsync() =>
            await _mediator.Send(new GetCurrentUserRequest());

        [HttpGet("user/{id:int}")]
        public async Task<ActionResult<GetUserByIdResponseDto>> GetUserByIdAsync([FromRoute] int id) =>
            await _mediator.Send(new GetUserByIdRequest(id));

        [HttpPost("confirm/email"), AllowAnonymous]
        public async Task ConfirmEmailAsync([FromQuery] string email) => 
            await _mediator.Send(new ConfirmEmailRequest(email));

        [HttpPut("confirm/email/checking"), AllowAnonymous]
        public async Task<CheckEmailConfirmationResponseDto> CheckEmailConfirmationAsync(
            [FromQuery] string email,
            [FromQuery] int code) =>
            await _mediator.Send(new CheckEmailConfirmationRequest(email, code));
    }
}

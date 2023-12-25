using Disco.ApiServices.Controllers;
using Disco.ApiServices.Features.Account.User.RequestHandlers.Apple;
using Disco.ApiServices.Features.Account.User.RequestHandlers.Facebook;
using Disco.ApiServices.Features.Account.User.RequestHandlers.Google;
using Disco.ApiServices.Features.Account.User.RequestHandlers.LogIn;
using Disco.ApiServices.Features.Account.User.RequestHandlers.RefreshToken;
using Disco.ApiServices.Features.Account.User.RequestHandlers.Registration;
using Disco.Business.Interfaces.Dtos.Account.User.Apple;
using Disco.Business.Interfaces.Dtos.Account.User.Facebook;
using Disco.Business.Interfaces.Dtos.Account.User.Google;
using Disco.Business.Interfaces.Dtos.Account.User.LogIn;
using Disco.Business.Interfaces.Dtos.Account.User.RefreshToken;
using Disco.Business.Interfaces.Dtos.Account.User.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<ActionResult<LogInResponseDto>> LogInAsync([FromBody] LogInRequestDto dto) =>
            await _mediator.Send(new LogInRequest(dto));

        [HttpPost("log-in/facebook")]
        public async Task<ActionResult<FacebookResponseDto>> Facebook([FromBody] Business.Interfaces.Dtos.Account.User.Facebook.FacebookRequestDto dto) =>
            await _mediator.Send(new FacebookRequest(dto));


        [HttpPost("log-in/google")]
        public async Task<ActionResult<GoogleResponseDto>> Google([FromBody] Business.Interfaces.Dtos.Account.User.Google.GoogleLogInRequestDto dto) =>
            await _mediator.Send(new GoogleRequest(dto));

        [HttpPost("log-in/apple")]
        public async Task<ActionResult<AppleLogInResponseDto>> Apple([FromBody] AppleLogInRequestDto dto) =>
            await _mediator.Send(new AppleRequest(dto));

        [HttpPut("refresh")]
        public async Task<ActionResult<RefreshTokenResponseDto>> RefreshToken([FromBody] RefreshTokenRequestDto dto) =>
            await _mediator.Send(new RefreshTokenRequest(dto));

        [HttpPost("registration")]
        public async Task<ActionResult<RegisterResponseDto>> Registration([FromBody] RegisterRequestDto dto) => 
            await _mediator.Send(new RegistrationRequest(dto));
    }
}

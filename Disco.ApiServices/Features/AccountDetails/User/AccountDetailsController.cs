using Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.ChangePhoto;
using Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.GetCurrentUser;
using Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.GetUserById;
using Disco.Business.Constants;
using Disco.Business.Interfaces.Dtos.Account;
using Disco.Business.Interfaces.Dtos.AccountDetails;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
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
        public async Task<ActionResult<Domain.Models.Models.User>> ChangePhotoAsync([FromForm] UpdateAccountDto dto) =>
            await _mediator.Send(new ChangePhotoRequest(dto));

        [HttpGet("user")]
        public async Task<ActionResult<UserDetailsResponseDto>> GetCurrentUserAsync() =>
            await _mediator.Send(new GetCurrentUserRequest());

        [HttpGet("user/{id:int}")]
        public async Task<ActionResult<UserDetailsResponseDto>> GetUserByIdAsync([FromRoute] int id) =>
            await _mediator.Send(new GetUserByIdRequest(id));
    }
}

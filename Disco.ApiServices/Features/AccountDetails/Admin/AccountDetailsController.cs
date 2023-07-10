using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Dtos.Account;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Disco.Business.Interfaces.Validators;
using AutoMapper;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using MediatR;
using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.CreateAccount;
using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.DeleteAccount;
using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAllAccounts;
using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAccountsByPeriot;

namespace Disco.ApiServices.Features.AccountDetails.Admin
{

    [Route("api/admin/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<UserResponseDto>> Create([FromBody] RegistrationDto dto) =>
            await _mediator.Send(new CreateAccountRequest(dto));

        [HttpDelete("{id:int}")]
        public async Task Remove([FromRoute] int id) =>
            await _mediator.Send(new DeleteAccountRequest(id));

        [HttpGet]
        public async Task<IEnumerable<Domain.Models.Models.Account>> GetAllAsync(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize) =>
            await _mediator.Send(new GetAllAccountsRequest(pageNumber, pageSize));

        [HttpGet("periot")]
        public async Task<ActionResult<List<Domain.Models.Models.User>>> GetAccountsByPeriotAsync(int periot) =>
            await _mediator.Send(new GetAccountsByPeriotRequest(periot));
    }
}

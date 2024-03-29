﻿using Disco.ApiServices.Controllers;
using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.ChangeAccountEmail;
using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.ChangeAccountPhoto;
using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.CreateAccount;
using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.DeleteAccount;
using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAccount;
using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAccountsByPeriot;
using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAllAccounts;
using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.SearchAccounts;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.ChangeAccountEmail;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.ChangeAccountPhoto;
using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.SearchAccountEmails;
using Disco.Business.Interfaces.Dtos.Account.User.Register;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.CreateAccount;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.GetAccount;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.GetAccountsByPeriot;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.GetAllAccounts;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.SearchAccounts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAccountsCount;
using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAccountsSearchResultsCount;
using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.SearchAccountNames;
using Disco.Business.Interfaces.Dtos.AccountDetails.Admin.DeleteAccountPhoto;
using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.DeleteAccountPhoto;

namespace Disco.ApiServices.Features.AccountDetails.Admin
{

    [Route("api/admin/account")]
    public class AccountDetailsController : AdminController
    {
        private readonly IMediator _mediator;

        public AccountDetailsController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<CreateAccountResponseDto>> Create([FromBody] CreateAccountRequestDto dto) =>
            await _mediator.Send(new CreateAccountRequest(dto));

        [HttpDelete("{id:int}")]
        public async Task Remove([FromRoute] int id) =>
            await _mediator.Send(new DeleteAccountRequest(id));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetAccountResponseDto>> GetAccountAsync([FromRoute] int id) => 
            await _mediator.Send(new GetAccountRequest(id));

        [HttpGet]
        public async Task<IEnumerable<GetAllAccountsResponseDto>> GetAllAsync(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize) =>
            await _mediator.Send(new GetAllAccountsRequest(pageNumber, pageSize));

        [HttpGet("count")]
        public async Task<int> GetAccountsCount() =>
            await _mediator.Send(new GetAccountsCountRequest());

        [HttpGet("periot")]
        public async Task<ActionResult<List<GetAccountsByPeriotResponseDto>>> GetAccountsByPeriotAsync(int periot) =>
            await _mediator.Send(new GetAccountsByPeriotRequest(periot));

        [HttpGet("search")]
        public async Task<IEnumerable<SearchAccountsResponseDto>> SearchAsync(
           [FromQuery] string search,
           [FromQuery] int pageNumber,
           [FromQuery] int pageSize) =>
            await _mediator.Send(new SearchAccountsRequest(search, pageNumber, pageSize));

        [HttpGet("search/count")]
        public async Task<int> GetAccountsCountAsync(
            [FromQuery] string search) =>
            await _mediator.Send(new GetAccountsSearchResultsCountRequest(search));

        [HttpPut("change/photo")]
        public async Task<ActionResult<ChangeAccountPhotoResponseDto>> ChangePhotoAsync(
            [FromForm] int userId,
            [FromForm] IFormFile photo) =>
            await _mediator.Send(new ChangeAccountPhotoRequest(photo, userId));

        [HttpDelete("delete/photo/{id:int}")]
        public async Task<ActionResult<DeleteAccountPhotoResponseDto>> DeleteUserPhotoAsync([FromRoute] int id) => 
            await _mediator.Send(new DeleteAccountPhotoRequest(id));

        [HttpPut("change/email")]
        public async Task<ActionResult<ChangeAccountEmailResponseDto>> ChangeEmailAsync([FromBody] ChangeAccountEmailRequestDto dto) =>
            await _mediator.Send(new ChangeAccountEmailRequest(dto));

        [HttpGet("emails/search")]
        public async Task<IEnumerable<string>> GetEmailsBySearchAsync([FromQuery] string search) =>
            await _mediator.Send(new SearchAccountEmailsRequest(search));

        [HttpGet("names/search")]
        public async Task<IEnumerable<string>> GetNamesBySearchAsync(
            [FromQuery] string search) => 
            await _mediator.Send(new SearchAccountNamesRequest(search));
    }
}

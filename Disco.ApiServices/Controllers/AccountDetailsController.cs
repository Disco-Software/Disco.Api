using Disco.Business.Constants;
using Disco.Business.Dtos.Account;
using Disco.Business.Dtos.AccountDetails;
using Disco.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Controllers
{
    [ApiController]
    [Route("api/user/account/details")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    public class AccountDetailsController : Controller
    {
        private readonly IAccountDetailsService _accountDetailsService;
        private readonly IAccountService _accountService;
        public AccountDetailsController(
            IAccountDetailsService accountDetailsService,
            IAccountService accountService)
        {
            _accountDetailsService = accountDetailsService;
            _accountService = accountService;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] UpdateAccountDto dto)
        {
            var user = await _accountService.GetAsync(HttpContext.User);

            var account = await _accountDetailsService.ChengePhotoAsync(user, dto.Photo);

            return Ok(user);
        }

    }
}

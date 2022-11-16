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
    [Authorize(AuthenticationSchemes = AuthSchema.UserToken)]
    public class AccountDetailsController : Controller
    {
        private readonly IAccountDetailsService _accountDetailsService;
        private readonly IAccountService _accountService;
        private readonly IPostService _postService;
        public AccountDetailsController(
            IAccountDetailsService accountDetailsService,
            IAccountService accountService,
            IPostService postService)
        {
            _accountDetailsService = accountDetailsService;
            _accountService = accountService;
            _postService = postService;
        }

        [HttpPut("change/photo")]
        public async Task<IActionResult> Update([FromForm] UpdateAccountDto dto)
        {
            var user = await _accountService.GetAsync(HttpContext.User);

            var account = await _accountDetailsService.ChengePhotoAsync(user, dto.Photo);

            return Ok(user);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetCurrentUserAsync()
        {
           var user = await _accountService.GetAsync(HttpContext.User);
           user.Account.Posts = await _postService.GetAllUserPosts(user);

            return Ok(user);
        }

        [HttpGet("user/{id:int}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] int id)
        {
            var account = await _accountService.GetByIdAsync(id);

            return Ok(account);
        }
    }
}

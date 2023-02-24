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
        private readonly IFollowerService _followerService;

        public AccountDetailsController(
            IAccountDetailsService accountDetailsService,
            IAccountService accountService,
            IPostService postService,
            IFollowerService followerService)
        {
            _accountDetailsService = accountDetailsService;
            _accountService = accountService;
            _postService = postService;
            _followerService = followerService;
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
            user.Account.Following = await _followerService.GetFollowingAsync(user.Id);
            user.Account.Followers = await _followerService.GetFollowersAsync(user.Id);

            var accountDetails = await _accountDetailsService.GetUserDatailsAsync(user);

            return Ok(accountDetails);
        }

        [HttpGet("user/{id:int}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] int id)
        {
            var user = await _accountService.GetByIdAsync(id);
            user.Account.Posts = await _postService.GetAllUserPosts(user);
            user.Account.Followers = await _followerService.GetFollowersAsync(user.Id);
            user.Account.Following = await _followerService.GetFollowingAsync(user.Id);

            var userDetailsResponseDto = await _accountDetailsService.GetUserDatailsAsync(user);

            return Ok(userDetailsResponseDto);
        }
    }
}

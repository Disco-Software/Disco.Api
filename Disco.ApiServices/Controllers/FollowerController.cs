using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Dtos.Friends;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Disco.Business.Interfaces.Validators;
using Disco.Business.Interfaces.Dtos.Friends;
using Disco.Business.Interfaces.Interfaces;
using System.Collections.Generic;
using Disco.Domain.Models.Models;
using System;

namespace Disco.ApiServices.Controllers
{
    [Route("api/user/followers")]
    [Authorize(AuthenticationSchemes = AuthSchema.UserToken)]
    [ApiController]
    public class FollowerController : ControllerBase
    {
        private readonly IFollowerService _followerService;
        private readonly IAccountService _accountService;
        public FollowerController(
            IFollowerService followerService,
            IAccountService accountService)
        {
            _followerService = followerService;
            _accountService = accountService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateFollowerDto dto)
        {
            var user = await _accountService.GetAsync(HttpContext.User);
            var following = await _accountService.GetByIdAsync(dto.FollowingAccountId);

            var followerDto = await _followerService.CreateAsync(user, following, dto);

            return Ok(followerDto);
        }

        [HttpGet("{followerId:int}")]
        public async Task<IActionResult> GetFollowerAsync([FromRoute] int followerId)
        {
            var follower = await _followerService.GetAsync(followerId);

            return Ok(follower);
        }

        [HttpGet("followers")]
        public async Task<IActionResult> GetAllFollowersAsync([FromQuery] GetAllFollowersDto dto)
        {
            var followers = await _followerService.GetFollowersAsync(dto.UserId, dto.PageNumber, dto.PageSize);

            return Ok(followers);
        }

        [HttpGet("following")]
        public async Task<IActionResult> GetFollowingAsync([FromQuery] GetAllFollowersDto dto)
        {
            var following = await _followerService.GetFollowingAsync(dto.UserId, dto.PageNumber, dto.PageSize);

            return Ok(following);
        }

        [HttpGet("recomend")]
        public async Task<IActionResult> GetRecomendedAsync()
        {
            var user = await _accountService.GetAsync(HttpContext.User);
            var recomended = new List<Account>();

            foreach(var followings in user.Account.Following)
            {
                followings.FollowingAccount = await _accountService.GetByAccountIdAsync(followings.FollowingAccountId);

                foreach (var following in followings.FollowingAccount.Following)
                {
                    if(following.FollowingAccount.Following.Count == 0)
                    {
                        continue;
                    }

                    recomended.Add(following.FollowingAccount);
                }
            }

            return Ok(recomended);
        }

        [HttpDelete("{followerId:int}")]
        public async Task DeleteFollowerAsync([FromRoute] int followerId)
        {
            await _followerService.DeleteAsync(followerId);
        }
    }
}

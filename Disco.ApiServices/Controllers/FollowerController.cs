using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Friends;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.ApiServices.Controllers
{
    [Route("api/user/followers")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
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
            var friend = await _accountService.GetByIdAsync(dto.FriendId);

            var friendResponse = await _followerService.CreateAsync(user, friend, dto);

            return Ok(friendResponse);
        }

        [HttpGet("get/{friendId:int}")]
        public async Task<IActionResult> GetFriend([FromRoute] int friendId)
        {
            var friend = await _followerService.GetAsync(friendId);

            return Ok(friend);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllFriendsDto dto)
        {
            var friends = await _followerService.GetAllFollowers(dto);

            return Ok(friends);
        }

        [HttpDelete("{friendId:int}")]
        public async Task DeleteFriend([FromRoute] int friendId)
        {
            await _followerService.DeleteFriend(friendId);
        }
    }
}

using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Friends;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.ApiServices.Controllers
{
    [Route("api/user/friends")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;
        private readonly IAccountService _userService;
        public FriendController(
            IFriendService friendService,
            IAccountService userService)
        {
            _friendService = friendService;
            _userService = userService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateFriendDto model)
        {
            var user = await _userService.GetAsync(HttpContext.User);
            var friend = await _userService.GetByIdAsync(model.FriendId);

            var friendResponse = await _friendService.CreateFriendAsync(user, friend, model);

            return Ok(friendResponse);
        }

        [HttpGet("get/{friendId:int}")]
        public async Task<IActionResult> GetFriend([FromRoute] int friendId)
        {
            var friend = await _friendService.GetFriendAsync(friendId);

            return Ok(friend);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllFriendsDto dto)
        {
            var friends = await _friendService.GetAllFriends(dto);

            return Ok(friends);
        }

        [HttpDelete("{friendId:int}")]
        public async Task DeleteFriend([FromRoute] int friendId)
        {
            await _friendService.DeleteFriend(friendId);
        }
    }
}

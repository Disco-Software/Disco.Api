using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Friends;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.Presentation.Controllers
{
    [Route("api/user/friends")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;
        private readonly IUserService _userService;
        public FriendController(
            IFriendService friendService,
            IUserService userService)
        {
            _friendService = friendService;
            _userService = userService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateFriendDto model)
        {
            var user = await _userService.GetUserAsync(HttpContext.User);
            var friend = await _userService.GetUserByIdAsync(model.FriendId);

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

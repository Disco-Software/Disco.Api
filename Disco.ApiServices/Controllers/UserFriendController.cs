using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Dto.Friends;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.Api.Controllers
{
    [Route("api/user/friends")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    [ApiController]
    public class UserFriendController : ControllerBase
    {
        private readonly IFriendService friendService;

        public UserFriendController(IFriendService _friendService)
        {
            friendService = _friendService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateFriendDto model)
        {
            return await friendService.CreateFriendAsync(model);
        }

        [HttpGet("get/{friendId:int}")]
        public async Task<IActionResult> GetFriend([FromRoute] int friendId)
        {
            return await friendService.GetFriendAsync(friendId);
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetAll([FromRoute] int userId)
        {
            return await friendService.GetAllFriends(userId);
        }

        [HttpDelete("{friendId:int}")]
        public async Task DeleteFriend([FromRoute] int friendId)
        {
            await friendService.DeleteFriend(friendId);
        }
    }
}

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
            var following = await _accountService.GetByIdAsync(dto.FollowerAccountId);

            var followerDto = await _followerService.CreateAsync(user, following, dto);

            return Ok(followerDto);
        }

        [HttpGet("{followerId:int}")]
        public async Task<IActionResult> GetFollowerAsync([FromRoute] int followerId)
        {
            var follower = await _followerService.GetAsync(followerId);

            return Ok(follower);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllFollowersDto dto)
        {
            var followers = await _followerService.GetFollowersAsync(dto);

            return Ok(followers);
        }

        [HttpDelete("{followerId:int}")]
        public async Task DeleteFollowerAsync([FromRoute] int followerId)
        {
            await _followerService.DeleteAsync(followerId);
        }
    }
}

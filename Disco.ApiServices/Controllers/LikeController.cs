using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Controllers
{
    [Route("api/user/likes")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    public class LikeController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILikeService _likeService;

        public LikeController(
            IUserService userService, 
            ILikeService likeService)
        {
            _userService = userService;
            _likeService = likeService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateLikeAsync([FromQuery] int postId)
        {
            var user = await _userService.GetUserAsync(User);

            if (user == null)
            {
                return BadRequest();
            }

            var likes = await _likeService.AddLikeAsync(user, postId);

            return Ok(likes.Count);
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveLikeAsync([FromQuery] int postId)
        {
            var user = await _userService.GetUserAsync(User);

            if (user == null)
            {
                return BadRequest();
            }

            var likes = await _likeService.RemoveLikeAsync(user, postId);

            return Ok(likes.Count);
        }
    }
}

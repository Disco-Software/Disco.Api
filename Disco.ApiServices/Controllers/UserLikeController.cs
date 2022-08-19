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
    public class UserLikeController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILikeService _likeService;

        public UserLikeController(IUserService userService, ILikeService likeService)
        {
            _userService = userService;
            _likeService = likeService;
        }

        [HttpPost("toggle")]
        public async Task<IActionResult> ToggleLikeAsync([FromQuery] int postId)
        {
            var user = await _userService.GetUserAsync(User);

            if (user == null)
            {
                return BadRequest();
            }

            var likes = await _likeService.ToggleLikeAsync(user, postId);

            return Ok(likes);
        }
    }
}

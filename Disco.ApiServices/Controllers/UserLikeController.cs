using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Controllers
{
    [Route("api/user/like")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    public class UserLikeController : ControllerBase
    {
        private readonly ILikeSocketService _likeSocketService;
        private readonly ILikeService _likeService;
        private readonly IUserService _userService;

        public UserLikeController(
            ILikeSocketService likeSocketService, 
            ILikeService likeService, 
            IUserService userService)
        {
            _likeSocketService = likeSocketService;
            _likeService = likeService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Like([FromQuery] int postId)
        {
            var user = await _userService.GetUserAsync(HttpContext.User);
            user.RoleName = _userService.GetUserRole(user);

            var likes = await _likeService.CreateLikeAsync(user, postId);

            await _likeSocketService.AddLikeAsync(likes);

            return Ok(likes.Count);
        }
    }
}

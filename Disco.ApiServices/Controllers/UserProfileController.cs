using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.ApiServices.Controllers
{
    [Route("api/user/profile")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    public class UserProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly IUserService _userService;
        public UserProfileController(
            IProfileService profileService,
            IUserService userService)
        {
            _profileService = profileService;
            _userService = userService;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] UpdateProfileDto model)
        {
            var user = await _userService.GetUserAsync(HttpContext.User);

            var profile = await _profileService.UpdateProfileAsync(user, model);

            return Ok(user);
        }
    }
}

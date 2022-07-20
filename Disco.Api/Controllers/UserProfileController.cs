using Disco.Business.Constants;
using Disco.Business.Interfaces;
using Disco.Business.Dto.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.Api.Controllers
{
    [Route("api/user/profile")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    public class UserProfileController : ControllerBase
    {
        private readonly IProfileService profileService;

        public UserProfileController(IProfileService profileService)
        {
            profileService = profileService;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] UpdateProfileDto model)
        {
            return await profileService.UpdateProfileAsync(model);
        }
    }
}

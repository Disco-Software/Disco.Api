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
    [ApiController]
    [Route("api/user/account/details")]
    [Authorize(AuthenticationSchemes = AuthScheme.UserToken)]
    public class AccountDetailsController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IUserService _userService;
        public AccountDetailsController(
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

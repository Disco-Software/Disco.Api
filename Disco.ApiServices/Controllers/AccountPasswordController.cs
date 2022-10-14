using Disco.Business.Interfaces;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Controllers
{
    [ApiController]
    [Route("api/user/account/password")]
    public class AccountPasswordController : Controller
    {
       private readonly UserManager<User> _userManager;
       private readonly IAuthenticationService _authenticationService;
       private readonly IFacebookAuthService _facebookAuthService;
       private readonly IUserService _userService;

        public AccountPasswordController(
            UserManager<User> userManager,
            IAuthenticationService authenticationService,
            IFacebookAuthService facebookAuthService,
            IUserService userService)
        {
            _userManager = userManager;
            _authenticationService = authenticationService;
            _facebookAuthService = facebookAuthService;
            _userService = userService;
        }

        [HttpPost("forgot")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
        {
            var user = await _userService.GetUserByEmailAsync(model.Email);

            if (user == null)
                BadRequest("User is null");

            var confirmationDto = await _authenticationService.ForgotPassword(user);

            return Ok(confirmationDto);
        }

        [HttpPut("reset")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            var user = await _userService.GetUserByEmailAsync(model.Email);

            if (user == null)
                return BadRequest();

            var restPasswordDto = await _authenticationService.ResetPassword(user, model);

            return Ok(restPasswordDto);
        }
    }
}

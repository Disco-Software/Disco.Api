
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Disco.Domain.Models;
using Disco.ApiServices.Validators;
using Microsoft.AspNetCore.Cors;
using Disco.Business.Constants;
using Microsoft.AspNetCore.Authorization;

namespace Disco.ApiServices.Controllers.Admin
{
    [Route("api/admin/authentication")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IAdminAuthenticationService _adminAuthenticationService;
        private readonly IUserService _userService;
        public AuthenticationController(
            UserManager<User> userManager,
            IAdminAuthenticationService adminAuthenticationService, 
            IUserService userService)
        {
            _userManager = userManager;
            _adminAuthenticationService = adminAuthenticationService;
            _userService = userService;
        }

        [HttpPost("log-in")]
        public async Task<IActionResult> LogIn([FromForm] LoginDto model)
        {
            var validator = await LogInValidator
                .Create(_userManager)
                .ValidateAsync(model);

            if (!validator.IsValid)
            {
                return BadRequest(validator.Errors);
            }

            var user = await _userService.GetUserByEmailAsync(model.Email);
            await _userService.LoadUserInfoAsync(user);

            var passwordValidator = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
            if (passwordValidator == PasswordVerificationResult.Failed)
            {
                return BadRequest(passwordValidator);
            }

            var userResponse = await _adminAuthenticationService.LogIn(user, model);

            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            
            return Ok(userResponse);
        }

        [HttpPut("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto dto)
        {
            var user = await _userService.GetUserByRefreshTokenAsync(dto.RefreshToken);

            if (user == null)
                return BadRequest();

            var result = await _adminAuthenticationService.RefreshToken(dto);

            return Ok(result);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
        {
            var user = await _userService.GetUserByEmailAsync(model.Email);

            if (user == null)
                BadRequest("User is null");

            var confirmationDto = await _adminAuthenticationService.ForgotPassword(user, model);

            return Ok(confirmationDto);
        }

        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            var user = await _userService.GetUserByEmailAsync(model.Email);

            if (user == null)
                return BadRequest();

            var restPasswordDto = await _adminAuthenticationService.ResetPassword(user, model);

            return Ok(restPasswordDto);
        }
    }
}
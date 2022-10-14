using Disco.ApiServices.Validators;
using Disco.Business.Interfaces;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Controllers
{
    [ApiController]
    [Route("api/user/account")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly IFacebookAuthService _facebookAuthService;
        private readonly IUserService _userService;

        public AccountController(
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

        [HttpPost("log-in")]
        public async Task<IActionResult> LogIn([FromBody] LoginDto model)
        {
            var validator = await LogInValidator
                .Create(_userManager)
                .ValidateAsync(model);

            if (!validator.IsValid)
                return BadRequest(validator.Errors);

            var user = await _userService.GetUserByEmailAsync(model.Email);

            var passwordValidator = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
            if (passwordValidator == PasswordVerificationResult.Failed)
                return BadRequest(validator.Errors);

            var loginResponse = await _authenticationService.LogIn(user, model.Password);

            return Ok(loginResponse);
        }

        [HttpPost("log-in/facebook")]
        public async Task<IActionResult> Facebook([FromBody] FacebookRequestDto model)
        {
            var validator = await FacebookAccessTokenValidator
                .Create()
                .ValidateAsync(model);

            if (!validator.IsValid)
            {
                return BadRequest(validator.Errors);
            }

            var userInfo = await _facebookAuthService.GetUserInfo(model.AccessToken);

            var response = await _authenticationService.Facebook(userInfo);

            return Ok(response);
        }

        [HttpPost("log-in/google")]
        public async Task<IActionResult> Google([FromBody] GoogleLogInDto dto)
        {
            var user = await _authenticationService.Google(dto);

            return Ok(user);
        }

        [HttpPost("log-in/apple")]
        public async Task<IActionResult> Apple([FromBody] AppleLogInDto model)
        {
            var user = await _authenticationService.Apple(model);

            return Ok(user);
        }

        [HttpPut("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto model)
        {
            var user = await _userService.GetUserByRefreshTokenAsync(model.RefreshToken);

            if (user == null)
                return BadRequest();

            var result = await _authenticationService.RefreshToken(user, model);

            return Ok(result);
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationDto model)
        {
            var validator = await RegistrationValidator
                .Create(_userManager)
                .ValidateAsync(model);

            if (!validator.IsValid)
            {
                return BadRequest(validator.Errors);
            }

            var userResponseDto = await _authenticationService.Register(model);

            return Ok(userResponseDto);
        }
    }
}

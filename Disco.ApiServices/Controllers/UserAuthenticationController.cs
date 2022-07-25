using Disco.Business.Interfaces;
using Disco.Business.Dtos.Apple;
using Disco.Business.Dtos.Authentication;
using Disco.Business.Dtos.Facebook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Google.Apis.Auth.AspNetCore3;
using Google.Apis.PeopleService.v1;
using Disco.Business.Validators;
using Microsoft.AspNetCore.Identity;
using Disco.Domain.Models;

namespace Disco.ApiServices.Controllers
{
    [ApiController]
    [Route("api/user/authentication")]
    public class UserAuthenticationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly IFacebookAuthService _facebookAuthService;
        private readonly IUserService _userService;

        public UserAuthenticationController(
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

        /// <summary>
        /// User log in by email and password
        /// </summary>
        /// <param name="model">email and password</param>
        /// <returns>object: UserDto with user and varification result</returns>
        [HttpPost("log-in"), AllowAnonymous]
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

        [HttpPost("log-in/facebook"), AllowAnonymous]
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

        [HttpPost("log-in/google"), AllowAnonymous,
         GoogleScopedAuthorize(PeopleServiceService.ScopeConstants.UserinfoProfile)]
        public async Task<IActionResult> Google([FromServices] IGoogleAuthProvider googleAuthProvider)
        {
            return await _authenticationService.Google(googleAuthProvider);
        }

        [HttpPost("log-in/apple"), AllowAnonymous]
        public async Task<IActionResult> Apple([FromBody] AppleLogInDto model)
        {
            var user = await _authenticationService.Apple(model);

            return Ok(user);
        }

        [HttpPut("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto model)
        {
            var user = await _userService.GetUserByRefreshTokenAsync(model.RefreshToken);

            if(user == null) 
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

        [HttpPost("forgot-password"), AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
        {
            var user = await _userService.GetUserByEmailAsync(model.Email);

            if (user == null)
                BadRequest("User is null");

            var confirmationDto = await _authenticationService.ForgotPassword(user);

            return Ok(confirmationDto);
        }

        [HttpPut("reset-password")]
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

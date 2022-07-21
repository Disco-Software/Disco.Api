using Disco.Business.Interfaces;
using Disco.Business.Dtos.Apple;
using Disco.Business.Dtos.Authentication;
using Disco.Business.Dtos.Facebook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Google.Apis.Auth.AspNetCore3;
using Google.Apis.PeopleService.v1;

namespace Disco.ApiServices.Controllers
{
    [ApiController]
    [Route("api/user/authentication")]
    public class UserAuthenticationController : Controller
    {
        private readonly IAuthenticationService authenticationService;

        public UserAuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        /// <summary>
        /// User log in by email and password
        /// </summary>
        /// <param name="model">email and password</param>
        /// <returns>object: UserDto with user and varification result</returns>
        [HttpPost("log-in"), AllowAnonymous]
        public async Task<IActionResult> LogIn([FromBody] LoginDto model)
        {
            return await authenticationService.LogIn(model);
        }

        [HttpPost("log-in/facebook"), AllowAnonymous]
        public async Task<IActionResult> Facebook([FromBody] FacebookRequestDto model)
        {
            return await authenticationService.Facebook(model);
        }

        [HttpPost("log-in/google"), AllowAnonymous,
         GoogleScopedAuthorize(PeopleServiceService.ScopeConstants.UserinfoProfile)]
        public async Task<IActionResult> Google([FromServices] IGoogleAuthProvider googleAuthProvider)
        {
            return await authenticationService.Google(googleAuthProvider);
        }

        [HttpPost("log-in/apple"), AllowAnonymous]
        public async Task<IActionResult> Apple([FromBody] AppleLogInDto model)
        {
            return await authenticationService.Apple(model);
        }

        [HttpPut("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto model)
        {
            return await authenticationService.RefreshToken(model);
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationDto model)
        {
            return await authenticationService.Register(model);
        }

        [HttpPost("forgot-password"), AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
        {
            return await authenticationService.ForgotPassword(model.Email);
        }

        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            return await authenticationService.ResetPassword(model);
        }
    }
}

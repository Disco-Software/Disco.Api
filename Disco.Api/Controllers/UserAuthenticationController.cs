using Disco.BLL.DTO;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.BLL.Models.Apple;
using Disco.BLL.Models.Authentication;
using Disco.BLL.Models.Facebook;
using Disco.BLL.Models.Google;
using Disco.BLL.Services;
using Google.Apis.Auth.AspNetCore3;
using Google.Apis.PeopleService.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Api.Controllers
{
    [ApiController]
    [Route("api/user/authentication")]
    public class UserAuthenticationController : Controller
    {
        private readonly IServiceManager serviceManager;

        public UserAuthenticationController(IServiceManager _serviceManager) =>
            serviceManager = _serviceManager;

        /// <summary>
        /// User log in by email and password
        /// </summary>
        /// <param name="model">email and password</param>
        /// <returns>object: UserDto with user and varification result</returns>
        [HttpPost("log-in"), AllowAnonymous]
        public async Task<IActionResult> LogIn([FromBody] LoginModel model) =>
            await serviceManager.AuthentificationService.LogIn(model);

        [HttpPost("log-in/facebook"), AllowAnonymous]
        public async Task<IActionResult> Facebook([FromBody] FacebookRequestModel model) =>
            await serviceManager.AuthentificationService.Facebook(model);

        [HttpPost("log-in/google"), AllowAnonymous, GoogleScopedAuthorize(PeopleServiceService.ScopeConstants.UserinfoProfile)]
        public async Task<IActionResult> Google([FromServices] IGoogleAuthProvider googleAuthProvider) =>
            await serviceManager.AuthentificationService.Google(googleAuthProvider);

        [HttpPost("log-in/apple"), AllowAnonymous]
        public async Task<IActionResult> Apple([FromBody] AppleLogInModel model) =>
            await serviceManager.AuthentificationService.Apple(model);

        [HttpPut("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestModel model) =>
            await serviceManager.AuthentificationService.RefreshToken(model);

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationModel model) =>
            await serviceManager.AuthentificationService.Register(model);

        [HttpPost("forgot-password"), AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model) =>
            await serviceManager.AuthentificationService.ForgotPassword(model.Email);

        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestModel model) =>
            await serviceManager.AuthentificationService.ResetPassword(model);
    }
}

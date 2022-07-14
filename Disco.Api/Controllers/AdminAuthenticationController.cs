using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.BLL.Models.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.Api.Controllers
{
    [Route("api/admin/authentication")]
    [ApiController]
    public class AdminAuthenticationController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public AdminAuthenticationController(IServiceManager _serviceManager)
        {
            serviceManager = _serviceManager;
        }

        [HttpPost("log-in")]
        public async Task<IActionResult> LogIn([FromForm] LoginModel model) =>
            await serviceManager.AdminAuthenticationService.LogIn(model);

        [HttpPut("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestModel refreshTokenRequestModel) =>
            await serviceManager.AdminAuthenticationService.RefreshToken(refreshTokenRequestModel);

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model) =>
            await serviceManager.AdminAuthenticationService.ForgotPassword(model);

        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestModel model) =>
            await serviceManager.AdminAuthenticationService.ResetPassword(model);
    }
}

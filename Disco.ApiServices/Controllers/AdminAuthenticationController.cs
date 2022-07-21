using Disco.Business.Interfaces;
using Disco.Business.Dto.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.Api.Controllers
{
    [Route("api/admin/authentication")]
    [ApiController]
    public class AdminAuthenticationController : ControllerBase
    {
        private readonly IAdminAuthenticationService adminAuthenticationService;

        public AdminAuthenticationController(IAdminAuthenticationService _adminAuthenticationService)
        {
            adminAuthenticationService = _adminAuthenticationService;
        }

        [HttpPost("log-in")]
        public async Task<IActionResult> LogIn([FromForm] LoginDto model)
        {
            return await adminAuthenticationService.LogIn(model);
        }

        [HttpPut("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto refreshTokenRequestModel)
        {
            return await adminAuthenticationService.RefreshToken(refreshTokenRequestModel);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
        {
            return await adminAuthenticationService.ForgotPassword(model);
        }

        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            return await adminAuthenticationService.ResetPassword(model);
        }
    }
}

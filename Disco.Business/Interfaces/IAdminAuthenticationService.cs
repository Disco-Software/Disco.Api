using Disco.Business.Dtos.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IAdminAuthenticationService
    {
        public Task<IActionResult> LogIn(LoginDto model);
        public Task<IActionResult> RefreshToken(RefreshTokenDto model);
        public Task<IActionResult> ForgotPassword(Dtos.Authentication.ForgotPasswordDto model);
        public Task<IActionResult> ResetPassword(Dtos.Authentication.ResetPasswordDto model);
    }
}

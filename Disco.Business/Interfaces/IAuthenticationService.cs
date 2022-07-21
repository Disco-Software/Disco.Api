using Disco.Business.Dto.Apple;
using Disco.Business.Dto.Authentication;
using Disco.Business.Dto.Facebook;
using Google.Apis.Auth.AspNetCore3;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IActionResult> LogIn(LoginDto model);
        Task<IActionResult> Register(RegistrationDto model);
        Task<IActionResult> RefreshToken(RefreshTokenDto model);
        Task<IActionResult> Facebook(FacebookRequestDto facebookRequestModel);
        Task<IActionResult> Apple(AppleLogInDto model);
        Task<IActionResult> ForgotPassword(string email);
        Task<IActionResult> ResetPassword(ResetPasswordDto model);
        Task<IActionResult> Google(IGoogleAuthProvider googleAuthProvider);
    }
}

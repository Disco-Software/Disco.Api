using Disco.BLL.Dto;
using Disco.BLL.Dto;
using Disco.BLL.Dto.Apple;
using Disco.BLL.Dto.Authentication;
using Disco.BLL.Dto.Facebook;
using Disco.BLL.Dto.Google;
using Disco.DAL.Models;
using Google.Apis.Auth.AspNetCore3;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
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

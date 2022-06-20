using Disco.BLL.DTO;
using Disco.BLL.Models;
using Disco.BLL.Models.Apple;
using Disco.BLL.Models.Authentication;
using Disco.BLL.Models.Facebook;
using Disco.BLL.Models.Google;
using Disco.DAL.Entities;
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
        Task<IActionResult> LogIn(LoginModel model);
        Task<IActionResult> Register(RegistrationModel model);
        Task<IActionResult> RefreshToken(RefreshTokenRequestModel model);
        Task<IActionResult> Facebook(FacebookRequestModel facebookRequestModel);
        Task<IActionResult> Apple(AppleLogInModel model);
        Task<IActionResult> ForgotPassword(string email);
        Task<IActionResult> ResetPassword(ResetPasswordRequestModel model);
        Task<IActionResult> Google(IGoogleAuthProvider googleAuthProvider);
    }
}

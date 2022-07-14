using Disco.BLL.Models;
using Disco.BLL.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IAdminAuthenticationService
    {
        public Task<IActionResult> LogIn(LoginModel model);
        public Task<IActionResult> RefreshToken(RefreshTokenRequestModel model);
        public Task<IActionResult> ForgotPassword(Models.Authentication.ForgotPasswordModel model);
        public Task<IActionResult> ResetPassword(Models.Authentication.ResetPasswordRequestModel model);
    }
}

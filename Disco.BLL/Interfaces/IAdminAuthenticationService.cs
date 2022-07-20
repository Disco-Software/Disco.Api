using Disco.Business.Dto;
using Disco.Business.Dto.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IAdminAuthenticationService
    {
        public Task<IActionResult> LogIn(LoginDto model);
        public Task<IActionResult> RefreshToken(RefreshTokenDto model);
        public Task<IActionResult> ForgotPassword(Dto.Authentication.ForgotPasswordDto model);
        public Task<IActionResult> ResetPassword(Dto.Authentication.ResetPasswordDto model);
    }
}

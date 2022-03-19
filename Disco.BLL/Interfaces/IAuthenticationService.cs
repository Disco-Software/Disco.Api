using Disco.BLL.DTO;
using Disco.BLL.Models;
using Disco.BLL.Models.Apple;
using Disco.BLL.Models.Authentication;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UserResponseModel> LogIn(LoginModel model);
        Task<UserResponseModel> Register(RegistrationModel model);
        Task<UserResponseModel> RefreshToken();
        Task<UserResponseModel> Facebook(string accessToken);
        Task<UserResponseModel> Apple(AppleLogInModel model);
        Task<string> ForgotPassword(string email);
        Task<UserResponseModel> ResetPassword(ResetPasswordRequestModel model);
        public string GenerateJwtToken(User user);
    }
}

using Disco.Business.Dtos.Apple;
using Disco.Business.Dtos.Authentication;
using Disco.Business.Dtos.Facebook;
using Disco.Domain.Models;
using Google.Apis.Auth.AspNetCore3;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UserResponseDto> LogIn(User user, string password);
        Task<UserResponseDto> Register(RegistrationDto dto);
        Task<UserResponseDto> RefreshToken(User user, RefreshTokenDto model);
        Task<UserResponseDto> Facebook(FacebookDto dto);
        Task<UserResponseDto> Apple(AppleLogInDto model);
        Task<string> ForgotPassword(User user);
        Task<UserResponseDto> ResetPassword(User user, ResetPasswordDto model);
        Task<UserResponseDto> Google(IGoogleAuthProvider googleAuthProvider);
    }
}

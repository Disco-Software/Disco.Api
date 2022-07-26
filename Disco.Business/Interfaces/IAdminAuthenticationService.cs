using Disco.Business.Dtos.Authentication;
using Disco.Domain.Models;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IAdminAuthenticationService
    {
        public Task<UserResponseDto> LogIn(User user, LoginDto dto);
        public Task<UserResponseDto> RefreshToken(RefreshTokenDto dto);
        public Task<string> ForgotPassword(User user, ForgotPasswordDto dto);
        public Task<UserResponseDto> ResetPassword(User user, ResetPasswordDto dto);
    }
}

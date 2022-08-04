using Disco.Domain.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByEmailAsync(string email);
        Task LoadUserInfoAsync(User user);
        string GetUserRole(User user);
        Task<User> GetUserByRefreshTokenAsync(string refreshToken);
        Task SaveRefreshTokenAsync(User user, string refreshToken);
        Task<User> GetUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<User> GetUserByIdAsync(int id);
    }
}

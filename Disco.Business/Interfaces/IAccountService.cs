using Disco.Business.Dtos.Authentication;
using Disco.Domain.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IAccountService
    {
        Task CreateAsync(User user);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByRefreshTokenAsync(string refreshToken);
        Task SaveRefreshTokenAsync(User user, string refreshToken);
        Task<User> GetAsync(ClaimsPrincipal claimsPrincipal);
        Task<User> GetByIdAsync(int id);
        Task<User> GetByNameAsync(string name);
        Task<User> GetByLogInProviderAsync(string loginProvider, string providerKey);
        Task<IEnumerable<User>> GetAccountsByPeriotAsync(int periot);
        Task<bool> IsInRoleAsync(User user, string roleName);
    }
}

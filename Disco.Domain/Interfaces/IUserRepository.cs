using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByRefreshTokenAsync(string refreshToken);
        Task GetUserInfosAsync(User user);
        string GetUserRole(User user);
        Task SaveRefreshTokenAsync(User user, string refreshToken);
        Task<List<User>> GetAllUsers(int pageNumber, int pageSize);
    }
}

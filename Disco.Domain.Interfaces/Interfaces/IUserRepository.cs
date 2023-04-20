using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByRefreshTokenAsync(string refreshToken);
        string GetUserRole(User user);
        Task SaveRefreshTokenAsync(User user, string refreshToken);
        Task<List<User>> GetAllUsers(int pageNumber, int pageSize);
        Task<List<User>> GetUsersByPeriotAsync(DateTime date);

        Task<List<User>> GetUsersByPeriotIntAsync(int days);
        Task<List<User>> GetAllUsersAsync();
        Task<List<User>> GetAllUsersAsync(DateTime from, DateTime to);
    }
}

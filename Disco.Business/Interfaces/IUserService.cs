using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByEmailAsync(string email);
        string GetUserRole(User user);
        Task SaveRefreshTokenAsync(User user, string refreshToken);
    }
}

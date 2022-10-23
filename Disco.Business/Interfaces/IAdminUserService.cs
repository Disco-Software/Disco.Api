using Disco.Business.Dtos.Account;
using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IAdminUserService
    {
        Task<User> CreateUserAsync(RegistrationDto model);
        Task RemoveUserAsync(int id);
        Task<List<User>> GetAllUsers(int pageNumber, int pageSize);
    }
}

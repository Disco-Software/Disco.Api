using Disco.Domain.Models.Models;
using Microsoft.AspNetCore.Http;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IAccountDetailsService
    {
        Task<User> GetUserDatailsAsync(User user);
        Task<User> ChengePhotoAsync(User user, IFormFile formFile);
        Task<List<Account>> GetAccountsByNameAsync(string search);
        Task RemoveAsync(Account account);
        Task<IEnumerable<Account>> GetAllAsync(int pageNumber, int pageSize);
        Task<IEnumerable<Account>> SearchAsync(string search, int pageNumber, int pageSize);
    }
}

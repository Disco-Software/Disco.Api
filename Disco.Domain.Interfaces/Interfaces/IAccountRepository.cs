using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetAsync(int id);
        Task<Account> GetAccountAsync(int accountId);
        Task<List<Account>> GetAllWithRoleAsync(string roleName);
        Task<Account> UpdateAsync(Account newItem);
        Task<List<Account>> FindAccountsByUserNameAsync(string search);
        int GetAccountsSearchResultCount(string search);
        Task RemoveAccountAsync(Account account);
        Task<List<Connection>> GetAllAccountConnectionsAsync(int userId);
        Task<IEnumerable<Account>> GetAllAsync(int pageNumber, int pageSize);
        Task<IEnumerable<Account>> SearchAsync(string search, int pageNumber, int pageSize);
        int GetAccountsCount();
    }
}

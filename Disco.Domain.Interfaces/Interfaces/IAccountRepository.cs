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
        Task<Account> Update(Account newItem);
        Task<List<Account>> FindAccountsByUserNameAsync(string search);
        Task RemoveAccountAsync(int accountId);
        Task<List<Connection>> GetAllAccountConnectionsAsync(int userId);
        Task<IEnumerable<Account>> GetAllAsync(int pageNumber, int pageSize);
    }
}

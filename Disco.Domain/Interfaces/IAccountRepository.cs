using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetAsync(int id);
        Task<Account> Update(Account newItem);
        Task<List<Account>> FindAccountsByUserNameAsync(string search);
        Task RemoveAccountAsync(int accountId);
    }
}

using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task AddAsync(Account account);
        Task Remove(Account account);
        Task<Account> GetAsync(int id);
        IQueryable<Account> GetAll();
        Task Update(Account newItem);
    }
}

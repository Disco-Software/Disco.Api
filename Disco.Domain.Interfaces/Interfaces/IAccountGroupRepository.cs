using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces.Interfaces
{
    public interface IAccountGroupRepository
    {
        Task CreateAsync(AccountGroup accountGroup);
        Task DeleteAsync(AccountGroup accountGroup);
        Task<AccountGroup> GetAsync(int id);
        Task<IEnumerable<AccountGroup>> GetAllAsync(int id);
    }
}

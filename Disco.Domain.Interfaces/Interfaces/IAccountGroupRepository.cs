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
        Task AddAsync(AccountGroup accountGroup);
        Task Remove(AccountGroup accountGroup);
        Task<AccountGroup> GetAsync(int id);
        Task<List<AccountGroup>> GetAllAsync(int id);
    }
}

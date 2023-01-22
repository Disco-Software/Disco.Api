using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IAccountGroupService
    {
        Task<AccountGroup> CreateAsync(Account account, Group group);
        Task DeleteAsync(AccountGroup accountGroup);
        Task<AccountGroup> GetAsync(int id);
    }
}

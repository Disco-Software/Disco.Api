using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Group = Disco.Domain.Models.Models.Group;

namespace Disco.Domain.Interfaces.Interfaces
{
    public interface IGroupRepository
    {
        Task CreateAsync(Group group, CancellationToken cancellationToken = default);
        Task DeleteAsync(Group group, CancellationToken cancellationToken = default);
        Task<Group> GetAsync(int id);
        Task<List<Group>> GetAllAsync(int id, int pageNumber, int pageSize);
        Task LoadAccountsAsync(List<AccountGroup> accountGroup);
        Task UpdateAsync(Group group, CancellationToken cancellationToken = default);
    }
}

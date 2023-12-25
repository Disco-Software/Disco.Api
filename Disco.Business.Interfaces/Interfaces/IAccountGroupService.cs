using Disco.Domain.Models.Models;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IAccountGroupService
    {
        Task<AccountGroup> CreateAsync(Account account, Group group);
        Task DeleteAsync(AccountGroup accountGroup);
        Task<AccountGroup> GetAsync(int accountId, int groupId);
    }
}

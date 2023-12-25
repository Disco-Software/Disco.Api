using Disco.Domain.Models.Models;

namespace Disco.Domain.Interfaces.Interfaces
{
    public interface IAccountGroupRepository
    {
        Task CreateAsync(AccountGroup accountGroup);
        Task DeleteAsync(AccountGroup accountGroup);
        Task<AccountGroup> GetAsync(int id);
        Task<IEnumerable<AccountGroup>> GetAllAsync(int id);
        Task<AccountGroup> GetAsync(int groupId, int accountId);
    }
}

using Group = Disco.Domain.Models.Models.Group;

namespace Disco.Domain.Interfaces.Interfaces
{
    public interface IGroupRepository
    {
        Task CreateAsync(Group group, CancellationToken cancellationToken = default);
        Task DeleteAsync(Group group, CancellationToken cancellationToken = default);
        Task<Group> GetAsync(int id);
        Task<List<Group>> GetAllAsync(int id, int pageNumber, int pageSize);
        Task UpdateAsync(Group group, CancellationToken cancellationToken = default);
    }
}

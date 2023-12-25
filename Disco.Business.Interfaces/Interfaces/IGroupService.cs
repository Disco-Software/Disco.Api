using Group = Disco.Domain.Models.Models.Group;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IGroupService
    {
        Task<Group> CreateAsync();
        Task DeleteAsync(Group group);
        Task<IEnumerable<Group>> GetAllAsync(int id, int pageNumber, int pageSize);
        Task<Group> GetAsync(int id);
        Task<Group> UpdateAsync(Group group);
    }
}

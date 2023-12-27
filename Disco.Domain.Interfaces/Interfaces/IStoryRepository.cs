using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IStoryRepository
    {
        Task AddAsync(Story story);
        Task<IEnumerable<Story>> GetAllAsync(int accountId, int pageNumber, int pageSize);
        Task RemoveAsync(Story story);
        Task<Story> GetAsync(int id);
        int GetStoriesCount(int accountCount);
    }
}

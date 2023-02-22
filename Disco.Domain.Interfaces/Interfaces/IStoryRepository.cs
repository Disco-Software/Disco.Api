using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IStoryRepository
    {
        Task AddAsync(Story story);
        Task<List<Story>> GetAllAsync(int profileId, int pageNumber, int pageSize);
        Task Remove(Story item);
        Task<Story> GetAsync(int id);
    }
}

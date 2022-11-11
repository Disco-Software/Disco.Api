using Disco.Business.Dtos.Stories;
using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IStoryService
    {
        Task CreateStoryAsync(Story story);
        Task DeleteStoryAsync(int id);
        Task<Story> GetStoryAsync(int id);
        Task<List<Story>> GetAllStoryAsync(User user, GetAllStoriesDto model);
    }
}

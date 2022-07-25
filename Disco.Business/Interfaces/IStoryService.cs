using Disco.Business.Dtos.Stories;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IStoryService
    {
        Task<Story> CreateStoryAsync(User user, CreateStoryDto model);
        Task DeleteStoryAsync(int id);
        Task<Story> GetStoryAsync(int id);
        Task<List<Story>> GetAllStoryAsync(User user, GetAllStoriesDto model);
    }
}

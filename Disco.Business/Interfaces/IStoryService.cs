using Disco.Business.Dto.Stories;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IStoryService
    {
        Task<IActionResult> CreateStoryAsync(CreateStoryDto model);
        Task DeleteStoryAsync(int id);
        Task<ActionResult<Story>> GetStoryAsync(int id);
        Task<ActionResult<List<Story>>> GetAllStoryAsync(GetAllStoriesDto model);
    }
}

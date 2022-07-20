using Disco.BLL.Dto.Stories;
using Disco.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IStoryService
    {
        Task<IActionResult> CreateStoryAsync(CreateStoryDto model);
        Task DeleteStoryAsync(int id);
        Task<ActionResult<Story>> GetStoryAsync(int id);
        Task<ActionResult<List<Story>>> GetAllStoryAsync(GetAllStoriesDto model);
    }
}

using Disco.BLL.Models.Stories;
using Disco.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IStoryService
    {
        Task<IActionResult> CreateStoryAsync(CreateStoryModel model);
        Task DeleteStoryAsync(int id);
        Task<ActionResult<Story>> GetStoryAsync(int id);
        Task<ActionResult<List<Story>>> GetAllStoryAsync(int profileId);
    }
}

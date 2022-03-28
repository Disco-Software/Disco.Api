using Disco.BLL.Models.Stories;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IStoryService
    {
        Task<Story> CreateStoryAsync(CreateStoryModel model);
        Task DeleteStoryAsync(int id);
        Task<Story> GetStoryAsync(int id);
        Task<List<Story>> GetAllStoryAsync(int profileId);
    }
}

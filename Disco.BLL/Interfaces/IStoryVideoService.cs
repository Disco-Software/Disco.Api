using Disco.BLL.Models.StoryVideos;
using Disco.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IStoryVideoService
    {
        Task<StoryVideo> CreateStoryVideoAsync(CreateStoryVideoModel model);
        Task Remove(int id);
    }
}

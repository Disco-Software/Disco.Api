using Disco.Business.Dto.StoryVideos;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IStoryVideoService
    {
        Task<StoryVideo> CreateStoryVideoAsync(CreateStoryVideoDto model);
        Task Remove(int id);
    }
}

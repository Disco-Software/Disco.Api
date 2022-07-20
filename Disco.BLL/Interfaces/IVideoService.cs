using Disco.Business.Dto.Videos;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IVideoService
    {
        Task<PostVideo> CreateVideoAsync(CreateVideoDto model);
        Task RemoveVideoAsync(int id);
    }
}

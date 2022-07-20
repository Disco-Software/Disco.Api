using Disco.BLL.Dto.Videos;
using Disco.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Interfaces
{
    public interface IVideoService
    {
        Task<PostVideo> CreateVideoAsync(CreateVideoDto model);
        Task RemoveVideoAsync(int id);
    }
}

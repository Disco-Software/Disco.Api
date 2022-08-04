using Disco.Business.Dtos.Videos;
using Disco.Domain.Models;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface IVideoService
    {
        Task<PostVideo> CreateVideoAsync(CreateVideoDto model);
        Task RemoveVideoAsync(int id);
    }
}

using Disco.Business.Interfaces.Dtos.Videos;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Interfaces
{
    public interface IVideoService
    {
        Task<PostVideo> CreateVideoAsync(CreateVideoDto model);
        Task RemoveVideoAsync(int id);
    }
}

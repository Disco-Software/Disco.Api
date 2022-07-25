using Disco.Domain.Models;
using System.Threading.Tasks;

namespace Disco.Domain.Interfaces
{
    public interface IImageRepository
    {
        Task AddAsync(PostImage item);
        Task Remove(int id);
    }
}

using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface ILikeService
    {
        public Task<List<Like>> ToggleLikeAsync(User user, int postId);
    }
}

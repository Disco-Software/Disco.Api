using Disco.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface ILikeService
    {
        public Task<List<Like>> CreateLikeAsync(User user, int postId);

        public Task<List<Like>> RemoveLikeAsync(User user, int likeId);
    }
}

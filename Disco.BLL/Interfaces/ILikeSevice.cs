using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces
{
    public interface ILikeSevice
    {
        public Task<List<Like>> CreateLikeAsync(int postId);

        public Task<List<Like>> RemoveLikeAsync(int likeId);
    }
}

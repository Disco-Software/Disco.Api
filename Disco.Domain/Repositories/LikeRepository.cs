using System;
using Disco.Domain.Models;
using Disco.Domain.EF;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Disco.Domain.Interfaces;
using Disco.Domain.Repositories.Base;

namespace Disco.Domain.Repositories
{
    public class LikeRepository : BaseRepository<Like, int>, ILikeRepository
    {
        public LikeRepository(ApiDbContext ctx) : base(ctx) { }

        public async Task AddAsync(Like item, int postId)
        {
            var post = await _ctx.Posts
                .Include(x => x.Likes)
                .Where(p => p.Id == postId)
                .FirstOrDefaultAsync();

            if (post == null)
                throw new Exception("post not found");

            post.Likes.Add(item);
            await _ctx.Like.AddAsync(item);

            await _ctx.SaveChangesAsync();
        }

        public override async Task Remove(int id)
        {
            var like = await _ctx.Like
                .Where(l => l.Id == id)
                .FirstOrDefaultAsync();

            _ctx.Remove(like);
            like.Post.Likes.Remove(like);

            await _ctx.SaveChangesAsync();
        }
    }
}

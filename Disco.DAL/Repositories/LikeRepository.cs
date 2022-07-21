using System;
using System.Collections.Generic;
using System.Text;
using Disco.Domain.Models;
using Disco.Domain.EF;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Disco.Domain.Interfaces;

namespace Disco.Domain.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ApiDbContext ctx;
        public LikeRepository(ApiDbContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task AddAsync(Like item, int postId)
        {
            var post = await ctx.Posts
                .Include(x => x.Likes)
                .Where(p => p.Id == postId)
                .FirstOrDefaultAsync();

            if (post == null)
                throw new Exception("post not found");

            post.Likes.Add(item);
            await ctx.Like.AddAsync(item);

            await ctx.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var like = await ctx.Like
                .Where(l => l.Id == id)
                .FirstOrDefaultAsync();

            ctx.Remove(like);
            like.Post.Likes.Remove(like);

            await ctx.SaveChangesAsync();
        }
    }
}

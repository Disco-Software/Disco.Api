using System;
using Disco.Domain.Models;
using Disco.Domain.EF;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Disco.Domain.Interfaces;
using Disco.Domain.Repositories.Base;
using System.Collections.Generic;

namespace Disco.Domain.Repositories
{
    public class LikeRepository : BaseRepository<Like, int>, ILikeRepository
    {
        public LikeRepository(ApiDbContext ctx) : base(ctx) { }

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

        public async Task Remove(Like like,int id)
        {
            var post = await ctx.Posts
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            ctx.Like.Remove(like);
            post.Likes.Remove(like);

            await ctx.SaveChangesAsync();
        }

        public async Task<List<Like>> GetAll(int postId)
        {
            return await ctx.Like
                .Include(p => p.Post)
                .Where(l => l.PostId == postId)
                .ToListAsync();
        }

        public async Task<Like> GetAsync(string userName)
        {
            return await ctx.Like
                .Where(l => l.UserName == userName)
                .FirstOrDefaultAsync();
        }
    }
}

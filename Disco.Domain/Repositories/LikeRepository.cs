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

        public override async Task AddAsync(Like item)
        {            
            await _ctx.Like.AddAsync(item);

            await _ctx.SaveChangesAsync();
        }

        public async Task Remove(Like like,int id)
        {
            var post = await _ctx.Posts
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            _ctx.Like.Remove(like);
            post.Likes.Remove(like);

            await _ctx.SaveChangesAsync();
        }

        public async Task<List<Like>> GetAll(int postId)
        {
            return await _ctx.Like
                .Include(p => p.Post)
                .Where(l => l.PostId == postId)
                .ToListAsync();
        }

        public async Task<Like> GetAsync(int postId)
        {
            return await _ctx.Like
                .Include(p => p.Post)
                .Where(l => l.Post.Id == postId)
                .FirstOrDefaultAsync();
        }
    }
}

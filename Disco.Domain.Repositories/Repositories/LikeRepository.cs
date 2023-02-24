using System;
using Disco.Domain.Models;
using Disco.Domain.EF;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Disco.Domain.Interfaces;
using System.Collections.Generic;
using Disco.Domain.Repositories.Repositories.Base;
using Disco.Domain.Models.Models;

namespace Disco.Domain.Repositories.Repositories
{
    public class LikeRepository : BaseRepository<Like, int>, ILikeRepository
    {
        public LikeRepository(ApiDbContext ctx) : base(ctx) { }

        public override async Task AddAsync(Like item)
        {            
            await _ctx.Likes.AddAsync(item);

            await _ctx.SaveChangesAsync();
        }

        public async Task Remove(Like like,int id)
        {
            var post = await _ctx.Posts
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            _ctx.Likes.Remove(like);
            post.Likes.Remove(like);

            await _ctx.SaveChangesAsync();
        }

        public async Task<List<Like>> GetAll(int postId)
        {
            return await _ctx.Likes
                .Include(p => p.Post)
                .Where(l => l.PostId == postId)
                .ToListAsync();
        }
        public async Task<List<Like>> GetAll(int postId, int pageNumber, int pageSize)
        {
            return await _ctx.Likes
                .Include(p => p.Post)
                .Where(l => l.PostId == postId)
                .OrderBy(l => l.Account.User.UserName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Like> GetAsync(int postId)
        {
            return await _ctx.Likes
                .Include(p => p.Post)
                .Where(l => l.Post.Id == postId)
                .FirstOrDefaultAsync();
        }
    }
}

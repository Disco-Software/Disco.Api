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

        public async Task<List<Like>> GetAllAsync(int postId, int pageNumber, int pageSize)
        {
            return await _context.Likes
                .Include(p => p.Post)
                .Where(l => l.PostId == postId)
                .OrderBy(l => l.Account.User.UserName)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Like> GetAsync(int accountId, int postId)
        {
            return await _context.Likes
                .Include(p => p.Post)
                .Where(x => x.PostId == postId)
                .Where(l => l.AccountId == accountId)
                .FirstOrDefaultAsync() ?? throw new NullReferenceException();
        }
    }
}

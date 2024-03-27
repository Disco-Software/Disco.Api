using Disco.Domain.EF;
using Disco.Domain.Interfaces.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Disco.Domain.Repositories.Repositories
{
    public class CommentRepository : BaseRepository<Comment,int>, ICommentRepository
    {
        public CommentRepository(ApiDbContext ctx) : base(ctx) { }

        public async Task<List<Comment>> GetAllAsync(int postId, int pageNumber, int pageSize)
        {
            var comments = await _context.Comments
                .Where(x => x.PostId == postId)
                .OrderByDescending(x => x.PostId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return comments;
        }
    }
}

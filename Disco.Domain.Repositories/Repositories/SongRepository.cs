using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories.Repositories
{
    public class SongRepository : BaseRepository<PostSong, int>, ISongRepository
    {
        public SongRepository(ApiDbContext ctx) : base(ctx) { }

        public override async Task AddAsync(PostSong song)
        {
            await _context.PostSongs.AddAsync(song);
        }

        public async Task RemoveAsync(PostSong song)
        {
            _context.PostSongs.Remove(song);

            await _context.SaveChangesAsync();
        }

        public override async Task<PostSong> GetAsync(int id)
        {
            return await _context.PostSongs
                .Include(p => p.Post)
                .Where(s => s.PostId == id)
                .FirstOrDefaultAsync() ?? throw new NullReferenceException();

        }
    }
}

using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly ApiDbContext ctx;

        public SongRepository(ApiDbContext _ctx) 
        {
            ctx = _ctx;
        }

        public async Task AddAsync(PostSong song)
        {
            await ctx.PostSongs.AddAsync(song);
        }

        public async Task Remove(int id)
        {
            var song = await ctx.PostSongs
                .Include(p => p.Post)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

            song.Post.PostSongs.Remove(song);
            ctx.PostSongs.Remove(song);

            await ctx.SaveChangesAsync();
        }
    }
}

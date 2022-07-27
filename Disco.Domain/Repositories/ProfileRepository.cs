
using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class ProfileRepository : BaseRepository<Profile, int>, IProfileRepository
    {
        public ProfileRepository(ApiDbContext ctx) : base(ctx) { }

        public async Task<Profile> GetAsync(int id)
        {
           return await ctx.Profiles
                  .Include(u => u.User)
                  .Where(p => p.Id == id)
                  .FirstOrDefaultAsync();
        }

        public override async Task<Profile> Update(Profile newItem)
        {
            var profile = ctx.Profiles.Update(newItem).Entity;
            
            await ctx.SaveChangesAsync();
            
            return profile;
        }

    }
}

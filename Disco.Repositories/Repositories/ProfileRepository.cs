
using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ApiDbContext ctx;

        public ProfileRepository(ApiDbContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task<Profile> GetAsync(int id)
        {
           return await ctx.Profiles
                  .Include(u => u.User)
                  .Where(p => p.Id == id)
                  .FirstOrDefaultAsync();
        }

        public async Task<Profile> Update(Profile newItem)
        {
            var profile = ctx.Profiles.Update(newItem).Entity;
            
            await ctx.SaveChangesAsync();
            
            return profile;
        }

    }
}


using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class ProfileRepository : BaseRepository<Account, int>, IAccountRepository
    {
        public ProfileRepository(ApiDbContext ctx) : base(ctx) { }

        public async Task<Account> GetAsync(int id)
        {
           return await ctx.Profiles
                  .Include(u => u.User)
                  .Where(p => p.Id == id)
                  .FirstOrDefaultAsync();
        }

        public override async Task<Account> Update(Account newItem)
        {
            var profile = ctx.Profiles.Update(newItem).Entity;
            
            await ctx.SaveChangesAsync();
            
            return profile;
        }

        public async Task<List<Account>> FindProfleByUserNameAsync(string search)
        {
            return await ctx.Profiles
                .Include(u => u.User)
                .Where(u => u.User.UserName.Contains(search))
                .ToListAsync();
        }
    }
}

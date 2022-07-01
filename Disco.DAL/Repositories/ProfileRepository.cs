
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.DAL.Repositories
{
    public class ProfileRepository : Base.BaseRepository<Profile,int>
    {
        public ProfileRepository(ApiDbContext _ctx) : base(_ctx) { }

        public override async Task<Profile> Get(int id) =>
              await ctx.Profiles
                    .Include(u => u.User)
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();

        public async override Task<Profile> Update(Profile newItem)
        {
            var profile = ctx.Profiles.Update(newItem).Entity;
            
            await ctx.SaveChangesAsync();
            
            return profile;
        }

    }
}

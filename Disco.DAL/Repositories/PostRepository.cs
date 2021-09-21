using Disco.DAL.EF;
using Disco.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Disco.DAL.Repositories
{
    public class PostRepository : Base.BaseRepository<Post, int>
    {
        private readonly ClaimsPrincipal claimsPrincipal;
        private readonly UserManager<User> userManager;

        public PostRepository(ApiDbContext _ctx) : base(_ctx) { }

        public PostRepository(ApiDbContext _ctx, ClaimsPrincipal _claimsPrincipal, UserManager<User> _userManager) : base(_ctx)
        {
            ctx = _ctx;
            claimsPrincipal = _claimsPrincipal;
            userManager = _userManager;
        }

        public async Task<Post> Add(Post post, User user)
        {
            await ctx.Posts
                .AddAsync(post);
            user.Posts.Add(post);
            await ctx.SaveChangesAsync();
            return post;
        }

        public async override Task Remove(int id)
        {
            var post = await ctx.Posts
                .Include(v => v.Video)
                .Include(s => s.Song)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            ctx.Remove(post);
        }
    }
}

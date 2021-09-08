using Disco.DAL.EF;
using Disco.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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

        public async Task Add(Post post, User user)
        {
            user.Posts.Add(post);
            await ctx.SaveChangesAsync();
        }
    }
}

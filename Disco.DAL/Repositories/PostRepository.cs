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
        private readonly UserManager<User> userManager;

        public PostRepository(ApiDbContext _ctx) : base(_ctx) { }

        public PostRepository(ApiDbContext _ctx, UserManager<User> _userManager) : base(_ctx)
        {
            ctx = _ctx;
            userManager = _userManager;
        }

        public async Task<Post> AddAsync(Post post, User user)
        {
            if(user == null)
                throw new ArgumentNullException("user");
            
            await ctx.Posts.AddAsync(post);
            user.Profile.Posts.Add(post);
            await ctx.SaveChangesAsync();

            return post;
        }

        public async override Task Remove(int id)
        {
            var post = await ctx.Posts
                .Include(v => v.PostVideos)
                .Include(s => s.PostSongs)
                .Include(i => i.PostImages)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            ctx.Remove(post);
        }
    }
}

using Disco.DAL.EF;
using Disco.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

            post.Profile.Posts.Remove(post);

            ctx.Remove(post);

            await ctx.SaveChangesAsync();
        }

        public async Task<List<Post>> GetAll(int userId)
        {
            var posts = new List<Post>();

            var user = await ctx.Users
                .Include(p => p.Profile)
                .ThenInclude(f => f.Friends)
                .Include(p => p.Profile)
                .ThenInclude(p => p.Posts)
                .ThenInclude(p => p.PostImages)
                .Include(p => p.Profile)
                .ThenInclude(p => p.Posts)
                .ThenInclude(s => s.PostSongs)
                .Include(p => p.Profile)
                .ThenInclude(p => p.Posts)
                .ThenInclude(p => p.PostVideos)
                .Where(s => s.Id == userId)
                .FirstOrDefaultAsync();

            posts.AddRange(user.Profile.Posts);

            foreach (var friend in user.Profile.Friends)
            {
                friend.ProfileFriend = await ctx.Profiles
                    .Include(p => p.Posts)
                    .ThenInclude(i => i.PostImages)
                    .Include(p => p.Posts)
                    .ThenInclude(s => s.PostSongs)
                    .Include(p => p.Posts)
                    .ThenInclude(v => v.PostVideos)
                    .Include(u => u.User)
                    .Where(f => f.Id == friend.FriendProfileId)
                    .FirstOrDefaultAsync();
                posts.AddRange(friend.ProfileFriend.Posts);             
            }

            posts.OrderByDescending(d => d.DateOfCreation).ToList();

            return posts;
        }

        public override Task<List<Post>> GetAll(Expression<Func<Post, bool>> expression)
        {
            if (expression != null)
               return ctx.Posts
                    .Include(i => i.PostImages)
                    .Include(s => s.PostSongs)
                    .Include(v => v.PostVideos)
                    .OrderByDescending(d => d.DateOfCreation)
                    .Where(expression)
                    .ToListAsync();

            return ctx.Posts.ToListAsync();
        }

        public override Task<Post> Get(int id)
        {
           return ctx.Posts
                .Include(i => i.PostImages)
                .Include(s => s.PostSongs)
                .Include(v => v.PostVideos)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}

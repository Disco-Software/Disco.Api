using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApiDbContext ctx;

        public PostRepository(
            ApiDbContext _ctx)
        {
            ctx = _ctx;
        }

        public async Task AddAsync(Post post, User user)
        {
            if(user == null)
                throw new ArgumentNullException("user is null");
            
            await ctx.Posts.AddAsync(post);
            user.Profile.Posts.Add(post);
            
            await ctx.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var post = await ctx.Posts
                .Include(p => p.Profile)
                .Include(v => v.PostVideos)
                .Include(s => s.PostSongs)
                .Include(i => i.PostImages)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            post.Profile.Posts.Remove(post);

            ctx.Remove(post);

            await ctx.SaveChangesAsync();
        }

        public async Task<List<Post>> GetAllPosts(int userId, int pageSize, int pageNumber)
        {
            var posts = new List<Post>();

            var user = await ctx.Users
                .Include(p => p.Profile)
                .ThenInclude(f => f.Followers)
                .Include(p => p.Profile)
                .ThenInclude(p => p.Following)
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

            foreach (var friend in user.Profile.Following)
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

            foreach (var friend in user.Profile.Followers)
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

            return posts
                .OrderByDescending(d => d.DateOfCreation)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public async Task<List<Post>> GetAllUserPosts(int userId, int pageSize, int pageNumber)
        {
            var user = await ctx.Users
                .Include(p => p.Profile)
                .ThenInclude(p => p.Posts)
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

           return user.Profile.Posts
                .OrderByDescending(d => d.DateOfCreation)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Task<Post> Get(int id)
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

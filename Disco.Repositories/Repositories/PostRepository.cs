using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories
{
    public class PostRepository : BaseRepository<Post,int>, IPostRepository
    {
        public PostRepository(ApiDbContext ctx) : base(ctx) { }

        public async Task AddAsync(Post post, User user)
        {
            if(user == null)
                throw new ArgumentNullException("user is null");
            
            await _ctx.Posts.AddAsync(post);
            user.Profile.Posts.Add(post);
            
            await _ctx.SaveChangesAsync();
        }

        public override async Task Remove(int id)
        {
            var post = await _ctx.Posts
                .Include(p => p.Profile)
                .Include(v => v.PostVideos)
                .Include(s => s.PostSongs)
                .Include(i => i.PostImages)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            post.Profile.Posts.Remove(post);

            _ctx.Remove(post);

            await _ctx.SaveChangesAsync();
        }

        public async Task<List<Post>> GetAllPosts(int userId, int pageSize, int pageNumber)
        {
            var posts = new List<Post>();

            var user = await _ctx.Users
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
                friend.ProfileFriend = await _ctx.Profiles
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
                friend.ProfileFriend = await _ctx.Profiles
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
            var user = await _ctx.Users
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

        public override Task<Post> Get(int id)
        {
           return _ctx.Posts
                .Include(i => i.PostImages)
                .Include(s => s.PostSongs)
                .Include(v => v.PostVideos)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}

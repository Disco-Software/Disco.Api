using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            user.Account.Posts.Add(post);
            
            await _ctx.SaveChangesAsync();
        }

        public override async Task Remove(int id)
        {
            var post = await _ctx.Posts
                .Include(p => p.Account)
                .Include(v => v.PostVideos)
                .Include(s => s.PostSongs)
                .Include(i => i.PostImages)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            post.Account.Posts.Remove(post);

            _ctx.Remove(post);

            await _ctx.SaveChangesAsync();
        }

        //public async Task<List<Post>> GetUserPostsAsync(int userId, int pageSize, int pageNumber)

        public override Task<Post> GetAsync(int id)
        {
           return _ctx.Posts
                .Include(p => p.Likes)
                .Include(i => i.PostImages)
                .Include(s => s.PostSongs)
                .Include(v => v.PostVideos)
                .Include(p => p.Account)
                .ThenInclude(u => u.User)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Post>> GetPostsByDescriptionAsync(string search)
        {
            return await _ctx.Posts
                .Include(p => p.PostImages)
                .Include(p => p.PostVideos)
                .Include(p => p.PostSongs)
                .Where(p => p.Description.StartsWith(search))
                .ToListAsync();
        }

        public async Task<List<Post>> GetUserPostsAsync(int userId)
        {
            return await _ctx.Posts
                .Include(p => p.Likes)
                .Include(p => p.PostImages)
                .Include(p => p.PostSongs)
                .Include(p => p.PostVideos)
                .Include(p => p.Likes)
                .Include(p => p.Account)
                .ThenInclude(a => a.User)
                .Where(p => p.Account.UserId == userId)
                .ToListAsync();

        }

        public async Task<List<Post>> GetFollowersPostsAsync(List<UserFollower> followers)
        {
            var posts = new List<Post>();
            
            foreach (var follower in followers)
            {
                var account = await _ctx.Accounts
                    .Include(a => a.Posts)
                    .ThenInclude(p => p.PostImages)
                    .Include(a => a.Posts)
                    .ThenInclude(p => p.PostSongs)
                    .Include(p => p.Posts)
                    .ThenInclude(a => a.PostVideos)
                    .Include(p => p.Posts)
                    .ThenInclude(l => l.Likes)
                    .Where(a => a.Id == follower.FollowerAccountId)
                    .FirstOrDefaultAsync();
                
                posts.AddRange(account.Posts);
            }

            return posts;
        }

        public async Task<List<Post>> GetFollowingPostsAsync(List<UserFollower> followings)
        {
            var posts = new List<Post>();

            foreach (var following in followings)
            {
                var account = await _ctx.Accounts
                    .Include(a => a.Posts)
                    .ThenInclude(p => p.PostImages)
                    .Include(a => a.Posts)
                    .ThenInclude(p => p.PostSongs)
                    .Include(p => p.Posts)
                    .ThenInclude(a => a.PostVideos)
                    .Include(p => p.Posts)
                    .ThenInclude(l => l.Likes)
                    .Include(p => p.Posts)
                    .ThenInclude(p => p.Account)
                    .ThenInclude(a => a.User)
                    .Where(a => a.Id == following.FollowingAccountId)
                    .FirstOrDefaultAsync();

                posts.AddRange(account.Posts);
            }

            return posts;
        }

        public Task<List<Post>> GetAllUserPosts(int userId, int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }
    }
}

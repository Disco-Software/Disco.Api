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

        public async Task<List<Post>> GetAll(int userId, int pageSize, int pageNumber)
        {
            var posts = new List<Post>();

            var user = await _ctx.Users
                .Include(p => p.Account)
                .ThenInclude(f => f.Followers)
                .Include(p => p.Account)
                .ThenInclude(p => p.Following)
                .Include(p => p.Account)
                .ThenInclude(p => p.Posts)
                .ThenInclude(p => p.PostImages)
                .Include(p => p.Account)
                .ThenInclude(p => p.Posts)
                .ThenInclude(s => s.PostSongs)
                .Include(p => p.Account)
                .ThenInclude(p => p.Posts)
                .ThenInclude(p => p.PostVideos)
                .Include(p => p.Account)
                .ThenInclude(p => p.Posts)
                .ThenInclude(l => l.Likes)
                .Where(s => s.Id == userId)
                .FirstOrDefaultAsync();

            posts.AddRange(user.Account.Posts);

            foreach (var following in user.Account.Following)
            {
                following.FollowerAccount = await _ctx.Accounts
                    .Include(p => p.Posts)
                    .ThenInclude(i => i.PostImages)
                    .Include(p => p.Posts)
                    .ThenInclude(s => s.PostSongs)
                    .Include(p => p.Posts)
                    .ThenInclude(v => v.PostVideos)
                    .Include(u => u.User)
                    .ThenInclude(l => l.Account)
                    .ThenInclude(p => p.Posts)
                    .ThenInclude(l => l.Likes)
                    .Where(f => f.Id == following.FollowerAccountId)
                    .FirstOrDefaultAsync();
                posts.AddRange(following.FollowerAccount.Posts);             
            }

            foreach (var follower in user.Account.Followers)
            {
                follower.FollowerAccount = await _ctx.Accounts
                    .Include(p => p.Posts)
                    .ThenInclude(i => i.PostImages)
                    .Include(p => p.Posts)
                    .ThenInclude(s => s.PostSongs)
                    .Include(p => p.Posts)
                    .ThenInclude(v => v.PostVideos)
                    .Include(u => u.User)
                    .Include(u => u.User)
                    .ThenInclude(l => l.Account)
                    .ThenInclude(p => p.Posts)
                    .ThenInclude(l => l.Likes)
                    .Where(f => f.Id == follower.FollowerAccountId)
                    .FirstOrDefaultAsync();
                posts.AddRange(follower.FollowerAccount.Posts);
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
                .Include(p => p.Account)
                .ThenInclude(p => p.Posts)
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

           return user.Account.Posts
                .OrderByDescending(d => d.DateOfCreation)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

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
                .Where(p => p.Account.UserId == userId)
                .OrderByDescending(p => p.DateOfCreation)
                .ToListAsync();

        }

        public async Task<List<Post>> GetAllUserPostsAsync(int accountId)
        {
            return await _ctx.Posts
                .Include(p => p.PostSongs)
                .Include(p => p.PostImages)
                .Include(p => p.PostVideos)
                .Where(p => p.AccountId == accountId)
                .ToListAsync();
        }
    }
}

using Disco.Domain.EF;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Disco.Domain.Repositories.Repositories
{
    public class PostRepository : BaseRepository<Post,int>, IPostRepository
    {
        public PostRepository(ApiDbContext ctx) : base(ctx) { }

        public override async Task AddAsync(Post post)
        {
            await base.AddAsync(post);
        }

        public override async Task Remove(Post item)
        {
           await base.Remove(item);
        }

        public override async Task<Post> GetAsync(int id)
        {
           return await _context.Posts
                .Include(p => p.Likes)
                .Include(i => i.PostImages)
                .Include(s => s.PostSongs)
                .Include(v => v.PostVideos)
                .Include(p => p.Account)
                .ThenInclude(u => u.User)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync() 
                ?? throw new NullReferenceException();
        }

        public async Task<List<Post>> GetPostsByDescriptionAsync(string search)
        {
            return await _context.Posts
                .Include(p => p.PostImages)
                .Include(p => p.PostVideos)
                .Include(p => p.PostSongs)
                .Where(p => p.Description.StartsWith(search))
                .ToListAsync();
        }

        public async Task<List<Post>> GetUserPostsAsync(int accountId)
        {
            return await _context.Accounts
                .SelectMany(account => account.Posts)
                .Include(post => post.PostImages)
                .Include(post => post.PostSongs)
                .Include(post => post.PostVideos)
                .Where(account => account.Id == accountId)
                .ToListAsync();
        }

        public async Task<List<Post>> GetFollowerPostsAsync(int accountId)
        {
            return await _context.Accounts
                .SelectMany(a => a.Posts)
                .Include(p => p.Likes)
                .Include(p => p.PostImages)
                .Include(p => p.PostSongs)
                .Include(p => p.PostVideos)
                .Where(p => p.AccountId == accountId)
                .ToListAsync();
        }

        public async Task<List<Post>> GetFollowingPostsAsync(List<UserFollower> followings)
        {
            var posts = new List<Post>();

            foreach (var following in followings)
            {
                var account = await _context.Accounts
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

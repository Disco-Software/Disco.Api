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

        public async Task AddAsync(Post post, User user)
        {
            if(user == null)
                throw new ArgumentNullException("user is null");
            
            await _context.Posts.AddAsync(post);
            user.Account.Posts.Add(post);
            
            await _context.SaveChangesAsync();
        }

        public override async Task RemoveAsync(Post post)
        {
            _context.Remove(post);

            await _context.SaveChangesAsync();
        }

        //public async Task<List<Post>> GetUserPostsAsync(int userId, int pageSize, int pageNumber)

        public override Task<Post> GetAsync(int id)
        {
           return _context.Posts
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
            return await _context.Posts
                .Include(p => p.PostImages)
                .Include(p => p.PostVideos)
                .Include(p => p.PostSongs)
                .Where(p => p.Description.StartsWith(search))
                .ToListAsync();
        }

        public async Task<List<Post>> GetUserPostsAsync(int accountId, int pageNumber, int pageSize)
        {
            return await _context.Posts
                .Include(account => account.Account)
                .Include(post => post.PostImages)
                .Include(post => post.PostSongs)
                .Include(post => post.PostVideos)
                .Where(post => post.AccountId == accountId)
                .OrderByDescending(post => post.DateOfCreation)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
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
                    .Include(x => x.User)
                    .Where(a => a.Id == following.FollowingAccountId)
                    .FirstOrDefaultAsync();

                posts.AddRange(account.Posts);
            }

            return posts;
        }

        public async Task<List<Post>> GetAllUserPosts(int userId, int pageSize, int pageNumber)
        {
            return await _context.Posts
                .Include(x => x.Account)
                .Where(x => x.Account.UserId == userId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<Post>> GetAllPostsAsync(DateTime from, DateTime to)
        {
            return await _context.Posts
                .Where(post => post.DateOfCreation >= from && post.DateOfCreation <= to)
                .OrderByDescending(post => post.DateOfCreation)
                .ToListAsync();
        }

        public async Task<List<Post>> GetUserPostsAsync(int accountId)
        {
            return await _context.Posts
                .Include(account => account.Account)
                .Include(post => post.PostImages)
                .Include(post => post.PostSongs)
                .Include(post => post.PostVideos)
                .Where(post => post.AccountId == accountId)
                .OrderByDescending(post => post.DateOfCreation)
                .ToListAsync();
        }

        public List<int> GetPostsCountFromMonth(DateTime date)
        {
            var postsInDay = new List<int>();

            var year = date.Year;
            var month = date.Month;
            var day = date.Day;

            foreach (var posts in _context.Posts)
            {
                var postsCount = _context.Posts
                    .Where(post => post.DateOfCreation.Value.Year == year)
                    .Where(post => post.DateOfCreation.Value.Month == month)
                    .Where(post => post.DateOfCreation.Value.Day == day)
                    .OrderBy(post => post.DateOfCreation.Value.Hour)
                    .OrderBy(post => post.DateOfCreation.Value.Minute)
                    .OrderBy(post => post.DateOfCreation.Value.Second)
                    .Count();

                postsInDay.Add(postsCount);
            }

            return postsInDay;
        }

        public List<int> GetPostsCountFromDay(DateTime date)
        {
            var postsInHours = new List<int>();

            var year = date.Year;
            var month = date.Month;
            var day = date.Day;

            foreach (var posts in _context.Posts)
            {
                var postsCount = _context.Posts
                    .Where(post => post.DateOfCreation.Value.Year == year)
                    .Where(post => post.DateOfCreation.Value.Month == month)
                    .Where(post => post.DateOfCreation.Value.Day == day)
                    .OrderBy(post => post.DateOfCreation.Value.Hour)
                    .OrderBy(post => post.DateOfCreation.Value.Minute)
                    .OrderBy(post => post.DateOfCreation.Value.Second)
                    .Count();

                postsInHours.Add(postsCount);
            }

            return postsInHours;
        }

        public List<int> GetPostsCountFromYear(DateTime date)
        {
            var postsInHours = new List<int>();

            var year = date.Year;
            var month = date.Month;
            var day = date.Day;

            foreach (var posts in _context.Posts)
            {
                var postsCount = _context.Posts
                    .Where(post => post.DateOfCreation.Value.Year == year)
                    .Where(post => post.DateOfCreation.Value.Month == month)
                    .Where(post => post.DateOfCreation.Value.Day == day)
                    .OrderBy(post => post.DateOfCreation.Value.Hour)
                    .OrderBy(post => post.DateOfCreation.Value.Minute)
                    .OrderBy(post => post.DateOfCreation.Value.Second)
                    .Count();

                postsInHours.Add(postsCount);
            }

            return postsInHours;
        }

        public int GetPostsCount(int accountId)
        {
            return _context.Posts.Count(x => x.AccountId == accountId);
        }
    }
}

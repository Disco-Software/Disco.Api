using Disco.BLL.Interfaces;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Identity;
using Disco.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext ctx;
        private readonly ApplicationUserManager _manager;
        public PostService(ApplicationDbContext ctx, ApplicationUserManager manager)
        {
            this.ctx = ctx;
            this._manager = manager;
        }
        public async Task<Post> AddAsync(Post post)
        {
            var user = await ctx.Users.FirstOrDefaultAsync(u => u.Id.Equals(post.UserId));
            user.Posts.Add(post);
            return post;
        }

        public async Task DeleteAsync(int postId)
        {
            PostRepository repo = new PostRepository(ctx);
            await repo.Delete(postId);
        }

        public async Task<List<Post>> GetAllAsync(string userId)
        {
            PostRepository repo = new PostRepository(ctx);
            var user = await ctx.Users.FirstOrDefaultAsync(u => u.Id.Equals(userId));
            return await repo.GetAll(p => p.UserId.Equals(user.Id));
        }

        public Task<Post> GetAsync(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<Post> UpdateAsync(Post post)
        {
            throw new NotImplementedException();
        }
    }
}

using Disco.BLL.DTO;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class PostService : IPostService
    {
        private readonly ClaimsPrincipal claimsPrincipal;
        private readonly UserManager<User> userManager;
        private readonly ApiDbContext ctx;
        public PostService(ApiDbContext _ctx, ClaimsPrincipal _claimsPrincipal, UserManager<User> _userManager)
        {
            ctx = _ctx;
            claimsPrincipal = _claimsPrincipal;
            userManager = _userManager;
        }

        public async Task<PostDTO> CreatePostAsync(PostModel post)
        {
            var user = await userManager.GetUserAsync(claimsPrincipal);
            if(user != null)
            {
               var newPost = ctx.Posts.Add(new Post { 
                    Description = post.Description,
                    VideoSource = new Video {
                        VideoSource = post.VideoSource,
                    },
                    Song = new Song {
                        ImageUrl = post.ImageUrl,
                        Source = post.VideoSource
                    },
                    User = user,
                    UserId = user.Id,
                }).Entity;
                user.Posts.Add(newPost);
                await ctx.SaveChangesAsync();

                return new PostDTO { Post = newPost, VarificationResult ="Success" };
            }
            return null;
        }

        public async Task DeletePostAsync(int postId)
        {
            var post = await ctx.Posts.Include(s => s.Song)
                .Include(u => u.User)
                .Where(p => p.Id == postId)
                .FirstOrDefaultAsync();
            post.User.Posts.Remove(post);
        }

        public Task<List<Post>> GetAllPostsAsync(Expression<Func<Post, bool>> expression)
        {
            if (expression == null)
                return ctx.Posts.ToListAsync();
            else
                return ctx.Posts.Where(expression).ToListAsync();
        }
    }
}

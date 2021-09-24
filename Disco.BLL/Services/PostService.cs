using AutoMapper;
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
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly ApiDbContext ctx;
        public PostService(ApiDbContext _ctx, IMapper _mapper, UserManager<User> _userManager)
        {
            ctx = _ctx;
            mapper = _mapper;
            userManager = _userManager;
        }

        public async Task<PostDTO> CreatePostAsync(CreatePostModel model)
        {
            var user = await ctx.Users
                .Include(p => p.Posts)
                .Where(p => p.Email == model.Email)
                .FirstOrDefaultAsync();
            if(user != null)
            {
                var post = mapper.Map<Post>(model);
                post.UserId = user.Id;
                post.User = user;
                ctx.Posts.Add(post);
                user.Posts.Add(post);
                await ctx.SaveChangesAsync();
                return new PostDTO { Post = post, VarificationResult ="Success" };
            }
            return new PostDTO { VarificationResult = "Faild"};
        }
        public async Task DeletePostAsync(int postId)
        {
            var post = await ctx.Posts
                .Include(s => s.Song)
                .Include(i => i.PostImage)
                .Include(v => v.Video)
                .Include(u => u.User)
                .Where(p => p.Id == postId)
                .FirstOrDefaultAsync();
            post.User.Posts.Remove(post);
            ctx.Posts.Remove(post);
            ctx.SaveChanges();
        }        
        public async Task<List<Post>> GetAllUserPosts(int userId)
        {
            var model = await ctx.Posts
                .Include(u => u.User)
                .Where(p => p.UserId == userId)
                .ToListAsync();
            return model;
        }
    }
}

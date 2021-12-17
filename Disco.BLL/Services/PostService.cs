using AutoMapper;
using Disco.BLL.DTO;
using Disco.BLL.Extensions;
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
    public class PostService : PostDTOExtincions,IPostService
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
            var user = await userManager.FindByNameAsync(model.Name);

           await ctx.Entry(user)
                .Reference(r => r.Profile)
                .LoadAsync();
           
            var post = mapper.Map<Post>(model);
            post.ProfileId = user.Profile.Id;
            post.Profile = user.Profile;

            await ctx.Posts.AddAsync(post);
            await ctx.SaveChangesAsync();
            return Ok(post);
        }
        public async Task DeletePostAsync(int postId)
        {
            var post = await ctx.Posts
                .Include(u => u.Profile)
                .ThenInclude(p => p.User)
                .Where(p => p.Id == postId)
                .FirstOrDefaultAsync();
            post.Profile.Posts.Remove(post);
            ctx.Posts.Remove(post);
            ctx.SaveChanges();
        }        
        public async Task<List<Post>> GetAllUserPosts(int userId)
        {
            var model = await ctx.Posts
                .Include(u => u.Profile)
                .ThenInclude(u => u.User)
                .Where(p => p.Profile.UserId == userId)
                .ToListAsync();
            return model;
        }
    }
}

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
        private readonly ApiDbContext ctx;
        private readonly PostRepository postRepository;
        private readonly UserManager<User> userManager;
        public PostService(IMapper _mapper, PostRepository _postRepository, ApiDbContext _ctx, UserManager<User> _userManager)
        {
            mapper = _mapper;
            postRepository = _postRepository;
            ctx = _ctx;
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

            await postRepository.Add(post);

            return Ok(post);
        }
        public async Task DeletePostAsync(int postId)
        {
            var post = await ctx.Posts
                .Include(u => u.Profile)
                .ThenInclude(p => p.User)
                .Where(p => p.Id == postId)
                .FirstOrDefaultAsync();
           await postRepository.Remove(postId);
        }
        public async Task<List<Post>> GetAllUserPosts(int userId) =>
            await postRepository.GetAll(p => p.Profile.UserId == userId);
    }
}

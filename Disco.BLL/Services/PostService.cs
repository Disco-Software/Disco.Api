using AutoMapper;
using Disco.BLL.DTO;
using Disco.BLL.Extensions;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IWebHostEnvironment webHostEnvironment;
        public PostService(IMapper _mapper, PostRepository _postRepository, ApiDbContext _ctx, UserManager<User> _userManager, IWebHostEnvironment _webHostEnvironment)
        {
            mapper = _mapper;
            postRepository = _postRepository;
            ctx = _ctx;
            userManager = _userManager;
            webHostEnvironment = _webHostEnvironment;
        }

        public async Task<PostDTO> CreatePostAsync(CreatePostModel model)
        {
            var user = await userManager.FindByNameAsync(model.Name);

           await ctx.Entry(user)
                .Reference(r => r.Profile)
                .LoadAsync();

            var post = new Post { Description = model.Description, Profile = ctx.Profiles.FirstOrDefault(p => p.User.UserName == model.Name), ProfileId = ctx.Profiles.FirstOrDefault(p => p.User.UserName == model.Name).Id, PostImages = new List<PostImage>(), PostSongs = new List<PostSong>(), PostVideos = new List<PostVideo>() };

            if (model.PostImages != null)
                foreach (var file in model.PostImages)
                {
                    var image = await this.AddPostImage(file, post.Id);
                    ctx.PostImages.Add(image);
                    post.PostImages.Add(image);
                }


            post.ProfileId = user.Profile.Id;
            post.Profile = user.Profile;

            await postRepository.AddAsync(post,user);

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

        public async Task<PostImage> AddPostImage(IFormFile file, int postId)
        {
            var post = await postRepository.Get(postId);
            if(file == null)
                return null;

            if(file.Length == 0)
                return null;

            var imagePath = $"/images/{file.FileName}";

            var imageReader = file.OpenReadStream();
            using (var memoryStream = new FileStream(webHostEnvironment.WebRootPath + imagePath, FileMode.Create))
            {
                imageReader.CopyTo(memoryStream);               
            }
            var postImage = new PostImage { Source = imagePath, Post = post};
            
            await ctx.PostImages.AddAsync(postImage);

            return postImage;
        }
    }
}

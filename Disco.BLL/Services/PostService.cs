using AutoMapper;
using Disco.BLL.DTO;
using Disco.BLL.Extensions;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.BLL.Models.Posts;
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
    public class PostService : PostApiRequestHandlerBase,IPostService
    {
        private readonly IMapper mapper;
        private readonly ApiDbContext ctx;
        private readonly PostRepository postRepository;
        private readonly UserManager<User> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        public PostService
            (IMapper _mapper, 
            PostRepository _postRepository, 
            ApiDbContext _ctx,
            UserManager<User> _userManager,
            IHttpContextAccessor _httpContextAccessor, 
            IWebHostEnvironment _webHostEnvironment)
        {
            mapper = _mapper;
            postRepository = _postRepository;
            userManager = _userManager;
            ctx = _ctx;
            httpContextAccessor = _httpContextAccessor;
            webHostEnvironment = _webHostEnvironment;
        }

        public async Task<PostResponseModel> CreatePostAsync(CreatePostModel model)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
           
             await ctx.Entry(user)
                .Reference(p => p.Profile)
                .LoadAsync();

            await ctx.Entry(user.Profile)
                 .Collection(p => p.Posts)
                 .LoadAsync();

            var post = new Post { Description = model.Description, Profile = user.Profile, ProfileId = user.Profile.Id, PostImages = new List<PostImage>(), PostSongs = new List<PostSong>(), PostVideos = new List<PostVideo>() };

            if (model.PostImages != null)
                foreach (var file in model.PostImages)
                {
                    var image = await this.AddPostImage(file, post.Id);
                    ctx.PostImages.Add(image);
                    post.PostImages.Add(image);
                }
            if(model.PostSongs != null)
                foreach (var postSong in model.PostSongs)
                {
                    var song = await this.AddPostSong(postSong, post.Id);
                    ctx.PostSongs.Add(song);
                    post.PostSongs.Add(song);
                }
            if(model.PostVideos != null)
                foreach (var video in model.PostVideos)
                {
                    var postVideo = await this.AddPostVideos(video, post.Id);
                    ctx.PostVideos.Add(postVideo);
                    post.PostVideos.Add(postVideo);
                }

            post.ProfileId = user.Profile.Id;
            post.Profile = user.Profile;
            post.DateOfCreation = DateTime.UtcNow;

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

        public async Task<List<Post>> GetAllUserPosts(int userId)
        {
            var posts = postRepository
                .GetAll(p => p.Profile.UserId == userId)
                .Result
                .OrderByDescending(d => d.DateOfCreation)
                .ToList();
            return posts;
        }

        public async Task<List<Post>> GetAllPosts(int userId) =>
            await postRepository.GetAll(userId);

        public async Task<PostImage> AddPostImage(IFormFile file, int postId)
        {
            var post = await postRepository.Get(postId);
            if(file == null)
                return null;

            if(file.Length == 0)
                return null;

            var imagePath = Path.Combine(webHostEnvironment.WebRootPath, "images", file.FileName);

            var imageReader = file.OpenReadStream();
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                imageReader.CopyTo(fileStream);
                
                var postImage = new PostImage { Source = fileStream.Name, Post = post };
                
                await ctx.PostImages.AddAsync(postImage);
                
                return postImage;
            }
        }
        public async Task<PostSong> AddPostSong(IFormFile file, int postId)
        {
            var post = await postRepository.Get(postId);
            if (file == null)
                return null;

            if (file.Length == 0)
                return null;

            var songPath = Path.Combine(webHostEnvironment.WebRootPath, "songs", file.FileName);
            var songImagePath = Path.Combine(webHostEnvironment.WebRootPath, "songsImages", file.FileName);

            var songReader = file.OpenReadStream();
            using (var fileStream = new FileStream(songPath, FileMode.Create))
            {
                songReader.CopyTo(fileStream);

                var postSong = new PostSong { ImageUrl = songImagePath, Source = fileStream.Name, Post = post };

                await ctx.PostSongs.AddAsync(postSong);

                return postSong;
            }
        }
        public async Task<PostVideo> AddPostVideos(IFormFile file, int postId)
        {
            var post = await postRepository.Get(postId);
            if (file == null)
                return null;

            if (file.Length == 0)
                return null;

            var videoPath = Path.Combine(webHostEnvironment.WebRootPath, "videos", file.FileName);

            var songReader = file.OpenReadStream();
            using (var fileStream = new FileStream(videoPath, FileMode.Create))
            {
                songReader.CopyTo(fileStream);

                var postVideo = new PostVideo {VideoSource = fileStream.Name, Post = post };

                await ctx.PostVideos.AddAsync(postVideo);

                return postVideo;
            }
        }

    }
}

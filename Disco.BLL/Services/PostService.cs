using AutoMapper;
using Azure.Storage.Blobs;
using Disco.BLL.DTO;
using Disco.BLL.Handlers;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.BLL.Models.Posts;
using Disco.BLL.Models.Songs;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class PostService : ApiRequestHandlerBase, IPostService
    {
        private readonly ApiDbContext ctx;
        private readonly PostRepository postRepository;
        private readonly UserManager<User> userManager;
        private readonly BlobServiceClient blobServiceClient;
        private readonly IImageService imageService;
        private readonly ISongService songService;
        private readonly IVideoService videoService;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        public PostService(
            PostRepository _postRepository,
            ApiDbContext _ctx,
            UserManager<User> _userManager,
            BlobServiceClient _blobServiceClient,
            IMapper _mapper,
            IImageService _imageService,
            ISongService _songService,
            IVideoService _videoService,
            IHttpContextAccessor _httpContextAccessor)
        {
            postRepository = _postRepository;
            ctx = _ctx;
            userManager = _userManager;
            blobServiceClient = _blobServiceClient;
            mapper = _mapper;
            imageService = _imageService;
            songService = _songService;
            videoService = _videoService;
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task<IActionResult> CreatePostAsync(CreatePostModel model)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
           
             await ctx.Entry(user)
                .Reference(p => p.Profile)
                .LoadAsync();

            await ctx.Entry(user.Profile)
                 .Collection(p => p.Posts)
                 .LoadAsync();

            var post = mapper.Map<Post>(model);
            post.Profile = user.Profile;
            post.ProfileId = user.Profile.Id;
            
            if (model.PostImages != null)
                foreach (var file in model.PostImages)
                {
                    var image = await imageService.CreatePostImage(
                        new Models.Images.CreateImageModel { ImageFile = file });
                    post.PostImages.Add(image);
                }
            if (model.PostSongs != null)
                foreach (var postSong in model.PostSongs)
                {
                    var name = model.PostSongNames.First();
                    var image = model.PostSongImages.First();
                    var executorName = model.ExecutorNames.First();

                    var song = await songService.CreatePostSongAsync(
                         new CreateSongModel { SongFile = postSong, SongImage = image, Name = name, ExecutorName = executorName, PostId = post.Id });
                   
                    model.PostSongNames.Remove(name);
                    model.PostSongImages.Remove(image);
                    model.ExecutorNames.Remove(executorName);

                    post.PostSongs.Add(song);
                }
            if (model.PostVideos != null)
                foreach (var video in model.PostVideos)
                {
                    var postVideo = await videoService.CreateVideoAsync(
                        new Models.Videos.CreateVideoModel { VideoFile = video });
                    post.PostVideos.Add(postVideo);
                }

            post.ProfileId = user.Profile.Id;
            post.Profile = user.Profile;
            post.DateOfCreation = DateTime.UtcNow;

            await postRepository.AddAsync(post,user);

            return Ok(post);
        }

        public async Task DeletePostAsync(int postId) =>
           await postRepository.Remove(postId);

        public async Task<ActionResult<List<Post>>> GetAllUserPosts(int userId)
        {
            var posts = postRepository
                .GetAll(p => p.Profile.UserId == userId)
                .Result
                .OrderByDescending(d => d.DateOfCreation)
                .ToList();
            return posts;
        }

        public async Task<ActionResult<List<Post>>> GetAllPosts(GetAllPostsModel model)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);

            return await postRepository.GetAll(user.Id, model.PageSize, model.PageNumber);
        }

    }
}

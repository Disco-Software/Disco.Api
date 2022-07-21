using AutoMapper;
using Azure.Storage.Blobs;
using Disco.Business.Dto;
using Disco.Business.Handlers;
using Disco.Business.Interfaces;
using Disco.Business.Dto;
using Disco.Business.Dto.Posts;
using Disco.Business.Dto.Songs;
using Disco.Domain.EF;
using Disco.Domain.Models;
using Disco.Domain.Repositories;
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
using Disco.Domain.Interfaces;

namespace Disco.Business.Services
{
    public class PostService : ApiRequestHandlerBase, IPostService
    {
        private readonly ApiDbContext ctx;
        private readonly UserManager<User> userManager;
        private readonly IPostRepository postRepository;
        private readonly IImageService imageService;
        private readonly ISongService songService;
        private readonly IVideoService videoService;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        public PostService(
            ApiDbContext _ctx,
            UserManager<User> _userManager,
            IMapper _mapper,
            IPostRepository _postRepository,
            IImageService _imageService,
            ISongService _songService,
            IVideoService _videoService,
            IHttpContextAccessor _httpContextAccessor)
        {
            postRepository = _postRepository;
            ctx = _ctx;
            userManager = _userManager;
            mapper = _mapper;
            imageService = _imageService;
            songService = _songService;
            videoService = _videoService;
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task<IActionResult> CreatePostAsync(CreatePostDto model)
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
                        new Dto.Images.CreateImageDto { ImageFile = file });
                    post.PostImages.Add(image);
                }
            if (model.PostSongs != null)
                foreach (var postSong in model.PostSongs)
                {
                    var name = model.PostSongNames.First();
                    var image = model.PostSongImages.First();
                    var executorName = model.ExecutorNames.First();

                    var song = await songService.CreatePostSongAsync(
                         new CreateSongDto { SongFile = postSong, SongImage = image, Name = name, ExecutorName = executorName, PostId = post.Id });
                   
                    model.PostSongNames.Remove(name);
                    model.PostSongImages.Remove(image);
                    model.ExecutorNames.Remove(executorName);

                    post.PostSongs.Add(song);
                }
            if (model.PostVideos != null)
                foreach (var video in model.PostVideos)
                {
                    var postVideo = await videoService.CreateVideoAsync(
                        new Dto.Videos.CreateVideoDto { VideoFile = video });
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

        public async Task<ActionResult<List<Post>>> GetAllUserPosts(GetAllPostsDto model)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);

            return await postRepository.GetAllUserPosts(user.Id, model.PageSize, model.PageNumber);
        }

        public async Task<ActionResult<List<Post>>> GetAllPosts(GetAllPostsDto model)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);

            return await postRepository.GetAllUserPosts(user.Id, model.PageSize, model.PageNumber);
        }
    }
}

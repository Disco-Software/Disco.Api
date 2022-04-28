using AutoMapper;
using Azure.Storage.Blobs;
using Disco.BLL.DTO;
using Disco.BLL.Extensions;
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

        public async Task<PostResponseModel> CreatePostAsync(CreatePostModel model)
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
                    foreach (var postSongImage in model.PostSongImages)
                    {
                        foreach (var name in model.PostSongNames)
                        {
                            var song = await songService.CreatePostSongAsync(
                                new CreateSongModel { SongFile = postSong, SongImage = postSongImage, Name = name, PostId = post.Id });
                            post.PostSongs.Add(song);
                        }
                    }
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

        public async Task<List<Post>> GetAllPosts(int userId)
        {
             var result = postRepository.GetAll(userId)
                .Result
                .OrderByDescending(p => p.DateOfCreation)
                .ToList();
            return result;
        }

        public async Task<PostImage> AddPostImage(IFormFile file, int postId)
        {
            var post = await postRepository.Get(postId);
            var uniqueImageName = Guid.NewGuid().ToString() + "_" + file.FileName.Replace(' ', '_');

            if (file == null)
                return null;

            if (file.Length == 0)
                return null;

            var containerClient = blobServiceClient.GetBlobContainerClient("images");
            var blobClient = containerClient.GetBlobClient(uniqueImageName);

            using var imageReader = file.OpenReadStream();
            var blobResult = blobClient.Upload(imageReader);

            var postImage = new PostImage { Source = blobClient.Uri.AbsoluteUri, Post = post };

            await ctx.PostImages.AddAsync(postImage);

            return postImage;
        }
        public async Task<PostSong> AddPostSong(CreateSongModel model)
        {
            var post = await postRepository.Get(model.PostId);
            var uniqueSongName = Guid.NewGuid().ToString() + "_" + model.SongFile.FileName.Replace(' ', '_');
            var uniqueImageName = Guid.NewGuid().ToString() + "_" + model.SongImage.FileName.Replace(' ', '_');
            if (model.SongFile == null)
                return null;

            if (model.SongFile.Length == 0)
                return null;

            var blobSongContainerClient = blobServiceClient.GetBlobContainerClient("songs");
            var blobImageContainerClient = blobServiceClient.GetBlobContainerClient("images");
            var blobSongClient = blobSongContainerClient.GetBlobClient(uniqueSongName);
            var blobImageClient = blobImageContainerClient.GetBlobClient(uniqueImageName);
            
            using var songReader = model.SongFile.OpenReadStream();
            var blobSongResult = blobSongClient.Upload(songReader);

            using var imageReader = model.SongImage.OpenReadStream();
            var blobImageResult = blobImageClient.Upload(imageReader);

            var postSong = new PostSong { ImageUrl = blobImageClient.Uri.AbsoluteUri, Source = blobSongClient.Uri.AbsoluteUri, Post = post, UserName = model.Name};

            await ctx.PostSongs.AddAsync(postSong);

            return postSong;
        }
        public async Task<PostVideo> AddPostVideos(IFormFile file, int postId)
        {
            var post = await postRepository.Get(postId);
            var uniqueVideoName = Guid.NewGuid().ToString() + "_" + file.FileName.Replace(' ', '_');

            if (file == null)
                return null;

            if (file.Length == 0)
                return null;

           var containerClient = blobServiceClient.GetBlobContainerClient("videos");
            var blobClient = containerClient.GetBlobClient(uniqueVideoName);

            using var videoReader = file.OpenReadStream();
            var blobResult = blobClient.Upload(videoReader);

            var postVideo = new PostVideo {VideoSource = blobClient.Uri.AbsoluteUri, Post = post };

            await ctx.PostVideos.AddAsync(postVideo);

            return postVideo;
        }

    }
}

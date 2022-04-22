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
        private readonly IMapper mapper;
        private readonly ApiDbContext ctx;
        private readonly PostRepository postRepository;
        private readonly UserManager<User> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly BlobServiceClient blobServiceClient;
        public PostService
            (IMapper _mapper, 
            PostRepository _postRepository, 
            ApiDbContext _ctx,
            UserManager<User> _userManager,
            BlobServiceClient _blobServiceClient,
            IHttpContextAccessor _httpContextAccessor, 
            IWebHostEnvironment _webHostEnvironment)
        {
            mapper = _mapper;
            postRepository = _postRepository;
            userManager = _userManager;
            ctx = _ctx;
            httpContextAccessor = _httpContextAccessor;
            webHostEnvironment = _webHostEnvironment;
            blobServiceClient = _blobServiceClient;
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
            if (model.PostSongs != null)
                foreach (var postSong in model.PostSongs)
                {
                    foreach (var postSongImage in model.PostSongImages)
                    {
                        foreach (var name in model.PostSongNames)
                        {
                            var song = await this.AddPostSong(new CreateSongModel { SongFile = postSong, SongImage = postSongImage, Name = name, PostId = post.Id });
                            ctx.PostSongs.Add(song);
                            post.PostSongs.Add(song);
                        }
                    }
                }
            if (model.PostVideos != null)
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

            var postSong = new PostSong { ImageUrl = blobImageClient.Uri.AbsoluteUri, Source = blobSongClient.Uri.AbsoluteUri, Post = post, Name = model.Name};

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

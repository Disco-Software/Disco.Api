using AutoMapper;
using Azure.Storage.Blobs;
using Disco.BLL.Interfaces;
using Disco.BLL.Models.Stories;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class StoryService : IStoryService
    {
        private readonly StoryRepository storyRepository;
        private readonly UserManager<User> userManager;
        private readonly ApiDbContext ctx;
        private readonly BlobServiceClient blobServiceClient;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        public StoryService(
            StoryRepository _storyRepository,
            UserManager<User> _userManager,
            ApiDbContext _ctx,
            BlobServiceClient _blobServiceClient,
            IMapper _mapper,
            IHttpContextAccessor _httpContextAccessor)
        {
            storyRepository = _storyRepository;
            userManager = _userManager;
            ctx = _ctx;
            blobServiceClient = _blobServiceClient;
            mapper = _mapper;
            httpContextAccessor = _httpContextAccessor;
        }
        

        public async Task<Story> CreateStoryAsync(CreateStoryModel model)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);

            await ctx.Entry(user)
                .Reference(p => p.Profile)
                .LoadAsync();

            await ctx.Entry(user.Profile)
                .Collection(s => s.Stories)
                .LoadAsync();

            if (user == null)
                throw new NullReferenceException("User is null");

            var story = new Story 
            { 
                DateOfCreation = DateTime.UtcNow,
                StoryVideos = new List<StoryVideo>(),
                StoryImages = new List<StoryImage>()
            };

            if (model.StoryImages != null)
                foreach (var image in model.StoryImages)
                {
                    var storyImage = await this.ConvertFileToStoryImage(image, story.Id);
                    story.StoryImages.Add(storyImage);
                }

            if (model.StoryVideos != null)
                foreach (var video in model.StoryVideos)
                {
                    var storyImage = await this.ConvertFileToStoryVideo(video, story.Id);
                    story.StoryVideos.Add(storyImage);
                }

            story.DateOfCreation = DateTime.UtcNow;

            user.Profile.Stories.Add(story);
            await storyRepository.Add(story);

            return story;
        }

        public async Task DeleteStoryAsync(int id)
        {
            var story = await storyRepository.Get(id);

            if (story.DateOfCreation > DateTime.UtcNow.AddHours(12))
                await storyRepository.Remove(id);
        }

        public async Task<Story> GetStoryAsync(int id) => 
            await storyRepository.Get(id);

        public async Task<List<Story>> GetAllStoryAsync(int profileId)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);

            await ctx.Entry(user)
                .Reference(s => s.Profile)
                .LoadAsync();

            await ctx.Entry(user.Profile)
                .Collection(s => s.Stories)
                .LoadAsync();

            return await storyRepository.GetAll(profileId);
        }

        private async Task<StoryImage> ConvertFileToStoryImage(IFormFile image, int storyId)
        {
            var story = await storyRepository.Get(storyId);
            
            var unequeName = Guid.NewGuid().ToString() + "_" + image.FileName.Replace(' ', '_');
           
            if (image == null)
                return null;

            if (image.Length == 0)
                return null;

            var blobContainerClient = blobServiceClient.GetBlobContainerClient("images");
            var blobClient = blobContainerClient.GetBlobClient(unequeName);

            using var imageReader = image.OpenReadStream();

            blobClient.Upload(imageReader);

            var storyImage = new StoryImage { Source = blobClient.Uri.AbsoluteUri, Story = story };
            
            ctx.StoriesImages.Add(storyImage);

            return storyImage;
        }
        private async Task<StoryVideo> ConvertFileToStoryVideo(IFormFile video, int storyId)
        {
            var story = await storyRepository.Get(storyId);
            
            var unequeName = Guid.NewGuid().ToString() + "_" + video.FileName.Replace(' ', '_');

            if (video == null)
                return null;

            if (video.Length == 0)
                return null;

            var blobContainerClient =  blobServiceClient.GetBlobContainerClient("videos");
            var blobClient = blobContainerClient.GetBlobClient(unequeName);

            using var videoReader = video.OpenReadStream();

            blobClient.Upload(videoReader);

            var storyVideo = new StoryVideo { Source = blobClient.Uri.AbsoluteUri, Story = story};

            return storyVideo;
        }
    }
}

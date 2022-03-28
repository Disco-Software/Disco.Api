using AutoMapper;
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
        private readonly ProfileRepository profileRepository;
        private readonly ApiDbContext ctx;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public StoryService(
            StoryRepository _storyRepository,
            ProfileRepository _profileRepository,
            ApiDbContext _ctx,
            IMapper _mapper,
            IWebHostEnvironment _webHostEnvironment)
        {
            storyRepository = _storyRepository;
            profileRepository = _profileRepository;
            ctx = _ctx;
            mapper = _mapper;
            webHostEnvironment = _webHostEnvironment;
        }
        

        public async Task<Story> CreateStoryAsync(CreateStoryModel model)
        {
            var user = await profileRepository.Get(model.ProfileId);

            if (user.User == null)
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

            await storyRepository.Add(story, user);

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
            var profile = await profileRepository.Get(profileId);

            return await storyRepository.GetAll(profileId);
        }

        private async Task<StoryImage> ConvertFileToStoryImage(IFormFile image, int storyId)
        {
            var story = await storyRepository.Get(storyId);
            if (image == null)
                return null;

            if (image.Length == 0)
                return null;

            var imagePath = Path.Combine(webHostEnvironment.WebRootPath, "images", image.FileName);

            var imageReader = image.OpenReadStream();
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                imageReader.CopyTo(fileStream);

                var storyImage = new StoryImage { Source = fileStream.Name, Story = story };

                ctx.StoriesImages.Add(storyImage);

                return storyImage;
            }

        }
        private async Task<StoryVideo> ConvertFileToStoryVideo(IFormFile video, int storyId)
        {
            var story = await storyRepository.Get(storyId);
            if (video == null)
                return null;

            if (video.Length == 0)
                return null;

            var imagePath = Path.Combine(webHostEnvironment.WebRootPath, "videos", video.FileName);

            var imageReader = video.OpenReadStream();
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                imageReader.CopyTo(fileStream);

                var storyVideo = new StoryVideo { Source = fileStream.Name, Story = story };

                ctx.StoryVideos.Add(storyVideo);

                await ctx.SaveChangesAsync();

                return storyVideo;
            }

        }
    }
}

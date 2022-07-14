using AutoMapper;
using Azure.Storage.Blobs;
using Disco.BLL.Handlers;
using Disco.BLL.Interfaces;
using Disco.BLL.Models.Stories;
using Disco.DAL.EF;
using Disco.DAL.Entities;
using Disco.DAL.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class StoryService : ApiRequestHandlerBase, IStoryService
    {
        private readonly StoryRepository storyRepository;
        private readonly UserManager<User> userManager;
        private readonly ApiDbContext ctx;
        private readonly IStoryImageService storyImageService;
        private readonly IStoryVideoService storyVideoService;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        public StoryService(
            StoryRepository _storyRepository,
            UserManager<User> _userManager,
            ApiDbContext _ctx,
            IStoryImageService _storyImageService,
            IStoryVideoService _storyVideoService,
            IMapper _mapper,
            IHttpContextAccessor _httpContextAccessor)
        {
            storyRepository = _storyRepository;
            userManager = _userManager;
            ctx = _ctx;
            storyImageService = _storyImageService;
            storyVideoService = _storyVideoService;
            mapper = _mapper;
            httpContextAccessor = _httpContextAccessor;
        }
        

        public async Task<IActionResult> CreateStoryAsync(CreateStoryModel model)
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

            var story = mapper.Map<Story>(model);

            if (model.StoryImages != null)
                foreach (var image in model.StoryImages)
                {
                    var storyImage = await storyImageService.CreateStoryImageAsync(
                        new Models.StoryImages.CreateStoryImageModel { StoryImageFile = image });
                    story.StoryImages.Add(storyImage);
                }

            if (model.StoryVideos != null)
                foreach (var video in model.StoryVideos)
                {
                    var storyImage = await storyVideoService.CreateStoryVideoAsync(
                        new Models.StoryVideos.CreateStoryVideoModel { VideoFile = video });
                    story.StoryVideos.Add(storyImage);
                }

            story.DateOfCreation = DateTime.UtcNow;

            user.Profile.Stories.Add(story);
            await storyRepository.Add(story);

            return Ok(story);
        }

        public async Task DeleteStoryAsync(int id)
        {
            var story = await storyRepository.Get(id);

            if (story.DateOfCreation > DateTime.UtcNow.AddHours(12))
                await storyRepository.Remove(id);
        }

        public async Task<ActionResult<Story>> GetStoryAsync(int id) => 
            await storyRepository.Get(id);

        public async Task<ActionResult<List<Story>>> GetAllStoryAsync(GetAllStoriesModel model)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);

            await ctx.Entry(user)
                .Reference(s => s.Profile)
                .LoadAsync();

            await ctx.Entry(user.Profile)
                .Collection(s => s.Stories)
                .LoadAsync();

            return await storyRepository.GetAll(user.Profile.Id,model.PageNumber,model.PageSize);
        }
    }
}

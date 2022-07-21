using AutoMapper;
using Disco.Business.Handlers;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Stories;
using Disco.Domain.EF;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;

namespace Disco.Business.Services
{
    public class StoryService : ApiRequestHandlerBase, IStoryService
    {
        private readonly UserManager<User> userManager;
        private readonly ApiDbContext ctx;
        private readonly IStoryRepository storyRepository;
        private readonly IStoryImageService storyImageService;
        private readonly IStoryVideoService storyVideoService;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        public StoryService(
            UserManager<User> _userManager,
            ApiDbContext _ctx,
            IStoryRepository _storyRepository,
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
        

        public async Task<IActionResult> CreateStoryAsync(CreateStoryDto model)
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
                        new Dtos.StoryImages.CreateStoryImageDto { StoryImageFile = image });
                    story.StoryImages.Add(storyImage);
                }

            if (model.StoryVideos != null)
                foreach (var video in model.StoryVideos)
                {
                    var storyImage = await storyVideoService.CreateStoryVideoAsync(
                        new Dtos.StoryVideos.CreateStoryVideoDto { VideoFile = video });
                    story.StoryVideos.Add(storyImage);
                }

            story.DateOfCreation = DateTime.UtcNow;

            user.Profile.Stories.Add(story);
            await storyRepository.AddAsync(story, user.Profile);

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

        public async Task<ActionResult<List<Story>>> GetAllStoryAsync(GetAllStoriesDto model)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);

            await ctx.Entry(user)
                .Reference(s => s.Profile)
                .LoadAsync();

            await ctx.Entry(user.Profile)
                .Collection(s => s.Stories)
                .LoadAsync();

            return await storyRepository.GetAllAsync(user.Profile.Id,model.PageNumber,model.PageSize);
        }
    }
}

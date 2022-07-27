using AutoMapper;
using Disco.Business.Interfaces;
using Disco.Business.Dtos.Stories;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;

namespace Disco.Business.Services
{
    public class StoryService : IStoryService
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IStoryImageService _storyImageService;
        private readonly IStoryVideoService _storyVideoService;
        private readonly IMapper _mapper;
        public StoryService(
            IStoryRepository storyRepository,
            IStoryImageService storyImageService,
            IStoryVideoService storyVideoService,
            IMapper mapper)
        {
            _storyRepository = storyRepository;
            _storyImageService = storyImageService;
            _storyVideoService = storyVideoService;
            _mapper = mapper;
        }
        

        public async Task<Story> CreateStoryAsync(User user, CreateStoryDto model)
        {
            var story = _mapper.Map<Story>(model);

            if (model.StoryImages != null)
                foreach (var image in model.StoryImages)
                {
                    var storyImage = await _storyImageService.CreateStoryImageAsync(
                        new Dtos.StoryImages.CreateStoryImageDto { StoryImageFile = image });
                    story.StoryImages.Add(storyImage);
                }

            if (model.StoryVideos != null)
                foreach (var video in model.StoryVideos)
                {
                    var storyImage = await _storyVideoService.CreateStoryVideoAsync(
                        new Dtos.StoryVideos.CreateStoryVideoDto { VideoFile = video });
                    story.StoryVideos.Add(storyImage);
                }

            story.DateOfCreation = DateTime.UtcNow;

            user.Profile.Stories.Add(story);
            await _storyRepository.AddAsync(story, user.Profile);

            return story;
        }

        public async Task DeleteStoryAsync(int id)
        {
            await _storyRepository.Remove(id);
        }

        public async Task<Story> GetStoryAsync(int id)
        {
           return await _storyRepository.Get(id);
        }

        public async Task<List<Story>> GetAllStoryAsync(User user, GetAllStoriesDto model)
        {
            var stories = await _storyRepository.GetAllAsync(user.Profile.Id, model.PageNumber, model.PageSize);
            return stories;
        }
    }
}

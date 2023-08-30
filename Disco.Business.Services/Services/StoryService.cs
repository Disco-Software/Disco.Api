using AutoMapper;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Dtos.Stories;
using Disco.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Services
{
    public class StoryService : IStoryService
    {
        private readonly IStoryRepository _storyRepository;
        public StoryService(
            IStoryRepository storyRepository)        {
            _storyRepository = storyRepository;
        }
        

        public async Task CreateStoryAsync(Story story)
        {
            story.DateOfCreation = DateTime.UtcNow;
            story.Account.Stories.Add(story);

            await _storyRepository.AddAsync(story);
        }

        public async Task DeleteStoryAsync(int id)
        {
            await _storyRepository.RemoveAsync(id);
        }

        public async Task<Story> GetStoryAsync(int id)
        {
           return await _storyRepository.GetAsync(id);
        }

        public async Task<List<Story>> GetAllStoryAsync(User user, GetAllStoriesDto dto)
        {
            var stories = await _storyRepository.GetAllAsync(user.Account.Id, dto.PageNumber, dto.PageSize);
            return stories;
        }
    }
}

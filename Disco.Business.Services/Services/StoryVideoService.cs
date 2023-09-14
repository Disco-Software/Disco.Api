using AutoMapper;
using Azure.Storage.Blobs;
using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Dtos.StoryVideos;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Models.Models;

namespace Disco.Business.Services.Services
{
    public class StoryVideoService : IStoryVideoService
    {
        private readonly UserManager<User> _userManager;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IMapper _mapper;
        private readonly IStoryVideoRepository _storyVideoRepository;
        private readonly IStoryRepository _storyRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public StoryVideoService(
            UserManager<User> userManager,
            BlobServiceClient blobServiceClient,
            IMapper mapper,
            IStoryVideoRepository storyVideoRepository,
            IStoryRepository storyRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _storyVideoRepository = storyVideoRepository;
            _storyRepository = storyRepository;
            _userManager = userManager;
            _blobServiceClient = blobServiceClient;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<StoryVideo> CreateStoryVideoAsync(CreateStoryVideoDto model)
        {
            var story = await _storyRepository.GetAsync(model.StoryId);

            var unequeName = Guid.NewGuid().ToString() + "_" + model.VideoFile.FileName.Replace(' ', '_');

            if (model.VideoFile == null)
                return null;

            if (model.VideoFile.Length == 0)
                return null;

            var blobContainerClient = _blobServiceClient.GetBlobContainerClient("videos");
            var blobClient = blobContainerClient.GetBlobClient(unequeName);

            using var videoReader = model.VideoFile.OpenReadStream();

            blobClient.Upload(videoReader);

            var storyVideo = _mapper.Map<StoryVideo>(model);
            storyVideo.Source = blobClient.Uri.AbsoluteUri;
            storyVideo.DateOfCreation = DateTime.UtcNow;

            return storyVideo;
        }

        public async Task Remove(int id)
        {
            var storyVideo = await _storyVideoRepository.GetAsync(id);

            storyVideo.Story.StoryVideos.Remove(storyVideo);

            await _storyVideoRepository.RemoveAsync(storyVideo);
        }
            
    }
}

using AutoMapper;
using Azure.Storage.Blobs;
using Disco.Business.Interfaces.Dtos.StoryVideos;
using Disco.Business.Interfaces.Dtos.StoryVideos.User.CreateStoryVideo;
using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Utils.Guards;
using Disco.Domain.Interfaces;
using Disco.Domain.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

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

            DefaultGuard.ArgumentNull(_storyVideoRepository);
            DefaultGuard.ArgumentNull(_storyRepository);
            DefaultGuard.ArgumentNull(_userManager);
            DefaultGuard.ArgumentNull(_blobServiceClient);
            DefaultGuard.ArgumentNull(_mapper);
            DefaultGuard.ArgumentNull(_httpContextAccessor);
        }

        public async Task<StoryVideo> CreateStoryVideoAsync(CreateStoryVideoRequestDto dto)
        {
            var unequeName = Guid.NewGuid().ToString() + "_" + dto.Video.FileName.Replace(' ', '_');

            if (dto.Video == null)
                return null;

            if (dto.Video.Length == 0)
                return null;

            var blobContainerClient = _blobServiceClient.GetBlobContainerClient("videos");
            var blobClient = blobContainerClient.GetBlobClient(unequeName);

            using var videoReader = dto.Video.OpenReadStream();

            blobClient.Upload(videoReader);

            var storyVideo = _mapper.Map<StoryVideo>(dto);
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

using AutoMapper;
using Azure.Storage.Blobs;
using Disco.Business.Interfaces.Dtos.StoryImages.User.CreateStoryImage;
using Disco.Business.Interfaces.Interfaces;
using Disco.Domain.Interfaces;
using Disco.Domain.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Disco.Business.Services.Services
{
    public class StoryImageService : IStoryImageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IMapper _mapper;
        private readonly IStoryImageRepository _storyImageRepository;
        private readonly IStoryRepository _storyRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StoryImageService(
            BlobServiceClient blobServiceClient,
            IMapper mapper,
            IStoryImageRepository storyImageRepository,
            IStoryRepository storyRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _storyImageRepository = storyImageRepository;
            _storyRepository = storyRepository;
            _blobServiceClient = blobServiceClient;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<StoryImage> CreateStoryImageAsync(CreateStoryImageRequestDto dto)
        {
            var unequeName = Guid.NewGuid().ToString() + "_" + dto.StoryImage.FileName.Replace(' ', '_');

            if (dto.StoryImage == null)
                return null;

            if (dto.StoryImage.Length == 0)
                return null;

            var blobContainerClient = _blobServiceClient.GetBlobContainerClient("images");
            var blobClient = blobContainerClient.GetBlobClient(unequeName);

            using var imageReader = dto.StoryImage.OpenReadStream();

            blobClient.Upload(imageReader);

            var storyImage = _mapper.Map<StoryImage>(dto);
            storyImage.Source = blobClient.Uri.AbsoluteUri;
            storyImage.DateOfCreation = DateTime.UtcNow;

            await _storyImageRepository.AddAsync(storyImage);

            return storyImage;
        }

        public async Task RemoveStoryImageAsync(int id)
        {
            var storyImage = await _storyImageRepository.GetAsync(id);

            storyImage.Story.StoryImages.Remove(storyImage);

           await _storyImageRepository.RemoveAsync(storyImage);
        }
    }
}

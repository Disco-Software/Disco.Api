using AutoMapper;
using Azure.Storage.Blobs;
using Disco.Business.Interfaces;
using Disco.Business.Dto.StoryImages;
using Disco.Domain.Models;
using Disco.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;

namespace Disco.Business.Services
{
    public class StoryImageService : IStoryImageService
    {
        private readonly UserManager<User> userManager;
        private readonly BlobServiceClient blobServiceClient;
        private readonly IMapper mapper;
        private readonly IStoryImageRepository storyImageRepository;
        private readonly IStoryRepository storyRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public StoryImageService(
            UserManager<User> _userManager,
            BlobServiceClient _blobServiceClient,
            IMapper _mapper,
            IStoryImageRepository _storyImageRepository,
            IStoryRepository _storyRepository,
            IHttpContextAccessor _httpContextAccessor)
        {
            storyImageRepository = _storyImageRepository;
            storyRepository = _storyRepository;
            userManager = _userManager;
            blobServiceClient = _blobServiceClient;
            mapper = _mapper;
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task<StoryImage> CreateStoryImageAsync(CreateStoryImageDto model)
        {
            var story = await storyRepository.Get(model.StoryId);

            var unequeName = Guid.NewGuid().ToString() + "_" + model.StoryImageFile.FileName.Replace(' ', '_');

            if (model.StoryImageFile == null)
                return null;

            if (model.StoryImageFile.Length == 0)
                return null;

            var blobContainerClient = blobServiceClient.GetBlobContainerClient("images");
            var blobClient = blobContainerClient.GetBlobClient(unequeName);

            using var imageReader = model.StoryImageFile.OpenReadStream();

            blobClient.Upload(imageReader);

            var storyImage = mapper.Map<StoryImage>(model);
            storyImage.Source = blobClient.Uri.AbsoluteUri;
            storyImage.Story = story;
            
            await storyImageRepository.AddAsync(storyImage);

            return storyImage;
        }

        public async Task RemoveStoryImageAsync(int id) =>
            await storyImageRepository.Remove(id);
    }
}

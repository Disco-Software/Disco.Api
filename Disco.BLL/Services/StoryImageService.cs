using AutoMapper;
using Azure.Storage.Blobs;
using Disco.BLL.Interfaces;
using Disco.BLL.Dto.StoryImages;
using Disco.DAL.Models;
using Disco.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class StoryImageService : IStoryImageService
    {
        private readonly StoryImageRepository storyImageRepository;
        private readonly StoryRepository storyRepository;
        private readonly UserManager<User> userManager;
        private readonly BlobServiceClient blobServiceClient;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public StoryImageService(
            StoryImageRepository _storyImageRepository,
            StoryRepository _storyRepository,
            UserManager<User> _userManager,
            BlobServiceClient _blobServiceClient,
            IMapper _mapper,
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

using AutoMapper;
using Azure.Storage.Blobs;
using Disco.Business.Interfaces;
using Disco.Business.Dto.StoryVideos;
using Disco.Domain.Models;
using Disco.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Services
{
    public class StoryVideoService : IStoryVideoService
    {
        private readonly StoryVideoRepository storyVideoRepository;
        private readonly StoryRepository storyRepository;
        private readonly UserManager<User> userManager;
        private readonly BlobServiceClient blobServiceClient;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        
        public StoryVideoService(
            StoryVideoRepository _storyVideoRepository,
            StoryRepository _storyRepository,
            UserManager<User> _userManager,
            BlobServiceClient _blobServiceClient,
            IMapper _mapper,
            IHttpContextAccessor _httpContextAccessor)
        {
            storyVideoRepository = _storyVideoRepository;
            storyRepository = _storyRepository;
            userManager = _userManager;
            blobServiceClient = _blobServiceClient;
            mapper = _mapper;
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task<StoryVideo> CreateStoryVideoAsync(CreateStoryVideoDto model)
        {
            var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            var story = await storyRepository.Get(model.StoryId);

            var unequeName = Guid.NewGuid().ToString() + "_" + model.VideoFile.FileName.Replace(' ', '_');

            if (model.VideoFile == null)
                return null;

            if (model.VideoFile.Length == 0)
                return null;

            var blobContainerClient = blobServiceClient.GetBlobContainerClient("videos");
            var blobClient = blobContainerClient.GetBlobClient(unequeName);

            using var videoReader = model.VideoFile.OpenReadStream();

            blobClient.Upload(videoReader);

            var storyVideo = mapper.Map<StoryVideo>(model);
            storyVideo.Source = blobClient.Uri.AbsoluteUri;

            return storyVideo;
        }

        public async Task Remove(int id) =>
            await storyVideoRepository.Remove(id);
            
    }
}

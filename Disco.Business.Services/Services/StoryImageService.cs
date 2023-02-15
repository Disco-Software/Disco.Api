﻿using AutoMapper;
using Azure.Storage.Blobs;
using Disco.Business.Interfaces.Dtos.StoryImages;
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
    public class StoryImageService : IStoryImageService
    {
        private readonly UserManager<User> _userManager;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IMapper _mapper;
        private readonly IStoryImageRepository _storyImageRepository;
        private readonly IStoryRepository _storyRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StoryImageService(
            UserManager<User> userManager,
            BlobServiceClient blobServiceClient,
            IMapper mapper,
            IStoryImageRepository storyImageRepository,
            IStoryRepository storyRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _storyImageRepository = storyImageRepository;
            _storyRepository = storyRepository;
            _userManager = userManager;
            _blobServiceClient = blobServiceClient;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<StoryImage> CreateStoryImageAsync(CreateStoryImageDto dto)
        {
            var story = await _storyRepository.GetAsync(dto.StoryId);

            var unequeName = Guid.NewGuid().ToString() + "_" + dto.StoryImageFile.FileName.Replace(' ', '_');

            if (dto.StoryImageFile == null)
                return null;

            if (dto.StoryImageFile.Length == 0)
                return null;

            var blobContainerClient = _blobServiceClient.GetBlobContainerClient("images");
            var blobClient = blobContainerClient.GetBlobClient(unequeName);

            using var imageReader = dto.StoryImageFile.OpenReadStream();

            blobClient.Upload(imageReader);

            var storyImage = _mapper.Map<StoryImage>(dto);
            storyImage.Source = blobClient.Uri.AbsoluteUri;
            storyImage.DateOfCreation = DateTime.UtcNow;
            storyImage.Story = story;

            await _storyImageRepository.AddAsync(storyImage);

            return storyImage;
        }

        public async Task RemoveStoryImageAsync(int id)
        {
           await _storyImageRepository.Remove(id);
        }
    }
}
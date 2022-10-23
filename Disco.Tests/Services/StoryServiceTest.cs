using AutoMapper;
using Azure.Storage.Blobs;
using Disco.Business.Constants;
using Disco.Business.Dtos.Images;
using Disco.Business.Dtos.Stories;
using Disco.Business.Dtos.StoryImages;
using Disco.Business.Dtos.StoryVideos;
using Disco.Business.Interfaces;
using Disco.Business.Mapper;
using Disco.Business.Services;
using Disco.Domain.EF;
using Disco.Domain.Models;
using Disco.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disco.Domain.Interfaces;
using Account = Disco.Domain.Models.Account;

namespace Disco.Tests.Services
{
    [TestClass]
    public class StoryServiceTest
    {
        [TestMethod]
        public async Task CreateStoryWithImage_ReturnsSuccessResponse()
        {
            const string content = "Hello World from a Fake File";
            const string fileName = "test.pdf";
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);

            await writer.WriteAsync(content);
            await writer.FlushAsync();

            stream.Position = 0;

            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            var user = new User
            {
                UserName = "Vasya_Pupkin",
                Email = "pupkin2022@gmail.com",
                Account = new Domain.Models.Account
                {
                    Status = StatusTypes.MusicLover,
                    Id = 5,
                }
            };

            var story = new Story
            {
                Id = 1,
                StoryImages = new List<StoryImage>(),
                DateOfCreation = DateTime.UtcNow,
                StoryVideos = new List<StoryVideo>(),
                Account = user.Account,
                AccountId = user.Account.Id
            };

            user.Account.UserId = user.Id;
            user.Account.User = user;
            
            var mockedStoryRepository = new Mock<IStoryRepository>();

            mockedStoryRepository
                .Setup(s => s.AddAsync(It.IsAny<Story>(), It.IsAny<Account>()))
                .Returns(Task.CompletedTask);

            var mockedStoryImageService = new Mock<IStoryImageService>();
            mockedStoryImageService.Setup(s =>
                    s.CreateStoryImageAsync(new CreateStoryImageDto
                    {
                        StoryId = 2,
                        StoryImageFile = file
                    }))
                .Returns(Task.FromResult(new StoryImage
                {
                    Source = file.FileName,
                    DateOfCreation = DateTime.UtcNow
                }));

            var storyDto = new CreateStoryDto
            {
                ProfileId = user.Account.Id,
                StoryImages = new List<IFormFile>(),
                StoryVideos = new List<IFormFile>(),
            };

            storyDto.StoryImages.Add(file);

            var mapperConfiguration = new MapperConfiguration(config => config.AddProfile<MapProfile>());
            var mapper = mapperConfiguration.CreateMapper();

            var service = new StoryService(mockedStoryRepository.Object, mockedStoryImageService.Object, null, mapper);
            var response = await service.CreateStoryAsync(user, storyDto);

            Assert.IsNotNull(response.StoryImages);
            Assert.IsNotNull(response.DateOfCreation);
        }

        [TestMethod]
        public async Task CreateStoryWithVideo_ReturnsSuccessResponse()
        {
            const string content = "Hello World from a Fake File";
            const string fileName = "test.pdf";
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);

            await writer.WriteAsync(content);
            await writer.FlushAsync();

            stream.Position = 0;

            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            var user = new User
            {
                UserName = "Vasya_Pupkin",
                Email = "pupkin2022@gmail.com",
                Account = new Domain.Models.Account
                {
                    Status = StatusTypes.MusicLover,
                    Id = 5,
                }
            };

            var story = new Story
            {
                Id = 1,
                StoryImages = new List<StoryImage>(),
                DateOfCreation = DateTime.UtcNow,
                StoryVideos = new List<StoryVideo>(),
                Account = user.Account,
                AccountId = user.Account.Id
            };

            user.Account.UserId = user.Id;
            user.Account.User = user;

            var mockedStoryRepository = new Mock<IStoryRepository>();

            mockedStoryRepository
                .Setup(s => s.AddAsync(It.IsAny<Story>(), It.IsAny<Account>()))
                .Returns(Task.CompletedTask);

            var mockedStoryVideoService = new Mock<IStoryVideoService>();
            mockedStoryVideoService.Setup(s =>
                    s.CreateStoryVideoAsync(new CreateStoryVideoDto
                    {
                        StoryId = 2,
                        VideoFile = file
                    }))
                .Returns(Task.FromResult(new StoryVideo
                {
                    Source = file.FileName,
                    DateOfCreation = DateTime.UtcNow
                }));

            var storyDto = new CreateStoryDto
            {
                ProfileId = user.Account.Id,
                StoryImages = new List<IFormFile>(),
                StoryVideos = new List<IFormFile>(),
            };

            storyDto.StoryVideos.Add(file);

            var mapperConfiguration = new MapperConfiguration(config => config.AddProfile<MapProfile>());
            var mapper = mapperConfiguration.CreateMapper();

            var service = new StoryService(mockedStoryRepository.Object, null, mockedStoryVideoService.Object, mapper);
            var response = await service.CreateStoryAsync(user, storyDto);

            Assert.IsNotNull(response.StoryVideos);
            Assert.IsNotNull(response.DateOfCreation);
        }

        [TestMethod]
        public async Task GetStory_ReturnsSuccessResponse()
        {
            const string content = "Hello World from a Fake File";
            const string fileName = "test.pdf";
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);

            await writer.WriteAsync(content);
            await writer.FlushAsync();

            stream.Position = 0;

            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            var user = new User
            {
                UserName = "Vasya_Pupkin",
                Email = "pupkin2022@gmail.com",
                Account = new Domain.Models.Account
                {
                    Status = StatusTypes.MusicLover,
                    Id = 5,
                }
            };

            var story = new Story
            {
                Id = 1,
                StoryImages = new List<StoryImage>(),
                DateOfCreation = DateTime.UtcNow,
                StoryVideos = new List<StoryVideo>(),
                Account = user.Account,
                AccountId = user.Account.Id
            };

            user.Account.UserId = user.Id;
            user.Account.User = user;

            var mockedStoryRepository = new Mock<IStoryRepository>();
            mockedStoryRepository
                .Setup(s => s.GetAsync(story.Id))
                .Returns(Task.FromResult(story));

            var service = new StoryService(mockedStoryRepository.Object, null, null, null);
            var response = await service.GetStoryAsync(story.Id);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Id, story.Id);
        }
    }
}

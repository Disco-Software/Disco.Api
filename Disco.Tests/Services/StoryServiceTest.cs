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
using System.Web.Http;

namespace Disco.Tests.Services
{
    [TestClass]
    public class StoryServiceTest
    {
        [TestMethod]
        public async Task CreateStory_ReturnsSuccessResponse()
        {
            try
            {
                var content = "Hello World from a Fake File";
                var fileName = "test.pdf";
                var stream = new MemoryStream();
                var writer = new StreamWriter(stream);
                writer.Write(content);
                writer.Flush();
                stream.Position = 0;

                IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

                var user = new User
                {
                    UserName = "Vasya_Pupkin",
                    Email = "pupkin2022@gmail.com",
                    Profile = new Domain.Models.Profile
                    {
                        Status = StatusProvider.MusicLover,
                        Id = 5,
                    }
                };

                var story = new Story
                {
                    Id = 1,
                    StoryImages = new List<StoryImage>(),
                    DateOfCreation = DateTime.UtcNow,
                    StoryVideos = new List<StoryVideo>(),
                    Profile = user.Profile,
                    ProfileId = user.Profile.Id
                };

                user.Profile.UserId = user.Id;
                user.Profile.User = user;

                var ctxOptions = new DbContextOptionsBuilder<ApiDbContext>()
                    .UseInMemoryDatabase<ApiDbContext>("Disco.Database")
                    .Options;

                var mockedRepository = new Mock<StoryRepository>(new ApiDbContext(ctxOptions));

                mockedRepository
                    .Setup(s => s.AddAsync(story))
                    .Returns(Task.CompletedTask);

                var mockedStoryImage = new Mock<IStoryImageService>();
                mockedStoryImage.Setup(s =>
                    s.CreateStoryImageAsync(new CreateStoryImageDto { StoryId = 2, StoryImageFile = file }))
                        .Returns(Task.FromResult(new StoryImage { Source = file.FileName, DateOfCreation = DateTime.UtcNow }));

                var mockedStoryVideo = new Mock<IStoryVideoService>();

                var storyDto = new CreateStoryDto
                {
                    ProfileId = user.Profile.Id,
                    StoryImages = new List<IFormFile>(),
                    StoryVideos = new List<IFormFile>(),
                };

                storyDto.StoryImages.Add(file);

                var mapperConfiguration = new MapperConfiguration(config => config.AddProfile<MapProfile>());
                var mapper = mapperConfiguration.CreateMapper();

                var service = new StoryService(mockedRepository.Object, mockedStoryImage.Object, null, mapper);
                var response = await service.CreateStoryAsync(user, storyDto);

                Assert.IsNotNull(response.StoryImages);
                Assert.IsNotNull(response.DateOfCreation);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

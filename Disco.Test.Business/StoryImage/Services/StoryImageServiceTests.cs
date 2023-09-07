namespace Disco.Test.Business.StoryImage.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Azure.Storage.Blobs;
    using Disco.Business.Interfaces.Dtos.StoryImages;
    using Disco.Business.Services.Mappers;
    using Disco.Business.Services.Services;
    using Disco.Domain.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class StoryImageServiceTests
    {
        private StoryImageService _testClass;
        private UserManager<User> _userManager;
        
        private Mock<BlobServiceClient> _blobServiceClient;
        private IMapper _mapper;
        private Mock<IStoryImageRepository> _storyImageRepository;
        private Mock<IStoryRepository> _storyRepository;
        private Mock<IHttpContextAccessor> _httpContextAccessor;

        [SetUp]
        public void SetUp()
        {
            _userManager = new UserManager<User>(new Mock<IUserStore<User>>().Object, new Mock<IOptions<IdentityOptions>>().Object, new Mock<IPasswordHasher<User>>().Object, new[] { new Mock<IUserValidator<User>>().Object, new Mock<IUserValidator<User>>().Object, new Mock<IUserValidator<User>>().Object }, new[] { new Mock<IPasswordValidator<User>>().Object, new Mock<IPasswordValidator<User>>().Object, new Mock<IPasswordValidator<User>>().Object }, new Mock<ILookupNormalizer>().Object, new IdentityErrorDescriber(), new Mock<IServiceProvider>().Object, new Mock<ILogger<UserManager<User>>>().Object);
            
            _blobServiceClient = GetBlobServiceClientMock();

            _mapper = new MapperConfiguration(x => x.AddProfile(new StoryMapProfile())).CreateMapper();
            
            _storyImageRepository = new Mock<IStoryImageRepository>();
            _storyRepository = new Mock<IStoryRepository>();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _testClass = new StoryImageService(_userManager, _blobServiceClient.Object, _mapper, _storyImageRepository.Object, _storyRepository.Object, _httpContextAccessor.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new StoryImageService(_userManager, _blobServiceClient.Object, _mapper, _storyImageRepository.Object, _storyRepository.Object, _httpContextAccessor.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreateStoryImageAsync()
        {
            // Arrange
            var dto = new CreateStoryImageDto
            {
                StoryImageFile = new Mock<IFormFile>().Object,
                StoryId = 1736209464
            };

            _storyImageRepository.Setup(mock => mock.AddAsync(It.IsAny<StoryImage>())).Verifiable();
            _storyRepository.Setup(mock => mock.GetAsync(It.IsAny<int>())).ReturnsAsync(new Story
            {
                StoryImages = new List<StoryImage>(),
                StoryVideos = new List<StoryVideo>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 607037247,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue244253147",
                        FollowersCount = 1221649760,
                        NextStatusId = 454868522,
                        UserTarget = 55541191,
                        AccountId = 497366633,
                        Account = default
                    },
                    Cread = "TestValue1652836693",
                    Photo = "TestValue2009695115",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 700178805,
                    User = new User
                    {
                        RoleName = "TestValue1060454655",
                        RefreshToken = "TestValue645457077",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 894271776,
                        Account = default
                    }
                }
            });

            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            var file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            dto.StoryImageFile = file;

            // Act
            var result = await _testClass.CreateStoryImageAsync(dto);

            // Assert
            _storyImageRepository.Verify(mock => mock.AddAsync(It.IsAny<StoryImage>()));
            _storyRepository.Verify(mock => mock.GetAsync(It.IsAny<int>()));
        }

        [Test]
        public void CannotCallCreateStoryImageAsyncWithNullDto()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.CreateStoryImageAsync(default));
        }

        [Test]
        public async Task CreateStoryImageAsyncPerformsMapping()
        {
            // Arrange
            var dto = new CreateStoryImageDto
            {
                StoryImageFile = new Mock<IFormFile>().Object,
                StoryId = 1437511383
            };

            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            var file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            dto.StoryImageFile = file;

            // Act
            var result = await _testClass.CreateStoryImageAsync(dto);

            // Assert
            Assert.That(result.StoryId, Is.EqualTo(dto.StoryId));
        }

        [Test]
        public async Task CanCallRemoveStoryImageAsync()
        {
            // Arrange
            var id = 1;

            _storyImageRepository.Setup(mock => mock.RemoveAsync(It.IsAny<StoryImage>())).Verifiable();
            _storyImageRepository.Setup(mock => mock.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(new StoryImage
                {
                    StoryId = id,
                    Source = "http://photo.com",
                    Story = new Story(),
                    DateOfCreation = DateTime.UtcNow,
                    Id = 1,
                });

            // Act
            await _testClass.RemoveStoryImageAsync(id);

            // Assert
            _storyImageRepository.Verify(mock => mock.RemoveAsync(It.IsAny<StoryImage>()));
        }

        private Mock<BlobServiceClient> GetBlobServiceClientMock()
        {
            var mock = new Mock<BlobServiceClient>();
            var mockBlobContainerClient = new Mock<BlobContainerClient>();
            var mockBlobClient = new Mock<BlobClient>();

            var uri = new Uri("https://blablabla.com");

            mockBlobContainerClient.Setup(i => i.AccountName)
                .Returns("Test account name");
            mock.Setup(x => x.GetBlobContainerClient(It.IsAny<string>()))
                .Returns(mockBlobContainerClient.Object);
            mockBlobContainerClient.Setup(x => x.GetBlobClient(It.IsAny<string>()))
                .Returns(mockBlobClient.Object);
            mockBlobClient.Setup(x => x.Uri)
                .Returns(uri);

            return mock;
        }
    }
}
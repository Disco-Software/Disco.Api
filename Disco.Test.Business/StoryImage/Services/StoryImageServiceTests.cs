namespace Disco.Test.Business.StoryImage.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Azure.Storage.Blobs;
    using Disco.Business.Interfaces.Dtos.StoryImages;
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
        private BlobServiceClient _blobServiceClient;
        private Mock<IMapper> _mapper;
        private Mock<IStoryImageRepository> _storyImageRepository;
        private Mock<IStoryRepository> _storyRepository;
        private Mock<IHttpContextAccessor> _httpContextAccessor;

        [SetUp]
        public void SetUp()
        {
            _userManager = new UserManager<User>(new Mock<IUserStore<User>>().Object, new Mock<IOptions<IdentityOptions>>().Object, new Mock<IPasswordHasher<User>>().Object, new[] { new Mock<IUserValidator<User>>().Object, new Mock<IUserValidator<User>>().Object, new Mock<IUserValidator<User>>().Object }, new[] { new Mock<IPasswordValidator<User>>().Object, new Mock<IPasswordValidator<User>>().Object, new Mock<IPasswordValidator<User>>().Object }, new Mock<ILookupNormalizer>().Object, new IdentityErrorDescriber(), new Mock<IServiceProvider>().Object, new Mock<ILogger<UserManager<User>>>().Object);
            _blobServiceClient = new BlobServiceClient("TestValue384870087");
            _mapper = new Mock<IMapper>();
            _storyImageRepository = new Mock<IStoryImageRepository>();
            _storyRepository = new Mock<IStoryRepository>();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _testClass = new StoryImageService(_userManager, _blobServiceClient, _mapper.Object, _storyImageRepository.Object, _storyRepository.Object, _httpContextAccessor.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new StoryImageService(_userManager, _blobServiceClient, _mapper.Object, _storyImageRepository.Object, _storyRepository.Object, _httpContextAccessor.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullUserManager()
        {
            Assert.Throws<ArgumentNullException>(() => new StoryImageService(default, _blobServiceClient, _mapper.Object, _storyImageRepository.Object, _storyRepository.Object, _httpContextAccessor.Object));
        }

        [Test]
        public void CannotConstructWithNullBlobServiceClient()
        {
            Assert.Throws<ArgumentNullException>(() => new StoryImageService(_userManager, default, _mapper.Object, _storyImageRepository.Object, _storyRepository.Object, _httpContextAccessor.Object));
        }

        [Test]
        public void CannotConstructWithNullMapper()
        {
            Assert.Throws<ArgumentNullException>(() => new StoryImageService(_userManager, _blobServiceClient, default, _storyImageRepository.Object, _storyRepository.Object, _httpContextAccessor.Object));
        }

        [Test]
        public void CannotConstructWithNullStoryImageRepository()
        {
            Assert.Throws<ArgumentNullException>(() => new StoryImageService(_userManager, _blobServiceClient, _mapper.Object, default, _storyRepository.Object, _httpContextAccessor.Object));
        }

        [Test]
        public void CannotConstructWithNullStoryRepository()
        {
            Assert.Throws<ArgumentNullException>(() => new StoryImageService(_userManager, _blobServiceClient, _mapper.Object, _storyImageRepository.Object, default, _httpContextAccessor.Object));
        }

        [Test]
        public void CannotConstructWithNullHttpContextAccessor()
        {
            Assert.Throws<ArgumentNullException>(() => new StoryImageService(_userManager, _blobServiceClient, _mapper.Object, _storyImageRepository.Object, _storyRepository.Object, default));
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

            // Act
            var result = await _testClass.CreateStoryImageAsync(dto);

            // Assert
            _storyImageRepository.Verify(mock => mock.AddAsync(It.IsAny<StoryImage>()));
            _storyRepository.Verify(mock => mock.GetAsync(It.IsAny<int>()));

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallCreateStoryImageAsyncWithNullDto()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.CreateStoryImageAsync(default));
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

            // Act
            var result = await _testClass.CreateStoryImageAsync(dto);

            // Assert
            Assert.That(result.StoryId, Is.EqualTo(dto.StoryId));
        }

        [Test]
        public async Task CanCallRemoveStoryImageAsync()
        {
            // Arrange
            var id = 986936215;

            _storyImageRepository.Setup(mock => mock.Remove(It.IsAny<int>())).Verifiable();

            // Act
            await _testClass.RemoveStoryImageAsync(id);

            // Assert
            _storyImageRepository.Verify(mock => mock.Remove(It.IsAny<int>()));

            Assert.Fail("Create or modify test");
        }
    }
}
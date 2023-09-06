namespace Disco.Test.Business.StoryVideo.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Azure.Storage.Blobs;
    using Disco.Business.Interfaces.Dtos.StoryVideos;
    using Disco.Business.Interfaces.Dtos.Videos;
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
    public class StoryVideoServiceTests
    {
        private StoryVideoService _testClass;
        
        private Mock<UserManager<User>> _userManager;
        private Mock<BlobServiceClient> _blobServiceClient;
        private Mock<IStoryVideoRepository> _storyVideoRepository;
        private Mock<IStoryRepository> _storyRepository;
        private Mock<IHttpContextAccessor> _httpContextAccessor;

        private IMapper _mapper;


        [SetUp]
        public void SetUp()
        {
            _userManager = GetUserManager<User>();
            _blobServiceClient = GetBlobServiceClientMock();
            
            _mapper = new MapperConfiguration((x) => x.AddProfile(new StoryMapProfile()))
                .CreateMapper();
            
            _storyVideoRepository = new Mock<IStoryVideoRepository>();
            _storyRepository = new Mock<IStoryRepository>();
            _httpContextAccessor = new Mock<IHttpContextAccessor>();
            _testClass = new StoryVideoService(_userManager.Object, _blobServiceClient.Object, _mapper, _storyVideoRepository.Object, _storyRepository.Object, _httpContextAccessor.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new StoryVideoService(_userManager.Object, _blobServiceClient.Object, _mapper, _storyVideoRepository.Object, _storyRepository.Object, _httpContextAccessor.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreateStoryVideoAsync()
        {
            // Arrange
            var model = new CreateStoryVideoDto
            {
                StoryId = 102212158
            };

            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            var file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            model.VideoFile = file;


            _storyRepository.Setup(mock => mock.GetAsync(It.IsAny<int>())).ReturnsAsync(new Story
            {
                StoryImages = new List<StoryImage>(),
                StoryVideos = new List<StoryVideo>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1362765751,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1982828584",
                        FollowersCount = 501574210,
                        NextStatusId = 1043253223,
                        UserTarget = 1114454542,
                        AccountId = 1930728159,
                        Account = default
                    },
                    Cread = "TestValue1083703113",
                    Photo = "TestValue2094813973",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1646309568,
                    User = new User
                    {
                        RoleName = "TestValue1925661456",
                        RefreshToken = "TestValue371097917",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1216269122,
                        Account = default
                    }
                }
            });
            _httpContextAccessor.Setup(mock => mock.HttpContext).Returns(new DefaultHttpContext());

            // Act
            var result = await _testClass.CreateStoryVideoAsync(model);

            // Assert
            _storyRepository.Verify(mock => mock.GetAsync(It.IsAny<int>()));
        }

        [Test]
        public void CannotCallCreateStoryVideoAsyncWithNullModel()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.CreateStoryVideoAsync(default));
        }

        [Test]
        public async Task CreateStoryVideoAsyncPerformsMapping()
        {
            // Arrange
            var model = new CreateStoryVideoDto
            {
                StoryId = 102212158
            };

            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            var file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            model.VideoFile = file;

            // Act
            var result = await _testClass.CreateStoryVideoAsync(model);

            // Assert
            Assert.That(result.StoryId, Is.EqualTo(model.StoryId));
        }

        [Test]
        public async Task CanCallRemove()
        {
            // Arrange
            var id = 549160325;

            _storyVideoRepository.Setup(mock => mock.RemoveAsync(It.IsAny<StoryVideo>())).Verifiable();

            // Act
            await _testClass.Remove(id);

            // Assert
            _storyVideoRepository.Verify(mock => mock.RemoveAsync(It.IsAny<StoryVideo>()));

            Assert.Fail("Create or modify test");
        }

        private Mock<UserManager<TUser>> GetUserManager<TUser>()
    where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var passwordHasher = new Mock<IPasswordHasher<TUser>>();
            IList<IUserValidator<TUser>> userValidators = new List<IUserValidator<TUser>>
            {
                new UserValidator<TUser>()
            };
            IList<IPasswordValidator<TUser>> passwordValidators = new List<IPasswordValidator<TUser>>
            {
                new PasswordValidator<TUser>()
            };
            userValidators.Add(new UserValidator<TUser>());
            passwordValidators.Add(new PasswordValidator<TUser>());

            var userManager = new Mock<UserManager<TUser>>(store.Object, null, passwordHasher.Object, userValidators, passwordValidators, null, null, null, null);

            return userManager;
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
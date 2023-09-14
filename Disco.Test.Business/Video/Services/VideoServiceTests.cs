namespace Disco.Test.Business.Video.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Azure.Storage.Blobs;
    using Disco.Business.Interfaces.Dtos.Images;
    using Disco.Business.Interfaces.Dtos.Videos;
    using Disco.Business.Services.Mappers;
    using Disco.Business.Services.Services;
    using Disco.Domain.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _testClass;
        private Mock<BlobServiceClient> _blobServiceClient;
        private Mock<IVideoRepository> _videoRepository;
        private Mock<IPostRepository> _postRepository;

        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _blobServiceClient = GetBlobServiceClientMock();

            _mapper = new MapperConfiguration((x) => x.AddProfile(new PostMapProfile()))
                .CreateMapper();

            _videoRepository = new Mock<IVideoRepository>();
            _postRepository = new Mock<IPostRepository>();
            _testClass = new VideoService(_blobServiceClient.Object, _mapper, _videoRepository.Object, _postRepository.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new VideoService(_blobServiceClient.Object, _mapper, _videoRepository.Object, _postRepository.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreateVideoAsync()
        {
            // Arrange
            var model = new CreateVideoDto
            {
                PostId = 1031353934
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

            _videoRepository.Setup(mock => mock.AddAsync(It.IsAny<PostVideo>())).Verifiable();
            _postRepository.Setup(mock => mock.GetAsync(It.IsAny<int>())).ReturnsAsync(new Post
            {
                Description = "TestValue1525853416",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 929183399,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1209467309",
                        FollowersCount = 791796904,
                        NextStatusId = 866039216,
                        UserTarget = 1006832045,
                        AccountId = 1669706775,
                        Account = default
                    },
                    Cread = "TestValue1630440818",
                    Photo = "TestValue1369705668",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1236900968,
                    User = new User
                    {
                        RoleName = "TestValue1725117915",
                        RefreshToken = "TestValue1165107236",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 369218790,
                        Account = default
                    }
                }
            });

            // Act
            var result = await _testClass.CreateVideoAsync(model);

            // Assert
            _videoRepository.Verify(mock => mock.AddAsync(It.IsAny<PostVideo>()));
            _postRepository.Verify(mock => mock.GetAsync(It.IsAny<int>()));
        }

        [Test]
        public void CannotCallCreateVideoAsyncWithNullModel()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.CreateVideoAsync(default));
        }

        [Test]
        public async Task CreateVideoAsyncPerformsMapping()
        {
            // Arrange
            var model = new CreateVideoDto
            {
                PostId = 371565530
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
            var result = await _testClass.CreateVideoAsync(model);

            // Assert
            Assert.That(result.PostId, Is.EqualTo(model.PostId));
        }

        [Test]
        public async Task CanCallRemoveVideoAsync()
        {
            // Arrange
            var id = 1;
            var postVideo = new PostVideo
            {
                VideoSource = "TestValue2055230050",
                PostId = 973005875,
                Post = new Post
                {
                    Description = "TestValue1148833773",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 588080504,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue64736755",
                            FollowersCount = 1565507486,
                            NextStatusId = 1351773223,
                            UserTarget = 1861426870,
                            AccountId = 37336429,
                            Account = default(Account)
                        },
                        Cread = "TestValue968185866",
                        Photo = "TestValue1147318100",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 867629368,
                        User = new User
                        {
                            RoleName = "TestValue130040222",
                            RefreshToken = "TestValue1974299148",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1644707456,
                            Account = default(Account)
                        }
                    }
                }
            };


            _videoRepository.Setup(mock => mock.RemoveAsync(It.IsAny<PostVideo>())).Verifiable();
            _videoRepository.Setup(mock => mock.GetAsync(It.IsAny<int>())).ReturnsAsync(postVideo);

            // Act
            await _testClass.RemoveVideoAsync(id);

            // Assert
            _videoRepository.Verify(mock => mock.GetAsync(It.IsAny<int>()));
            _videoRepository.Verify(mock => mock.RemoveAsync(It.IsAny<PostVideo>()));
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
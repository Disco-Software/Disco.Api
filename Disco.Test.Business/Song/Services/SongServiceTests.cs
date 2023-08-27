namespace Disco.Test.Business.Song.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Azure.Storage.Blobs;
    using Disco.Business.Interfaces.Dtos.Images;
    using Disco.Business.Interfaces.Dtos.Songs;
    using Disco.Business.Services.Mappers;
    using Disco.Business.Services.Services;
    using Disco.Domain.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class SongServiceTests
    {
        private SongService _testClass;
        private Mock<BlobServiceClient> _blobServiceClient;
        private Mock<ISongRepository> _songRepository;
        private Mock<IPostRepository> _postRepository;

        private IMapper _mapper;


        [SetUp]
        public void SetUp()
        {
            _blobServiceClient = GetBlobServiceClientMock();
            _songRepository = new Mock<ISongRepository>();
            _postRepository = new Mock<IPostRepository>();

            _mapper = new MapperConfiguration(x => {
                x.AddProfile(new PostMapProfile());
            }).CreateMapper();

            _testClass = new SongService(_blobServiceClient.Object, _mapper, _songRepository.Object, _postRepository.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new SongService(_blobServiceClient.Object, _mapper, _songRepository.Object, _postRepository.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreatePostSongAsync()
        {
            // Arrange
            var dto = new CreateSongDto
            {
                Name = "TestValue1600205688",
                ExecutorName = "TestValue2135517118",
                Post = new Post
                {
                    Description = "TestValue1309828805",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1984648390,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1811982146",
                            FollowersCount = 1256785851,
                            NextStatusId = 903458003,
                            UserTarget = 866771004,
                            AccountId = 609810057,
                            Account = default
                        },
                        Cread = "TestValue1021324037",
                        Photo = "TestValue969210476",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 1556945256,
                        User = new User
                        {
                            RoleName = "TestValue1207981444",
                            RefreshToken = "TestValue1108096316",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1764334834,
                            Account = default
                        }
                    }
                }
            };

            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            var imageContent = "Hello World from a Fake File";
            var imageFileName = "test.pdf";
            var imageStream = new MemoryStream();
            var imageWriter = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            var file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);
            var image = new FormFile(imageStream, 0, imageStream.Length, "id_image_from_form", imageFileName);

            dto.Song = file;
            dto.Image = image;

            _songRepository.Setup(mock => mock.AddAsync(It.IsAny<PostSong>())).Verifiable();

            // Act
            var result = await _testClass.CreatePostSongAsync(dto);

            // Assert
            _songRepository.Verify(mock => mock.AddAsync(It.IsAny<PostSong>()));
        }

        [Test]
        public void CannotCallCreatePostSongAsyncWithNullDto()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.CreatePostSongAsync(default));
        }

        [Test]
        public async Task CreatePostSongAsyncPerformsMapping()
        {
            // Arrange

            var dto = new CreateSongDto
            {
                Name = "TestValue1824070908",
                ExecutorName = "TestValue2018383516",
                Post = new Post
                {
                    Description = "TestValue1478845566",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1721064721,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue351189666",
                            FollowersCount = 1090751121,
                            NextStatusId = 539751033,
                            UserTarget = 1490060041,
                            AccountId = 415557029,
                            Account = default
                        },
                        Cread = "TestValue248438926",
                        Photo = "TestValue374470763",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 269849636,
                        User = new User
                        {
                            RoleName = "TestValue1652470068",
                            RefreshToken = "TestValue1044800317",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 459143449,
                            Account = default
                        }
                    }
                }
            };

            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            var imageContent = "Hello World from a Fake File";
            var imageFileName = "test.pdf";
            var imageStream = new MemoryStream();
            var imageWriter = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            var file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);
            var image = new FormFile(imageStream, 0, imageStream.Length, "id_image_from_form", imageFileName);

            dto.Song = file;
            dto.Image = image;
            dto.ExecutorName = Guid.NewGuid().ToString();
            dto.Name = Guid.NewGuid().ToString();

            // Act
            var result = await _testClass.CreatePostSongAsync(dto);

            // Assert
            Assert.That(result.Name, Is.SameAs(dto.Name));
            Assert.That(result.ExecutorName, Is.SameAs(dto.ExecutorName));
            Assert.That(result.Post, Is.SameAs(dto.Post));
        }

        [Test]
        public async Task CanCallRemove()
        {
            // Arrange
            var songId = 2082310262;

            _songRepository.Setup(mock => mock.Remove(It.IsAny<int>())).Verifiable();

            // Act
            await _testClass.Remove(songId);

            // Assert
            _songRepository.Verify(mock => mock.Remove(It.IsAny<int>()));
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
namespace Disco.ApiServices.Test.Features.Post.RequestHandlers.CreatePost
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.ApiServices.Features.Post.RequestHandlers.CreatePost;
    using Disco.Business.Interfaces.Dtos.Images;
    using Disco.Business.Interfaces.Dtos.Posts;
    using Disco.Business.Interfaces.Dtos.Songs;
    using Disco.Business.Interfaces.Dtos.Videos;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Business.Services.Mappers;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class CreatePostRequestHandlerTests
    {
        private CreatePostRequestHandler _testClass;
        private IAccountService _accountService;
        private IPostService _postService;
        private IImageService _imageService;
        private ISongService _songService;
        private IVideoService _videoService;
        private IMapper _mapper;
        private IHttpContextAccessor _contextAccessor;

        [SetUp]
        public void SetUp()
        {
            _accountService = Substitute.For<IAccountService>();
            _postService = Substitute.For<IPostService>();
            _imageService = Substitute.For<IImageService>();
            _songService = Substitute.For<ISongService>();
            _videoService = Substitute.For<IVideoService>();
            
            _mapper = new MapperConfiguration(x => x.AddProfile(new PostMapProfile())).CreateMapper();
            
            _contextAccessor = Substitute.For<IHttpContextAccessor>();
            _testClass = new CreatePostRequestHandler(_accountService, _postService, _imageService, _songService, _videoService, _mapper, _contextAccessor);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new CreatePostRequestHandler(_accountService, _postService, _imageService, _songService, _videoService, _mapper, _contextAccessor);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new CreatePostRequest(new CreatePostDto
            {
                Description = "TestValue1684751429",
                PostImages = new List<IFormFile>(),
                PostSongs = new List<IFormFile>(),
                PostSongImages = new List<IFormFile>(),
                PostSongNames = new List<string>(),
                ExecutorNames = new List<string>(),
                PostVideos = new List<IFormFile>()
            });
            var cancellationToken = CancellationToken.None;

            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue1097872193",
                RefreshToken = "TestValue1673031935",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 994687808,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1969828453",
                        FollowersCount = 1235633537,
                        NextStatusId = 1825337148,
                        UserTarget = 437217130,
                        AccountId = 347227673,
                        Account = default(Account)
                    },
                    Cread = "TestValue1903499065",
                    Photo = "TestValue319237873",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 868524083,
                    User = default(User)
                }
            });
            _imageService.CreatePostImage(Arg.Any<CreateImageDto>()).Returns(new PostImage
            {
                Source = "TestValue1057741314",
                PostId = 1654324447,
                Post = new Post
                {
                    Description = "TestValue1511796462",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 506388710,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1137624643",
                            FollowersCount = 1039895837,
                            NextStatusId = 1206458877,
                            UserTarget = 85935419,
                            AccountId = 83752171,
                            Account = default(Account)
                        },
                        Cread = "TestValue2033190399",
                        Photo = "TestValue993369321",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 1138533764,
                        User = new User
                        {
                            RoleName = "TestValue163574638",
                            RefreshToken = "TestValue1356465967",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1698365755,
                            Account = default(Account)
                        }
                    }
                }
            });
            _songService.CreatePostSongAsync(Arg.Any<CreateSongDto>()).Returns(new PostSong
            {
                Name = "TestValue1921637614",
                ImageUrl = "TestValue1526638884",
                Source = "TestValue1949103621",
                ExecutorName = "TestValue1977815570",
                PostId = 947964785,
                Post = new Post
                {
                    Description = "TestValue1318764006",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1627951971,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue544690145",
                            FollowersCount = 1712550513,
                            NextStatusId = 203059581,
                            UserTarget = 119492037,
                            AccountId = 1069621109,
                            Account = default(Account)
                        },
                        Cread = "TestValue1214080706",
                        Photo = "TestValue1824489202",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 669083498,
                        User = new User
                        {
                            RoleName = "TestValue325531425",
                            RefreshToken = "TestValue2146603000",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 990755146,
                            Account = default(Account)
                        }
                    }
                }
            });
            _videoService.CreateVideoAsync(Arg.Any<CreateVideoDto>()).Returns(new PostVideo
            {
                VideoSource = "TestValue617207196",
                PostId = 160777206,
                Post = new Post
                {
                    Description = "TestValue2097847993",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1664277223,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue485796489",
                            FollowersCount = 1183421393,
                            NextStatusId = 463142383,
                            UserTarget = 1230252302,
                            AccountId = 1465969230,
                            Account = default(Account)
                        },
                        Cread = "TestValue739363794",
                        Photo = "TestValue1184470875",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 104502872,
                        User = new User
                        {
                            RoleName = "TestValue534498171",
                            RefreshToken = "TestValue831113170",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 613362486,
                            Account = default(Account)
                        }
                    }
                }
            });
            _contextAccessor.HttpContext.Returns(new DefaultHttpContext());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());
            await _postService.Received().CreatePostAsync(Arg.Any<Post>());
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(CreatePostRequest), CancellationToken.None));
        }
    }
}
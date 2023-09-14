namespace Disco.ApiServices.Test.Features.Like.RequestHandlers.CreateLike
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Like.RequestHandlers.CreateLike;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class CreateLikeRequestHandlerTests
    {
        private CreateLikeRequestHandler _testClass;
        private IAccountService _accountService;
        private IPostService _postService;
        private ILikeService _likeService;
        private IHttpContextAccessor _contextAccessor;

        [SetUp]
        public void SetUp()
        {
            _accountService = Substitute.For<IAccountService>();
            _postService = Substitute.For<IPostService>();
            _likeService = Substitute.For<ILikeService>();
            _contextAccessor = Substitute.For<IHttpContextAccessor>();
            _testClass = new CreateLikeRequestHandler(_accountService, _postService, _likeService, _contextAccessor);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new CreateLikeRequestHandler(_accountService, _postService, _likeService, _contextAccessor);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new CreateLikeRequest(622914854);
            var cancellationToken = CancellationToken.None;

            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue1526349319",
                RefreshToken = "TestValue1695183288",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 583018695,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue978851550",
                        FollowersCount = 774825237,
                        NextStatusId = 421415523,
                        UserTarget = 1521048053,
                        AccountId = 1844043947,
                        Account = default(Account)
                    },
                    Cread = "TestValue336922441",
                    Photo = "TestValue1858422993",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 658341758,
                    User = default(User)
                }
            });
            _postService.GetPostAsync(Arg.Any<int>()).Returns(new Post
            {
                Description = "TestValue1100456474",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1324445949,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1254010026",
                        FollowersCount = 1306328110,
                        NextStatusId = 1327015677,
                        UserTarget = 1684172070,
                        AccountId = 1173722253,
                        Account = default(Account)
                    },
                    Cread = "TestValue901209891",
                    Photo = "TestValue1124791757",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1866007663,
                    User = new User
                    {
                        RoleName = "TestValue2135854512",
                        RefreshToken = "TestValue1352925862",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1578636953,
                        Account = default(Account)
                    }
                }
            });
            _likeService.AddLikeAsync(Arg.Any<User>(), Arg.Any<Post>()).Returns(new List<Like>());
            _contextAccessor.HttpContext.Returns(new DefaultHttpContext());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());
            await _postService.Received().GetPostAsync(Arg.Any<int>());
            await _likeService.Received().AddLikeAsync(Arg.Any<User>(), Arg.Any<Post>());
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(CreateLikeRequest), CancellationToken.None));
        }
    }
}
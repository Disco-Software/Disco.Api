namespace Disco.ApiServices.Test.Features.Like.RequestHandlers.RemoveLike
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Like.RequestHandlers.RemoveLike;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class RemoveLikeRequestHandlerTests
    {
        private RemoveLikeRequestHandler _testClass;
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
            _testClass = new RemoveLikeRequestHandler(_accountService, _postService, _likeService, _contextAccessor);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new RemoveLikeRequestHandler(_accountService, _postService, _likeService, _contextAccessor);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullAccountService()
        {
            Assert.Throws<ArgumentNullException>(() => new RemoveLikeRequestHandler(default(IAccountService), _postService, _likeService, _contextAccessor));
        }

        [Test]
        public void CannotConstructWithNullPostService()
        {
            Assert.Throws<ArgumentNullException>(() => new RemoveLikeRequestHandler(_accountService, default(IPostService), _likeService, _contextAccessor));
        }

        [Test]
        public void CannotConstructWithNullLikeService()
        {
            Assert.Throws<ArgumentNullException>(() => new RemoveLikeRequestHandler(_accountService, _postService, default(ILikeService), _contextAccessor));
        }

        [Test]
        public void CannotConstructWithNullContextAccessor()
        {
            Assert.Throws<ArgumentNullException>(() => new RemoveLikeRequestHandler(_accountService, _postService, _likeService, default(IHttpContextAccessor)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new RemoveLikeRequest(1679160594);
            var cancellationToken = CancellationToken.None;

            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue792199200",
                RefreshToken = "TestValue469271927",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1064994940,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1667758290",
                        FollowersCount = 1537978454,
                        NextStatusId = 342257426,
                        UserTarget = 1151865389,
                        AccountId = 355936696,
                        Account = default(Account)
                    },
                    Cread = "TestValue2051839247",
                    Photo = "TestValue2060242205",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1311203092,
                    User = default(User)
                }
            });
            _postService.GetPostAsync(Arg.Any<int>()).Returns(new Post
            {
                Description = "TestValue2063790601",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1078533881,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1001080592",
                        FollowersCount = 1402419606,
                        NextStatusId = 678058626,
                        UserTarget = 1950940537,
                        AccountId = 93062934,
                        Account = default(Account)
                    },
                    Cread = "TestValue2143136363",
                    Photo = "TestValue1309640931",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1641218088,
                    User = new User
                    {
                        RoleName = "TestValue1321225491",
                        RefreshToken = "TestValue379386357",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 934463107,
                        Account = default(Account)
                    }
                }
            });
            _likeService.RemoveLikeAsync(Arg.Any<User>(), Arg.Any<Post>()).Returns(new List<Like>());
            _contextAccessor.HttpContext.Returns(new DefaultHttpContext());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());
            await _postService.Received().GetPostAsync(Arg.Any<int>());
            await _likeService.Received().RemoveLikeAsync(Arg.Any<User>(), Arg.Any<Post>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(RemoveLikeRequest), CancellationToken.None));
        }
    }
}
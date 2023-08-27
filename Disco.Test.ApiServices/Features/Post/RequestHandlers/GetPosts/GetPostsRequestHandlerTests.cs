namespace Disco.ApiServices.Test.Features.Post.RequestHandlers.GetPosts
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Post.RequestHandlers.GetPosts;
    using Disco.Business.Interfaces.Dtos.Posts;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class GetPostsRequestHandlerTests
    {
        private GetPostsRequestHandler _testClass;
        private IAccountService _accountService;
        private IFollowerService _followerService;
        private IPostService _postService;
        private ILikeService _likeService;
        private IHttpContextAccessor _contextAccessor;

        [SetUp]
        public void SetUp()
        {
            _accountService = Substitute.For<IAccountService>();
            _followerService = Substitute.For<IFollowerService>();
            _postService = Substitute.For<IPostService>();
            _likeService = Substitute.For<ILikeService>();
            _contextAccessor = Substitute.For<IHttpContextAccessor>();
            _testClass = new GetPostsRequestHandler(_accountService, _followerService, _postService, _likeService, _contextAccessor);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetPostsRequestHandler(_accountService, _followerService, _postService, _likeService, _contextAccessor);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullAccountService()
        {
            Assert.Throws<ArgumentNullException>(() => new GetPostsRequestHandler(default(IAccountService), _followerService, _postService, _likeService, _contextAccessor));
        }

        [Test]
        public void CannotConstructWithNullFollowerService()
        {
            Assert.Throws<ArgumentNullException>(() => new GetPostsRequestHandler(_accountService, default(IFollowerService), _postService, _likeService, _contextAccessor));
        }

        [Test]
        public void CannotConstructWithNullPostService()
        {
            Assert.Throws<ArgumentNullException>(() => new GetPostsRequestHandler(_accountService, _followerService, default(IPostService), _likeService, _contextAccessor));
        }

        [Test]
        public void CannotConstructWithNullLikeService()
        {
            Assert.Throws<ArgumentNullException>(() => new GetPostsRequestHandler(_accountService, _followerService, _postService, default(ILikeService), _contextAccessor));
        }

        [Test]
        public void CannotConstructWithNullContextAccessor()
        {
            Assert.Throws<ArgumentNullException>(() => new GetPostsRequestHandler(_accountService, _followerService, _postService, _likeService, default(IHttpContextAccessor)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new GetPostsRequest(new GetAllPostsDto
            {
                PageNumber = 1608047641,
                PageSize = 1816045057
            });
            var cancellationToken = CancellationToken.None;

            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue1693851089",
                RefreshToken = "TestValue1195688761",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1748001409,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue257360391",
                        FollowersCount = 1040842395,
                        NextStatusId = 765682228,
                        UserTarget = 1514673187,
                        AccountId = 1865196130,
                        Account = default(Account)
                    },
                    Cread = "TestValue2000278423",
                    Photo = "TestValue888588177",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1507702917,
                    User = default(User)
                }
            });
            _followerService.GetFollowingAsync(Arg.Any<int>()).Returns(new List<UserFollower>());
            _followerService.GetFollowersAsync(Arg.Any<int>()).Returns(new List<UserFollower>());
            _postService.GetAllPostsAsync(Arg.Any<User>(), Arg.Any<int>(), Arg.Any<int>()).Returns(new List<Post>());
            _likeService.GetAllLikesAsync(Arg.Any<int>()).Returns(new List<Like>());
            _contextAccessor.HttpContext.Returns(new DefaultHttpContext());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());
            await _followerService.Received().GetFollowingAsync(Arg.Any<int>());
            await _followerService.Received().GetFollowersAsync(Arg.Any<int>());
            await _postService.Received().GetAllPostsAsync(Arg.Any<User>(), Arg.Any<int>(), Arg.Any<int>());
            await _likeService.Received().GetAllLikesAsync(Arg.Any<int>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(GetPostsRequest), CancellationToken.None));
        }
    }
}
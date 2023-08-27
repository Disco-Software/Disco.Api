namespace Disco.ApiServices.Test.Features.Post.RequestHandlers.GetUserPosts
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Post.RequestHandlers.GetUserPosts;
    using Disco.Business.Interfaces.Dtos.Posts;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class GetUserPostsRequestHandlerTests
    {
        private GetUserPostsRequestHandler _testClass;
        private IAccountService _accountService;
        private IPostService _postService;
        private IHttpContextAccessor _contextAccessor;

        [SetUp]
        public void SetUp()
        {
            _accountService = Substitute.For<IAccountService>();
            _postService = Substitute.For<IPostService>();
            _contextAccessor = Substitute.For<IHttpContextAccessor>();
            _testClass = new GetUserPostsRequestHandler(_accountService, _postService, _contextAccessor);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetUserPostsRequestHandler(_accountService, _postService, _contextAccessor);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullAccountService()
        {
            Assert.Throws<ArgumentNullException>(() => new GetUserPostsRequestHandler(default(IAccountService), _postService, _contextAccessor));
        }

        [Test]
        public void CannotConstructWithNullPostService()
        {
            Assert.Throws<ArgumentNullException>(() => new GetUserPostsRequestHandler(_accountService, default(IPostService), _contextAccessor));
        }

        [Test]
        public void CannotConstructWithNullContextAccessor()
        {
            Assert.Throws<ArgumentNullException>(() => new GetUserPostsRequestHandler(_accountService, _postService, default(IHttpContextAccessor)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new GetUserPostsRequest(new GetAllPostsDto
            {
                PageNumber = 1927409118,
                PageSize = 558493955
            });
            var cancellationToken = CancellationToken.None;

            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue1237874131",
                RefreshToken = "TestValue1057039366",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1324695121,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1624295548",
                        FollowersCount = 1257736551,
                        NextStatusId = 386719553,
                        UserTarget = 1284745728,
                        AccountId = 1565157372,
                        Account = default(Account)
                    },
                    Cread = "TestValue2084233667",
                    Photo = "TestValue1793822790",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 17219498,
                    User = default(User)
                }
            });
            _postService.GetAllUserPosts(Arg.Any<User>(), Arg.Any<GetAllPostsDto>()).Returns(new List<Post>());
            _contextAccessor.HttpContext.Returns(new DefaultHttpContext());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());
            await _postService.Received().GetAllUserPosts(Arg.Any<User>(), Arg.Any<GetAllPostsDto>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(GetUserPostsRequest), CancellationToken.None));
        }
    }
}
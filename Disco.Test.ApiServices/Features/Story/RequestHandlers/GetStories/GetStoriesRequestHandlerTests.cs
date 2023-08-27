namespace Disco.ApiServices.Test.Features.Story.RequestHandlers.GetStories
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Story.RequestHandlers.GetStories;
    using Disco.Business.Interfaces.Dtos.Stories;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class GetStoriesRequestHandlerTests
    {
        private GetStoriesRequestHandler _testClass;
        private IAccountService _accountService;
        private IStoryService _storyService;
        private IHttpContextAccessor _contextAccessor;

        [SetUp]
        public void SetUp()
        {
            _accountService = Substitute.For<IAccountService>();
            _storyService = Substitute.For<IStoryService>();
            _contextAccessor = Substitute.For<IHttpContextAccessor>();
            _testClass = new GetStoriesRequestHandler(_accountService, _storyService, _contextAccessor);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetStoriesRequestHandler(_accountService, _storyService, _contextAccessor);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullAccountService()
        {
            Assert.Throws<ArgumentNullException>(() => new GetStoriesRequestHandler(default(IAccountService), _storyService, _contextAccessor));
        }

        [Test]
        public void CannotConstructWithNullStoryService()
        {
            Assert.Throws<ArgumentNullException>(() => new GetStoriesRequestHandler(_accountService, default(IStoryService), _contextAccessor));
        }

        [Test]
        public void CannotConstructWithNullContextAccessor()
        {
            Assert.Throws<ArgumentNullException>(() => new GetStoriesRequestHandler(_accountService, _storyService, default(IHttpContextAccessor)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new GetStoriesRequest(new GetAllStoriesDto
            {
                PageNumber = 1350554847,
                PageSize = 559491514
            });
            var cancellationToken = CancellationToken.None;

            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue1123981367",
                RefreshToken = "TestValue439800231",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1518693281,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue716330543",
                        FollowersCount = 807778349,
                        NextStatusId = 1589560723,
                        UserTarget = 322131533,
                        AccountId = 374475007,
                        Account = default(Account)
                    },
                    Cread = "TestValue1864621502",
                    Photo = "TestValue1183805384",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1447181695,
                    User = default(User)
                }
            });
            _contextAccessor.HttpContext.Returns(new DefaultHttpContext());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(GetStoriesRequest), CancellationToken.None));
        }
    }
}
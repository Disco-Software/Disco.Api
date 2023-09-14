namespace Disco.Test.ApiServices.Features.AccountDetails.User.RequestHandlers.GetCurrentUser
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.GetCurrentUser;
    using Disco.Business.Interfaces.Dtos.AccountDetails;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class GetCurrentUserRequestHandlerTests
    {
        private GetCurrentUserRequestHandler _testClass;
        private IAccountService _accountService;
        private IAccountDetailsService _accountDetailsService;
        private IPostService _postService;
        private IFollowerService _followerService;
        private IHttpContextAccessor _contextAccessor;

        [SetUp]
        public void SetUp()
        {
            _accountService = Substitute.For<IAccountService>();
            _accountDetailsService = Substitute.For<IAccountDetailsService>();
            _postService = Substitute.For<IPostService>();
            _followerService = Substitute.For<IFollowerService>();
            _contextAccessor = Substitute.For<IHttpContextAccessor>();
            _testClass = new GetCurrentUserRequestHandler(_accountService, _accountDetailsService, _postService, _followerService, _contextAccessor);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetCurrentUserRequestHandler(_accountService, _accountDetailsService, _postService, _followerService, _contextAccessor);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new GetCurrentUserRequest();
            var cancellationToken = CancellationToken.None;

            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue1598239775",
                RefreshToken = "TestValue1019847749",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 511866080,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue2082605889",
                        FollowersCount = 1560996251,
                        NextStatusId = 1810335209,
                        UserTarget = 774923673,
                        AccountId = 1321571870,
                        Account = default(Account)
                    },
                    Cread = "TestValue1507221445",
                    Photo = "TestValue1658851549",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1257831132,
                    User = default(User)
                }
            });
            _accountDetailsService.GetUserDatailsAsync(Arg.Any<User>()).Returns(new UserDetailsResponseDto
            {
                User = new User
                {
                    RoleName = "TestValue445787323",
                    RefreshToken = "TestValue1738442236",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1220625949,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1175125733",
                            FollowersCount = 1504283473,
                            NextStatusId = 1971555,
                            UserTarget = 948262269,
                            AccountId = 533022987,
                            Account = default(Account)
                        },
                        Cread = "TestValue237766722",
                        Photo = "TestValue1108195934",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 17338376,
                        User = default(User)
                    }
                }
            });
            _postService.GetAllUserPosts(Arg.Any<User>()).Returns(new List<Post>());
            _followerService.GetFollowingAsync(Arg.Any<int>()).Returns(new List<UserFollower>());
            _followerService.GetFollowersAsync(Arg.Any<int>()).Returns(new List<UserFollower>());
            _contextAccessor.HttpContext.Returns(new DefaultHttpContext());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());
            await _accountDetailsService.Received().GetUserDatailsAsync(Arg.Any<User>());
            await _postService.Received().GetAllUserPosts(Arg.Any<User>());
            await _followerService.Received().GetFollowingAsync(Arg.Any<int>());
            await _followerService.Received().GetFollowersAsync(Arg.Any<int>());
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(GetCurrentUserRequest), CancellationToken.None));
        }
    }
}
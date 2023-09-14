namespace Disco.Test.ApiServices.Features.Follower.RequestHandlers.GetRecomended
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Follower.RequestHandlers.GetRecomended;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class GetRecomendedRequestHandlerTests
    {
        private GetRecomendedRequestHandler _testClass;
        private IFollowerService _followerService;
        private IAccountService _accountService;
        private IHttpContextAccessor _contextAccessor;

        [SetUp]
        public void SetUp()
        {
            _followerService = Substitute.For<IFollowerService>();
            _accountService = Substitute.For<IAccountService>();
            _contextAccessor = Substitute.For<IHttpContextAccessor>();
            _testClass = new GetRecomendedRequestHandler(_followerService, _accountService, _contextAccessor);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetRecomendedRequestHandler(_followerService, _accountService, _contextAccessor);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new GetRecomendedRequest();
            var cancellationToken = CancellationToken.None;

            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue1543336135",
                RefreshToken = "TestValue2031956771",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1848134010,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1198959109",
                        FollowersCount = 1754685444,
                        NextStatusId = 449511712,
                        UserTarget = 53564033,
                        AccountId = 901652962,
                        Account = default(Account)
                    },
                    Cread = "TestValue624472545",
                    Photo = "TestValue900583778",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 413126843,
                    User = default(User)
                }
            });
            _accountService.GetByAccountIdAsync(Arg.Any<int>()).Returns(new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue445670935",
                    FollowersCount = 2119251917,
                    NextStatusId = 1823510034,
                    UserTarget = 1505286812,
                    AccountId = 1038216860,
                    Account = default(Account)
                },
                Cread = "TestValue2007057369",
                Photo = "TestValue15267261",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 690754449,
                User = new User
                {
                    RoleName = "TestValue1246824315",
                    RefreshToken = "TestValue219759945",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 2077629812,
                    Account = default(Account)
                }
            });
            _contextAccessor.HttpContext.Returns(new DefaultHttpContext());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());
            await _accountService.Received(0).GetByAccountIdAsync(Arg.Any<int>());
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(GetRecomendedRequest), CancellationToken.None));
        }
    }
}
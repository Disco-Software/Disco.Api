namespace Disco.Test.ApiServices.Features.Follower.RequestHandlers.GetFollower
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Follower.RequestHandlers.GetFollower;
    using Disco.Business.Interfaces.Dtos.Followers;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class GetFollowerRequestHandlerTests
    {
        private GetFollowerRequestHandler _testClass;
        private IFollowerService _followerService;

        [SetUp]
        public void SetUp()
        {
            _followerService = Substitute.For<IFollowerService>();
            _testClass = new GetFollowerRequestHandler(_followerService);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetFollowerRequestHandler(_followerService);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullFollowerService()
        {
            Assert.Throws<ArgumentNullException>(() => new GetFollowerRequestHandler(default(IFollowerService)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new GetFollowerRequest(1171410765);
            var cancellationToken = CancellationToken.None;

            _followerService.GetAsync(Arg.Any<int>()).Returns(new FollowerResponseDto
            {
                FollowingAccount = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1063197448",
                        FollowersCount = 95982879,
                        NextStatusId = 1960538888,
                        UserTarget = 1868257125,
                        AccountId = 346896739,
                        Account = default(Account)
                    },
                    Cread = "TestValue63854663",
                    Photo = "TestValue1293714934",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 784925857,
                    User = new User
                    {
                        RoleName = "TestValue823941442",
                        RefreshToken = "TestValue129939844",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2093162386,
                        Account = default(Account)
                    }
                },
                FollowerAccount = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue997540111",
                        FollowersCount = 139182628,
                        NextStatusId = 590948338,
                        UserTarget = 805869083,
                        AccountId = 1778853063,
                        Account = default(Account)
                    },
                    Cread = "TestValue1605665239",
                    Photo = "TestValue1896082397",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 695179243,
                    User = new User
                    {
                        RoleName = "TestValue591644649",
                        RefreshToken = "TestValue440222796",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 276481343,
                        Account = default(Account)
                    }
                },
                IsFollowing = false
            });

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _followerService.Received().GetAsync(Arg.Any<int>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(GetFollowerRequest), CancellationToken.None));
        }
    }
}
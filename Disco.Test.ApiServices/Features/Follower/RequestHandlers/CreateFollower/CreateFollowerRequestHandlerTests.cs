namespace Disco.Test.ApiServices.Features.Follower.RequestHandlers.CreateFollower
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Follower.RequestHandlers.CreateFollower;
    using Disco.Business.Interfaces.Dtos.Followers;
    using Disco.Business.Interfaces.Dtos.Friends;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class CreateFollowerRequestHandlerTests
    {
        private CreateFollowerRequestHandler _testClass;
        private IAccountService _accountService;
        private IFollowerService _followerService;
        private IHttpContextAccessor _contextAccessor;

        [SetUp]
        public void SetUp()
        {
            _accountService = Substitute.For<IAccountService>();
            _followerService = Substitute.For<IFollowerService>();
            _contextAccessor = Substitute.For<IHttpContextAccessor>();
            _testClass = new CreateFollowerRequestHandler(_accountService, _followerService, _contextAccessor);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new CreateFollowerRequestHandler(_accountService, _followerService, _contextAccessor);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new CreateFollowerRequest(new CreateFollowerDto
            {
                FollowingAccountId = 2012698060,
                IntalationId = "TestValue1894185631"
            });
            var cancellationToken = CancellationToken.None;

            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue1238451750",
                RefreshToken = "TestValue2134612969",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1720692626,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1830617743",
                        FollowersCount = 1816490422,
                        NextStatusId = 739633028,
                        UserTarget = 491596777,
                        AccountId = 2080797233,
                        Account = default(Account)
                    },
                    Cread = "TestValue1988588180",
                    Photo = "TestValue626582265",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2081762620,
                    User = default(User)
                }
            });
            _accountService.GetByIdAsync(Arg.Any<int>()).Returns(new User
            {
                RoleName = "TestValue1614415518",
                RefreshToken = "TestValue1725342034",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 302609327,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue899324662",
                        FollowersCount = 1713762455,
                        NextStatusId = 1919645282,
                        UserTarget = 1561524590,
                        AccountId = 1083981828,
                        Account = default(Account)
                    },
                    Cread = "TestValue461072755",
                    Photo = "TestValue320849661",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 786111500,
                    User = default(User)
                }
            });
            _followerService.CreateAsync(Arg.Any<User>(), Arg.Any<User>(), Arg.Any<CreateFollowerDto>()).Returns(new FollowerResponseDto
            {
                FollowingAccount = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue596268698",
                        FollowersCount = 1295906871,
                        NextStatusId = 212111152,
                        UserTarget = 1958040294,
                        AccountId = 1414883935,
                        Account = default(Account)
                    },
                    Cread = "TestValue1859602706",
                    Photo = "TestValue952142717",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1416567141,
                    User = new User
                    {
                        RoleName = "TestValue1014779573",
                        RefreshToken = "TestValue1314534298",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 468262035,
                        Account = default(Account)
                    }
                },
                FollowerAccount = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue490408680",
                        FollowersCount = 1258209333,
                        NextStatusId = 1169713687,
                        UserTarget = 2030450994,
                        AccountId = 1367105341,
                        Account = default(Account)
                    },
                    Cread = "TestValue553629371",
                    Photo = "TestValue2063877389",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1219700514,
                    User = new User
                    {
                        RoleName = "TestValue1405135860",
                        RefreshToken = "TestValue690128621",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 783213457,
                        Account = default(Account)
                    }
                },
                IsFollowing = true
            });
            _contextAccessor.HttpContext.Returns(new DefaultHttpContext());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());
            await _accountService.Received().GetByIdAsync(Arg.Any<int>());
            await _followerService.Received().CreateAsync(Arg.Any<User>(), Arg.Any<User>(), Arg.Any<CreateFollowerDto>());
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(CreateFollowerRequest), CancellationToken.None));
        }
    }
}
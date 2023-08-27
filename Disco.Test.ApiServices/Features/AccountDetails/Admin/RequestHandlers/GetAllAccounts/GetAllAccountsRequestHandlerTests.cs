namespace Disco.Test.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAllAccounts
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAllAccounts;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class GetAllAccountsRequestHandlerTests
    {
        private GetAllAccountsRequestHandler _testClass;
        private IAccountDetailsService _accountDetailsService;

        [SetUp]
        public void SetUp()
        {
            _accountDetailsService = Substitute.For<IAccountDetailsService>();
            _testClass = new GetAllAccountsRequestHandler(_accountDetailsService);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetAllAccountsRequestHandler(_accountDetailsService);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullAccountDetailsService()
        {
            Assert.Throws<ArgumentNullException>(() => new GetAllAccountsRequestHandler(default(IAccountDetailsService)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new GetAllAccountsRequest(642563253, 876954488);
            var cancellationToken = CancellationToken.None;

            _accountDetailsService.GetAllAsync(Arg.Any<int>(), Arg.Any<int>()).Returns(new[] {
                new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue66885395",
                        FollowersCount = 1089219908,
                        NextStatusId = 1301682135,
                        UserTarget = 1850573194,
                        AccountId = 443331543,
                        Account = default(Account)
                    },
                    Cread = "TestValue1689861118",
                    Photo = "TestValue125625953",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 240117171,
                    User = new User
                    {
                        RoleName = "TestValue1982359457",
                        RefreshToken = "TestValue1301958607",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 913874312,
                        Account = default(Account)
                    }
                },
                new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue431255296",
                        FollowersCount = 365699498,
                        NextStatusId = 163480073,
                        UserTarget = 782300868,
                        AccountId = 1614139377,
                        Account = default(Account)
                    },
                    Cread = "TestValue781344633",
                    Photo = "TestValue447418128",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 767983981,
                    User = new User
                    {
                        RoleName = "TestValue1528764560",
                        RefreshToken = "TestValue771521392",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1996500113,
                        Account = default(Account)
                    }
                },
                new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1537666734",
                        FollowersCount = 2012025016,
                        NextStatusId = 1345802855,
                        UserTarget = 1662114167,
                        AccountId = 2058036997,
                        Account = default(Account)
                    },
                    Cread = "TestValue1651963382",
                    Photo = "TestValue85336697",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1972506125,
                    User = new User
                    {
                        RoleName = "TestValue2025911416",
                        RefreshToken = "TestValue935930788",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 564107937,
                        Account = default(Account)
                    }
                }
            });

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountDetailsService.Received().GetAllAsync(Arg.Any<int>(), Arg.Any<int>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(GetAllAccountsRequest), CancellationToken.None));
        }
    }
}
namespace Disco.Test.Domain.Repositories.Test
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Disco.Domain.EF;
    using Disco.Domain.Models.Models;
    using Disco.Domain.Repositories.Repositories;
    using NUnit.Framework;

    [TestFixture]
    public class UserRepositoryTests
    {
        private UserRepository _testClass;
        private ApiDbContext _ctx;

        [SetUp]
        public void SetUp()
        {
            _ctx = new ApiDbContext();
            _testClass = new UserRepository(_ctx);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new UserRepository(_ctx);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullCtx()
        {
            Assert.Throws<ArgumentNullException>(() => new UserRepository(default(ApiDbContext)));
        }

        [Test]
        public async Task CanCallGetUserByRefreshTokenAsync()
        {
            // Arrange
            var refreshToken = "TestValue1356262726";

            // Act
            var result = await _testClass.GetUserByRefreshTokenAsync(refreshToken);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallGetUserByRefreshTokenAsyncWithInvalidRefreshToken(string value)
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.GetUserByRefreshTokenAsync(value));
        }

        [Test]
        public async Task GetUserByRefreshTokenAsyncPerformsMapping()
        {
            // Arrange
            var refreshToken = "TestValue1930471122";

            // Act
            var result = await _testClass.GetUserByRefreshTokenAsync(refreshToken);

            // Assert
            Assert.That(result.RefreshToken, Is.SameAs(refreshToken));
        }

        [Test]
        public async Task CanCallGetUserAccountAsync()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue1309478103",
                RefreshToken = "TestValue387805277",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1201594692,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue642307175",
                        FollowersCount = 1336680708,
                        NextStatusId = 94061513,
                        UserTarget = 176425444,
                        AccountId = 369265535,
                        Account = default(Account)
                    },
                    Cread = "TestValue2049430939",
                    Photo = "TestValue1120119782",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 550344057,
                    User = default(User)
                }
            };

            // Act
            await _testClass.GetUserAccountAsync(user);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallGetUserAccountAsyncWithNullUser()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.GetUserAccountAsync(default(User)));
        }

        [Test]
        public void CanCallGetUserRole()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue2085771049",
                RefreshToken = "TestValue862484046",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1880560070,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue27653646",
                        FollowersCount = 952112000,
                        NextStatusId = 1005080458,
                        UserTarget = 557163727,
                        AccountId = 1967284889,
                        Account = default(Account)
                    },
                    Cread = "TestValue76148225",
                    Photo = "TestValue1537379719",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1456065739,
                    User = default(User)
                }
            };

            // Act
            var result = _testClass.GetUserRole(user);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallGetUserRoleWithNullUser()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.GetUserRole(default(User)));
        }

        [Test]
        public async Task CanCallSaveRefreshTokenAsync()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue819182670",
                RefreshToken = "TestValue1409812745",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 419940009,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1817984293",
                        FollowersCount = 1437826790,
                        NextStatusId = 1090738075,
                        UserTarget = 1013681679,
                        AccountId = 2088583824,
                        Account = default(Account)
                    },
                    Cread = "TestValue521484667",
                    Photo = "TestValue642597654",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1112765174,
                    User = default(User)
                }
            };
            var refreshToken = "TestValue1861133920";

            // Act
            await _testClass.SaveRefreshTokenAsync(user, refreshToken);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallSaveRefreshTokenAsyncWithNullUser()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.SaveRefreshTokenAsync(default(User), "TestValue1292479566"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallSaveRefreshTokenAsyncWithInvalidRefreshToken(string value)
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.SaveRefreshTokenAsync(new User
            {
                RoleName = "TestValue2110400538",
                RefreshToken = "TestValue1534088161",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1800790882,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue843220504",
                        FollowersCount = 1929948460,
                        NextStatusId = 1255446006,
                        UserTarget = 390061619,
                        AccountId = 588436371,
                        Account = default(Account)
                    },
                    Cread = "TestValue689142448",
                    Photo = "TestValue1582997244",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 922716200,
                    User = default(User)
                }
            }, value));
        }

        [Test]
        public async Task CanCallGetAllUsers()
        {
            // Arrange
            var pageNumber = 1634261163;
            var pageSize = 972441582;

            // Act
            var result = await _testClass.GetAllUsers(pageNumber, pageSize);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public async Task CanCallGetUsersByPeriotAsync()
        {
            // Arrange
            var date = DateTime.UtcNow;

            // Act
            var result = await _testClass.GetUsersByPeriotAsync(date);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public async Task CanCallGetUsersByPeriotIntAsync()
        {
            // Arrange
            var days = 2055963536;

            // Act
            var result = await _testClass.GetUsersByPeriotIntAsync(days);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public async Task CanCallGetAllUsersAsyncWithNoParameters()
        {
            // Act
            var result = await _testClass.GetAllUsersAsync();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public async Task CanCallGetAllUsersAsyncWithFromAndTo()
        {
            // Arrange
            var @from = DateTime.UtcNow;
            var to = DateTime.UtcNow;

            // Act
            var result = await _testClass.GetAllUsersAsync(from, to);

            // Assert
            Assert.Fail("Create or modify test");
        }
    }
}
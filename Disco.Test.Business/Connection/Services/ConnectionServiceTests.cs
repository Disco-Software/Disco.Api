namespace Disco.Test.Business.Connection.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Disco.Business.Exceptions;
    using Disco.Business.Services.Services;
    using Disco.Domain.Interfaces;
    using Disco.Domain.Models.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ConnectionServiceTests
    {
        private ConnectionService _testClass;
        private Mock<IConnectionRepository> _connectionRepository;

        [SetUp]
        public void SetUp()
        {
            _connectionRepository = new Mock<IConnectionRepository>();
            _testClass = new ConnectionService(_connectionRepository.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new ConnectionService(_connectionRepository.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreateAsync()
        {
            // Arrange
            var connection = new Connection
            {
                UserAgent = "TestValue1427535524",
                IsConnected = true
            };
            var account = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1122869829",
                    FollowersCount = 2044968691,
                    NextStatusId = 718582271,
                    UserTarget = 472386395,
                    AccountId = 704151739,
                    Account = default
                },
                Cread = "TestValue415805664",
                Photo = "TestValue1690195111",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 699694513,
                User = new User
                {
                    RoleName = "TestValue1287652093",
                    RefreshToken = "TestValue669061797",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1568841174,
                    Account = default
                }
            };

            _connectionRepository.Setup(mock => mock.CreateAsync(It.IsAny<Connection>())).Verifiable();

            // Act
            await _testClass.CreateAsync(connection, account);

            // Assert
            _connectionRepository.Verify(mock => mock.CreateAsync(It.IsAny<Connection>()));
        }

        [Test]
        public void CannotCallCreateAsyncWithNullConnection()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.CreateAsync(default, new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1335129975",
                    FollowersCount = 1960297371,
                    NextStatusId = 993364410,
                    UserTarget = 1999435082,
                    AccountId = 526397828,
                    Account = default
                },
                Cread = "TestValue1175650335",
                Photo = "TestValue353396303",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 121960663,
                User = new User
                {
                    RoleName = "TestValue1456352410",
                    RefreshToken = "TestValue2021842864",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 120394485,
                    Account = default
                }
            }));
        }

        [Test]
        public void CannotCallCreateAsyncWithNullAccount()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.CreateAsync(new Connection
            {
                UserAgent = "TestValue495857514",
                IsConnected = true
            }, default));
        }

        [Test]
        public async Task CanCallDeleteAsync()
        {
            // Arrange
            var connection = new Connection
            {
                UserAgent = "TestValue1225362519",
                IsConnected = true
            };
            var account = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1251832007",
                    FollowersCount = 909842465,
                    NextStatusId = 857370605,
                    UserTarget = 1966497292,
                    AccountId = 1636234936,
                    Account = default
                },
                Cread = "TestValue1622502038",
                Photo = "TestValue1144527529",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 1122334477,
                User = new User
                {
                    RoleName = "TestValue1455074416",
                    RefreshToken = "TestValue583687934",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1474623776,
                    Account = default
                }
            };

            _connectionRepository.Setup(mock => mock.DeleteAsync(It.IsAny<Connection>())).Verifiable();

            // Act
            await _testClass.DeleteAsync(connection, account);

            // Assert
            _connectionRepository.Verify(mock => mock.DeleteAsync(It.IsAny<Connection>()));
        }

        [Test]
        public async Task CanCallGetAsync()
        {
            // Arrange
            var connectionId = "TestValue343710809";

            _connectionRepository.Setup(mock => mock.GetAsync(It.IsAny<string>())).ReturnsAsync(new Connection
            {
                UserAgent = "TestValue629144388",
                IsConnected = true
            });

            // Act
            var result = await _testClass.GetAsync(connectionId);

            // Assert
            _connectionRepository.Verify(mock => mock.GetAsync(It.IsAny<string>()));
        }
    }
}
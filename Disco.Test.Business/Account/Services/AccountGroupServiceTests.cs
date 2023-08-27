namespace Disco.Test.Business.Account.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.Business.Services.Mappers;
    using Disco.Business.Services.Services;
    using Disco.Domain.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class AccountGroupServiceTests
    {
        private AccountGroupService _testClass;
        private Mock<IAccountGroupRepository> _accountGroupRepository;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _accountGroupRepository = new Mock<IAccountGroupRepository>();
            
            var mapper = new MapperConfiguration(x =>
            {
                x.AddProfile(new GroupMapProfile());
            }).CreateMapper() as IMapper;

            _mapper = mapper;

            _testClass = new AccountGroupService(_accountGroupRepository.Object, _mapper);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new AccountGroupService(_accountGroupRepository.Object, _mapper);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreateAsync()
        {
            // Arrange
            var account = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1749854961",
                    FollowersCount = 1655872383,
                    NextStatusId = 809605787,
                    UserTarget = 199476709,
                    AccountId = 1275555712,
                    Account = default
                },
                Cread = "TestValue1567532447",
                Photo = "TestValue370197032",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 143836873,
                User = new User
                {
                    RoleName = "TestValue2135160851",
                    RefreshToken = "TestValue1841625139",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 2092454322,
                    Account = default
                }
            };
            var @group = new Group
            {
                Name = "TestValue715185109",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>()
            };

            _accountGroupRepository.Setup(mock => mock.CreateAsync(It.IsAny<AccountGroup>())).Verifiable();

            // Act
            var result = await _testClass.CreateAsync(account, group);

            // Assert
            _accountGroupRepository.Verify(mock => mock.CreateAsync(It.IsAny<AccountGroup>()));
        }

        [Test]
        public void CannotCallCreateAsyncWithNullAccount()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.CreateAsync(default, new Group
            {
                Name = "TestValue990500166",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>()
            }));
        }

        [Test]
        public void CannotCallCreateAsyncWithNullGroup()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.CreateAsync(new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1313489187",
                    FollowersCount = 915357033,
                    NextStatusId = 1494348312,
                    UserTarget = 1044738938,
                    AccountId = 1521569487,
                    Account = default
                },
                Cread = "TestValue1169060287",
                Photo = "TestValue1445431811",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 1144608374,
                User = new User
                {
                    RoleName = "TestValue1649355031",
                    RefreshToken = "TestValue1338034900",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1797423976,
                    Account = default
                }
            }, default));
        }

        [Test]
        public async Task CreateAsyncPerformsMapping()
        {
            // Arrange
            var account = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1411624631",
                    FollowersCount = 422779253,
                    NextStatusId = 712710517,
                    UserTarget = 826273691,
                    AccountId = 797133304,
                    Account = default
                },
                Cread = "TestValue216008590",
                Photo = "TestValue1536422675",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 452108231,
                User = new User
                {
                    RoleName = "TestValue1154383296",
                    RefreshToken = "TestValue2023342034",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1149766703,
                    Account = default
                }
            };
            var @group = new Group
            {
                Name = "TestValue631206552",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>()
            };

            // Act
            var result = await _testClass.CreateAsync(account, group);

            // Assert
            Assert.AreEqual(result.Account, account);
            Assert.AreEqual(result.Group, @group);
        }

        [Test]
        public async Task CanCallDeleteAsync()
        {
            // Arrange
            var accountGroup = new AccountGroup
            {
                AccountId = 641873293,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue265115858",
                        FollowersCount = 1758830599,
                        NextStatusId = 440412515,
                        UserTarget = 1047920797,
                        AccountId = 694607190,
                        Account = default
                    },
                    Cread = "TestValue1674199428",
                    Photo = "TestValue497728811",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 655663704,
                    User = new User
                    {
                        RoleName = "TestValue1325116330",
                        RefreshToken = "TestValue1120511185",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 565885812,
                        Account = default
                    }
                },
                GroupId = 922413524,
                Group = new Group
                {
                    Name = "TestValue163125543",
                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>()
                }
            };

            _accountGroupRepository.Setup(mock => mock.DeleteAsync(It.IsAny<AccountGroup>())).Verifiable();

            // Act
            await _testClass.DeleteAsync(accountGroup);

            // Assert
            _accountGroupRepository.Verify(mock => mock.DeleteAsync(It.IsAny<AccountGroup>()));
        }

        [Test]
        public async Task CanCallGetAsync()
        {
            // Arrange
            var id = 305202464;

            _accountGroupRepository.Setup(mock => mock.GetAsync(It.IsAny<int>())).ReturnsAsync(new AccountGroup
            {
                AccountId = 519828323,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue177576690",
                        FollowersCount = 1090367065,
                        NextStatusId = 916320952,
                        UserTarget = 1552446411,
                        AccountId = 100499930,
                        Account = default
                    },
                    Cread = "TestValue317837483",
                    Photo = "TestValue1159665458",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 935335725,
                    User = new User
                    {
                        RoleName = "TestValue852776459",
                        RefreshToken = "TestValue854821930",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1691406988,
                        Account = default
                    }
                },
                GroupId = 1494187216,
                Group = new Group
                {
                    Name = "TestValue1919152261",
                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>()
                }
            });

            // Act
            var result = await _testClass.GetAsync(id);

            // Assert
            _accountGroupRepository.Verify(mock => mock.GetAsync(It.IsAny<int>()));
        }
    }
}
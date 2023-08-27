namespace Disco.Test.Business.Follower.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.Business.Interfaces.Dtos.Friends;
    using Disco.Business.Services.Mappers;
    using Disco.Business.Services.Services;
    using Disco.Domain.Interfaces;
    using Disco.Domain.Models.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class FollowerServiceTests
    {
        private FollowerService _testClass;
        
        private IMapper _mapper;
        private Mock<IFollowerRepository> _friendRepository;
        private Mock<IAccountRepository> _accountRepository;

        [SetUp]
        public void SetUp()
        {
            var mapper = new MapperConfiguration(x =>
            {
                x.AddProfile(new AccountMapProfile());
                x.AddProfile(new FollowerMapProfile());
            })
                .CreateMapper();

            _mapper = mapper;

            _friendRepository = new Mock<IFollowerRepository>();
            _accountRepository = new Mock<IAccountRepository>();
            _testClass = new FollowerService(_mapper, _friendRepository.Object, _accountRepository.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new FollowerService(_mapper, _friendRepository.Object, _accountRepository.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreateAsync()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue491367560",
                RefreshToken = "TestValue642360006",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1474323088,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1285818589",
                        FollowersCount = 890496136,
                        NextStatusId = 975235506,
                        UserTarget = 1303733902,
                        AccountId = 138131764,
                        Account = default
                    },
                    Cread = "TestValue722142274",
                    Photo = "TestValue1612357655",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1287148931,
                    User = default
                }
            };
            var following = new User
            {
                RoleName = "TestValue909013617",
                RefreshToken = "TestValue508251420",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 910516018,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue125334968",
                        FollowersCount = 1072023475,
                        NextStatusId = 1146576589,
                        UserTarget = 1216209706,
                        AccountId = 1202786129,
                        Account = default
                    },
                    Cread = "TestValue1613086483",
                    Photo = "TestValue1097304870",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 707365374,
                    User = default
                }
            };
            var dto = new CreateFollowerDto
            {
                FollowingAccountId = 134142792,
                IntalationId = "TestValue1097322817"
            };

            _friendRepository.Setup(mock => mock.AddAsync(It.IsAny<UserFollower>()))
                .Verifiable();

            // Act
            var result = await _testClass.CreateAsync(user, following, dto);

            // Assert
            _friendRepository.Verify(mock => mock.AddAsync(It.IsAny<UserFollower>()));
        }

        [Test]
        public void CannotCallCreateAsyncWithNullUser()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.CreateAsync(default, new User
            {
                RoleName = "TestValue1165767066",
                RefreshToken = "TestValue157394262",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1880429364,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue153753527",
                        FollowersCount = 137497759,
                        NextStatusId = 1759862577,
                        UserTarget = 1003812337,
                        AccountId = 1732470895,
                        Account = default
                    },
                    Cread = "TestValue615475511",
                    Photo = "TestValue1063058214",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2068057489,
                    User = default
                }
            }, new CreateFollowerDto
            {
                FollowingAccountId = 1394609105,
                IntalationId = "TestValue1398978977"
            }));
        }

        [Test]
        public void CannotCallCreateAsyncWithNullFollowing()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.CreateAsync(new User
            {
                RoleName = "TestValue1993857660",
                RefreshToken = "TestValue423383626",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 784493566,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue395404940",
                        FollowersCount = 1284982015,
                        NextStatusId = 1951150568,
                        UserTarget = 634669944,
                        AccountId = 2049803349,
                        Account = default
                    },
                    Cread = "TestValue1139528324",
                    Photo = "TestValue75166754",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 47848563,
                    User = default
                }
            }, default, new CreateFollowerDto
            {
                FollowingAccountId = 38866823,
                IntalationId = "TestValue1989228407"
            }));
        }

        [Test]
        public async Task CanCallDeleteAsync()
        {
            // Arrange
            var id = 841387224;

            _friendRepository.Setup(mock => mock.GetAsync(It.IsAny<int>())).ReturnsAsync(new UserFollower
            {
                FollowingAccountId = 792826080,
                FollowingAccount = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue418292563",
                        FollowersCount = 1217681543,
                        NextStatusId = 1959806501,
                        UserTarget = 903698453,
                        AccountId = 1646956495,
                        Account = default
                    },
                    Cread = "TestValue1195003115",
                    Photo = "TestValue26238742",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 82227508,
                    User = new User
                    {
                        RoleName = "TestValue1832580801",
                        RefreshToken = "TestValue114886704",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 295752999,
                        Account = default
                    }
                },
                FollowerAccountId = 1166686846,
                FollowerAccount = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1606191936",
                        FollowersCount = 1789428293,
                        NextStatusId = 1983396,
                        UserTarget = 1553714357,
                        AccountId = 136571656,
                        Account = default
                    },
                    Cread = "TestValue886391891",
                    Photo = "TestValue1021978706",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1873806137,
                    User = new User
                    {
                        RoleName = "TestValue1837765399",
                        RefreshToken = "TestValue1689687424",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1392908212,
                        Account = default
                    }
                },
                IsFollowing = true
            });
            _friendRepository.Setup(mock => mock.Remove(It.IsAny<UserFollower>())).Verifiable();

            // Act
            await _testClass.DeleteAsync(id);

            // Assert
            _friendRepository.Verify(mock => mock.GetAsync(It.IsAny<int>()));
            _friendRepository.Verify(mock => mock.Remove(It.IsAny<UserFollower>()));
        }

        [Test]
        public async Task CanCallGetFollowingAsyncWithInt()
        {
            // Arrange
            var accountId = 26124626;

            _friendRepository.Setup(mock => mock.GetFollowingAsync(It.IsAny<int>())).ReturnsAsync(new List<UserFollower>());

            // Act
            var result = await _testClass.GetFollowingAsync(accountId);

            // Assert
            Assert.IsNotNull(result);

            _friendRepository.Verify(mock => mock.GetFollowingAsync(It.IsAny<int>()));
        }

        [Test]
        public async Task CanCallGetAsync()
        {
            // Arrange
            var id = 2139301266;

            _friendRepository.Setup(mock => mock.GetAsync(It.IsAny<int>())).ReturnsAsync(new UserFollower
            {
                FollowingAccountId = 347641666,
                FollowingAccount = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue845990218",
                        FollowersCount = 629973548,
                        NextStatusId = 1205390034,
                        UserTarget = 1308140960,
                        AccountId = 168700262,
                        Account = default
                    },
                    Cread = "TestValue1440456802",
                    Photo = "TestValue752277968",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1672233686,
                    User = new User
                    {
                        RoleName = "TestValue1543294219",
                        RefreshToken = "TestValue1844504650",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1027787380,
                        Account = default
                    }
                },
                FollowerAccountId = 1008744366,
                FollowerAccount = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1329480803",
                        FollowersCount = 93812781,
                        NextStatusId = 650874366,
                        UserTarget = 1557192635,
                        AccountId = 1035093671,
                        Account = default
                    },
                    Cread = "TestValue1852364653",
                    Photo = "TestValue2090560145",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1149837029,
                    User = new User
                    {
                        RoleName = "TestValue2060217037",
                        RefreshToken = "TestValue291554710",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 38962496,
                        Account = default
                    }
                },
                IsFollowing = false
            });

            // Act
            var result = await _testClass.GetAsync(id);

            // Assert
            Assert.IsNotNull(result);

            _friendRepository.Verify(mock => mock.GetAsync(It.IsAny<int>()));
        }

        [Test]
        public async Task CanCallGetFollowersAsyncWithInt()
        {
            // Arrange
            var accountId = 798549439;

            _friendRepository.Setup(mock => mock.GetFollowersAsync(It.IsAny<int>())).ReturnsAsync(new List<UserFollower>());

            // Act
            var result = await _testClass.GetFollowersAsync(accountId);

            // Assert
            Assert.IsNotNull(result);

            _friendRepository.Verify(mock => mock.GetFollowersAsync(It.IsAny<int>()));
        }

        [Test]
        public async Task CanCallGetFollowingAsyncWithUserIdAndPageNumberAndPageSize()
        {
            // Arrange
            var userId = 1573880086;
            var pageNumber = 1102544328;
            var pageSize = 876088786;

            _friendRepository.Setup(mock => mock.GetFollowingAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new List<UserFollower>());

            // Act
            var result = await _testClass.GetFollowingAsync(userId, pageNumber, pageSize);

            // Assert
            Assert.IsNotNull(result);
            _friendRepository.Verify(mock => mock.GetFollowingAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
        }

        [Test]
        public async Task CanCallGetFollowersAsyncWithAccountIdAndPageNumberAndPageSize()
        {
            // Arrange
            var accountId = 1972256978;
            var pageNumber = 675458490;
            var pageSize = 62311229;

            _friendRepository.Setup(mock => mock.GetFollowersAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new List<UserFollower>());

            // Act
            var result = await _testClass.GetFollowersAsync(accountId, pageNumber, pageSize);

            // Assert
            Assert.IsNotNull(result);

            _friendRepository.Verify(mock => mock.GetFollowersAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
        }
    }
}
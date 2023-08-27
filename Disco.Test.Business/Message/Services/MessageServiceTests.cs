namespace Disco.Test.Business.Message.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.Business.Services.Mappers;
    using Disco.Business.Services.Services;
    using Disco.Domain.Interfaces;
    using Disco.Domain.Models.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class MessageServiceTests
    {
        private MessageService _testClass;
        private IMapper _mapper;


        private Mock<IMessageRepository> _messageRepository;

        [SetUp]
        public void SetUp()
        {
            _messageRepository = new Mock<IMessageRepository>();

            _mapper = new MapperConfiguration(x =>
            {
                x.AddProfile(new MessageMapProfile());
            }).CreateMapper();

            _testClass = new MessageService(_messageRepository.Object, _mapper);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new MessageService(_messageRepository.Object, _mapper);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreateAsync()
        {
            // Arrange
            var textMessage = "TestValue1271425977";
            var account = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1907391667",
                    FollowersCount = 67080131,
                    NextStatusId = 1138540462,
                    UserTarget = 2009834301,
                    AccountId = 809933590,
                    Account = default
                },
                Cread = "TestValue539069860",
                Photo = "TestValue1166333743",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 1878776223,
                User = new User
                {
                    RoleName = "TestValue1433552121",
                    RefreshToken = "TestValue648475332",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1381077610,
                    Account = default
                }
            };
            var @group = new Group
            {
                Name = "TestValue1042712462",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>()
            };

            _messageRepository.Setup(mock => mock.CreateAsync(It.IsAny<Message>(), It.IsAny<CancellationToken>())).Verifiable();

            // Act
            var result = await _testClass.CreateAsync(textMessage, account, group);

            // Assert
            _messageRepository.Verify(mock => mock.CreateAsync(It.IsAny<Message>(), It.IsAny<CancellationToken>()));
        }

        [Test]
        public void CannotCallCreateAsyncWithNullAccount()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.CreateAsync("TestValue1681766923", default, new Group
            {
                Name = "TestValue2065915824",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>()
            }));
        }

        [Test]
        public void CannotCallCreateAsyncWithNullGroup()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.CreateAsync("TestValue255838328", new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1536442270",
                    FollowersCount = 1356893721,
                    NextStatusId = 913199987,
                    UserTarget = 1759006027,
                    AccountId = 1277638522,
                    Account = default
                },
                Cread = "TestValue617426976",
                Photo = "TestValue1123799039",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 1632688235,
                User = new User
                {
                    RoleName = "TestValue1378603525",
                    RefreshToken = "TestValue560701513",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 505915016,
                    Account = default
                }
            }, default));
        }

        [TestCase(null)]
        [TestCase("")]
        public void CannotCallCreateAsyncWithInvalidTextMessage(string value)
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.CreateAsync(value, new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1423034945",
                    FollowersCount = 1540167692,
                    NextStatusId = 1467173282,
                    UserTarget = 223265890,
                    AccountId = 752368686,
                    Account = default
                },
                Cread = "TestValue1025235270",
                Photo = "TestValue326631388",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 96183124,
                User = new User
                {
                    RoleName = "TestValue1465317748",
                    RefreshToken = "TestValue297100582",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1915815675,
                    Account = default
                }
            }, new Group
            {
                Name = "TestValue620055520",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>()
            }));
        }

        [Test]
        public async Task CreateAsyncPerformsMapping()
        {
            // Arrange
            var textMessage = "TestValue1602248454";
            var account = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue18445769",
                    FollowersCount = 803512322,
                    NextStatusId = 2004276241,
                    UserTarget = 326223752,
                    AccountId = 731725431,
                    Account = default
                },
                Cread = "TestValue1640064893",
                Photo = "TestValue416993763",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 506260084,
                User = new User
                {
                    RoleName = "TestValue364011288",
                    RefreshToken = "TestValue341743482",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 325760957,
                    Account = default
                }
            };
            var @group = new Group
            {
                Name = "TestValue1344522480",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>()
            };

            // Act
            var result = await _testClass.CreateAsync(textMessage, account, group);

            // Assert
            Assert.That(result.Account, Is.SameAs(account));
            Assert.That(result.Group, Is.SameAs(group));
        }

        [Test]
        public async Task CanCallDeleteAsync()
        {
            // Arrange
            var message = new Message
            {
                AccountId = 1037009384,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue865825128",
                        FollowersCount = 44380141,
                        NextStatusId = 653999001,
                        UserTarget = 783592628,
                        AccountId = 581875543,
                        Account = default
                    },
                    Cread = "TestValue1907420584",
                    Photo = "TestValue1449132788",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 304018574,
                    User = new User
                    {
                        RoleName = "TestValue1263518562",
                        RefreshToken = "TestValue1773649698",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 411602941,
                        Account = default
                    }
                },
                Description = "TestValue1210286231",
                CreatedDate = DateTime.UtcNow,
                GroupId = 2043590293,
                Group = new Group
                {
                    Name = "TestValue355842340",
                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>()
                }
            };

            _messageRepository.Setup(mock => mock.DeleteAsync(It.IsAny<Message>(), It.IsAny<CancellationToken>())).Verifiable();

            // Act
            await _testClass.DeleteAsync(message);

            // Assert
            _messageRepository.Verify(mock => mock.DeleteAsync(It.IsAny<Message>(), It.IsAny<CancellationToken>()));
        }

        [Test]
        public void CannotCallDeleteAsyncWithNullMessage()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.DeleteAsync(default));
        }

        [Test]
        public async Task CanCallGetAllAsync()
        {
            // Arrange
            var groupId = 716081074;
            var pageNumber = 1585583799;
            var pageSize = 600598076;

            _messageRepository.Setup(mock => mock.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new List<Message>());

            // Act
            var result = await _testClass.GetAllAsync(groupId, pageNumber, pageSize);

            // Assert
            _messageRepository.Verify(mock => mock.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
        }

        [Test]
        public async Task CanCallGetByIdAsync()
        {
            // Arrange
            var id = 1026227057;

            _messageRepository.Setup(mock => mock.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Message
            {
                AccountId = 2106221393,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1768110242",
                        FollowersCount = 736838201,
                        NextStatusId = 1458435180,
                        UserTarget = 1740560258,
                        AccountId = 474126200,
                        Account = default
                    },
                    Cread = "TestValue760634382",
                    Photo = "TestValue797575287",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 900962804,
                    User = new User
                    {
                        RoleName = "TestValue1886022279",
                        RefreshToken = "TestValue143707750",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2147138579,
                        Account = default
                    }
                },
                Description = "TestValue1059023657",
                CreatedDate = DateTime.UtcNow,
                GroupId = 1198424210,
                Group = new Group
                {
                    Name = "TestValue1141412325",
                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>()
                }
            });

            // Act
            var result = await _testClass.GetByIdAsync(id);

            // Assert
            _messageRepository.Verify(mock => mock.GetByIdAsync(It.IsAny<int>()));
        }

        [Test]
        public async Task CanCallUpdateAsync()
        {
            // Arrange
            var message = new Message
            {
                AccountId = 1862842949,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue159410142",
                        FollowersCount = 282251247,
                        NextStatusId = 1589667770,
                        UserTarget = 681725120,
                        AccountId = 1862708686,
                        Account = default
                    },
                    Cread = "TestValue8395091",
                    Photo = "TestValue1318406379",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1298229880,
                    User = new User
                    {
                        RoleName = "TestValue902410854",
                        RefreshToken = "TestValue1177346271",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1592673300,
                        Account = default
                    }
                },
                Description = "TestValue1263421168",
                CreatedDate = DateTime.UtcNow,
                GroupId = 835618785,
                Group = new Group
                {
                    Name = "TestValue1284222553",
                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>()
                }
            };

            _messageRepository.Setup(mock => mock.UpdateAsync(It.IsAny<Message>(), It.IsAny<CancellationToken>())).Verifiable();

            // Act
            await _testClass.UpdateAsync(message);

            // Assert
            _messageRepository.Verify(mock => mock.UpdateAsync(It.IsAny<Message>(), It.IsAny<CancellationToken>()));
        }
    }
}
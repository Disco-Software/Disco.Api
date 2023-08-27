namespace Disco.Test.ApiServices.Hubs
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.ApiServices.Hubs;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class ChatHubTests
    {
        private ChatHub _testClass;
        
        private IGroupService _groupService;
        private IMessageService _messageService;
        private IConnectionService _connectionService;
        private IAccountService _accountService;
        private IAccountGroupService _accountGroupService;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _groupService = Substitute.For<IGroupService>();
            _messageService = Substitute.For<IMessageService>();
            _connectionService = Substitute.For<IConnectionService>();
            _accountService = Substitute.For<IAccountService>();
            _accountGroupService = Substitute.For<IAccountGroupService>();
            _mapper = Substitute.For<IMapper>();
            _testClass = new ChatHub(_groupService, _messageService, _connectionService, _accountService, _accountGroupService, _mapper);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new ChatHub(_groupService, _messageService, _connectionService, _accountService, _accountGroupService, _mapper);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullGroupService()
        {
            Assert.Throws<ArgumentNullException>(() => new ChatHub(default(IGroupService), _messageService, _connectionService, _accountService, _accountGroupService, _mapper));
        }

        [Test]
        public void CannotConstructWithNullMessageService()
        {
            Assert.Throws<ArgumentNullException>(() => new ChatHub(_groupService, default(IMessageService), _connectionService, _accountService, _accountGroupService, _mapper));
        }

        [Test]
        public void CannotConstructWithNullConnectionService()
        {
            Assert.Throws<ArgumentNullException>(() => new ChatHub(_groupService, _messageService, default(IConnectionService), _accountService, _accountGroupService, _mapper));
        }

        [Test]
        public void CannotConstructWithNullAccountService()
        {
            Assert.Throws<ArgumentNullException>(() => new ChatHub(_groupService, _messageService, _connectionService, default(IAccountService), _accountGroupService, _mapper));
        }

        [Test]
        public void CannotConstructWithNullAccountGroupService()
        {
            Assert.Throws<ArgumentNullException>(() => new ChatHub(_groupService, _messageService, _connectionService, _accountService, default(IAccountGroupService), _mapper));
        }

        [Test]
        public void CannotConstructWithNullMapper()
        {
            Assert.Throws<ArgumentNullException>(() => new ChatHub(_groupService, _messageService, _connectionService, _accountService, _accountGroupService, default(IMapper)));
        }

        [Test]
        public async Task CanCallOnConnectedAsync()
        {
            // Arrange
            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue426681516",
                RefreshToken = "TestValue542537646",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 522192569,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue991853443",
                        FollowersCount = 1663704242,
                        NextStatusId = 2033518798,
                        UserTarget = 628773733,
                        AccountId = 1260486002,
                        Account = default(Account)
                    },
                    Cread = "TestValue824190372",
                    Photo = "TestValue1525767578",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 52035632,
                    User = default(User)
                }
            });

            // Act
            await _testClass.OnConnectedAsync();

            // Assert
            await _connectionService.Received().CreateAsync(Arg.Any<Connection>(), Arg.Any<Account>());
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public async Task CanCallSendAsync()
        {
            // Arrange
            var groupId = 261494882;
            var textMessage = "TestValue1203512646";

            _groupService.GetAsync(Arg.Any<int>()).Returns(new Group
            {
                Name = "TestValue319602675",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>()
            });
            _messageService.CreateAsync(Arg.Any<string>(), Arg.Any<Account>(), Arg.Any<Group>()).Returns(new Message
            {
                AccountId = 857511686,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue342055684",
                        FollowersCount = 1629464539,
                        NextStatusId = 546736705,
                        UserTarget = 993840820,
                        AccountId = 1744965481,
                        Account = default(Account)
                    },
                    Cread = "TestValue1385118550",
                    Photo = "TestValue329858236",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1194134796,
                    User = new User
                    {
                        RoleName = "TestValue2111561593",
                        RefreshToken = "TestValue2048380640",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2013991751,
                        Account = default(Account)
                    }
                },
                Description = "TestValue691223082",
                CreatedDate = DateTime.UtcNow,
                GroupId = 686604316,
                Group = new Group
                {
                    Name = "TestValue1819815090",
                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>()
                }
            });
            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue1319212512",
                RefreshToken = "TestValue1385459997",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1751084771,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1367795248",
                        FollowersCount = 88031649,
                        NextStatusId = 1893119242,
                        UserTarget = 416655670,
                        AccountId = 802987108,
                        Account = default(Account)
                    },
                    Cread = "TestValue1932393099",
                    Photo = "TestValue1128303729",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1868166316,
                    User = default(User)
                }
            });

            // Act
            await _testClass.SendAsync(groupId, textMessage);

            // Assert
            await _groupService.Received().GetAsync(Arg.Any<int>());
            await _messageService.Received().CreateAsync(Arg.Any<string>(), Arg.Any<Account>(), Arg.Any<Group>());
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());

            Assert.Fail("Create or modify test");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallSendAsyncWithInvalidTextMessage(string value)
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.SendAsync(623284348, value));
        }

        [Test]
        public async Task CanCallJoinAsync()
        {
            // Arrange
            var userId = 1771054205;

            _groupService.CreateAsync().Returns(new Group
            {
                Name = "TestValue1151710321",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>()
            });
            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue174348069",
                RefreshToken = "TestValue1193187362",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 242937546,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue144996341",
                        FollowersCount = 11007556,
                        NextStatusId = 850273863,
                        UserTarget = 1426483640,
                        AccountId = 1566722382,
                        Account = default(Account)
                    },
                    Cread = "TestValue590491768",
                    Photo = "TestValue245394807",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 230659609,
                    User = default(User)
                }
            });
            _accountService.GetByIdAsync(Arg.Any<int>()).Returns(new User
            {
                RoleName = "TestValue2055633723",
                RefreshToken = "TestValue2105394493",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 462603570,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue641640653",
                        FollowersCount = 655684465,
                        NextStatusId = 300630361,
                        UserTarget = 977099926,
                        AccountId = 213703708,
                        Account = default(Account)
                    },
                    Cread = "TestValue1457044868",
                    Photo = "TestValue2022509652",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1220589248,
                    User = default(User)
                }
            });
            _accountGroupService.CreateAsync(Arg.Any<Account>(), Arg.Any<Group>()).Returns(new AccountGroup
            {
                AccountId = 157972330,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue2111487630",
                        FollowersCount = 573967080,
                        NextStatusId = 440856016,
                        UserTarget = 1686552223,
                        AccountId = 1844555087,
                        Account = default(Account)
                    },
                    Cread = "TestValue1565916623",
                    Photo = "TestValue1273158151",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1483470599,
                    User = new User
                    {
                        RoleName = "TestValue181605904",
                        RefreshToken = "TestValue1854057535",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 42424475,
                        Account = default(Account)
                    }
                },
                GroupId = 1937213524,
                Group = new Group
                {
                    Name = "TestValue855193278",
                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>()
                }
            });

            // Act
            await _testClass.JoinAsync(userId);

            // Assert
            await _groupService.Received().CreateAsync();
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());
            await _accountService.Received().GetByIdAsync(Arg.Any<int>());
            await _accountGroupService.Received().CreateAsync(Arg.Any<Account>(), Arg.Any<Group>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public async Task CanCallOnDisconnectedAsync()
        {
            // Arrange
            var exception = new Exception();

            _connectionService.GetAsync(Arg.Any<string>()).Returns(new Connection
            {
                UserAgent = "TestValue546226741",
                IsConnected = false
            });
            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue969541227",
                RefreshToken = "TestValue2040212519",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1966221262,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1160593003",
                        FollowersCount = 1122400441,
                        NextStatusId = 2004855687,
                        UserTarget = 1984969166,
                        AccountId = 458744824,
                        Account = default(Account)
                    },
                    Cread = "TestValue340383538",
                    Photo = "TestValue1290752446",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 472619264,
                    User = default(User)
                }
            });

            // Act
            await _testClass.OnDisconnectedAsync(exception);

            // Assert
            await _connectionService.Received().GetAsync(Arg.Any<string>());
            await _connectionService.Received().DeleteAsync(Arg.Any<Connection>(), Arg.Any<Account>());
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallOnDisconnectedAsyncWithNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.OnDisconnectedAsync(default(Exception)));
        }
    }
}
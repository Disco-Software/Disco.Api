namespace Disco.Test.Business.Group.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.Business.Services.Services;
    using Disco.Domain.Interfaces;
    using Disco.Domain.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class GroupServiceTests
    {
        private GroupService _testClass;
        private UserManager<User> _userManager;
        private Mock<IGroupRepository> _groupRepository;
        private Mock<IAccountGroupRepository> _accountGroupRepository;
        private Mock<IAccountRepository> _accountRepository;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void SetUp()
        {
            _userManager = new UserManager<User>(new Mock<IUserStore<User>>().Object, new Mock<IOptions<IdentityOptions>>().Object, new Mock<IPasswordHasher<User>>().Object, new[] { new Mock<IUserValidator<User>>().Object, new Mock<IUserValidator<User>>().Object, new Mock<IUserValidator<User>>().Object }, new[] { new Mock<IPasswordValidator<User>>().Object, new Mock<IPasswordValidator<User>>().Object, new Mock<IPasswordValidator<User>>().Object }, new Mock<ILookupNormalizer>().Object, new IdentityErrorDescriber(), new Mock<IServiceProvider>().Object, new Mock<ILogger<UserManager<User>>>().Object);
            _groupRepository = new Mock<IGroupRepository>();
            _accountGroupRepository = new Mock<IAccountGroupRepository>();
            _accountRepository = new Mock<IAccountRepository>();
            _mapper = new Mock<IMapper>();
            _testClass = new GroupService(_userManager, _groupRepository.Object, _accountGroupRepository.Object, _accountRepository.Object, _mapper.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GroupService(_userManager, _groupRepository.Object, _accountGroupRepository.Object, _accountRepository.Object, _mapper.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreateAsync()
        {
            // Arrange
            _groupRepository.Setup(mock => mock.CreateAsync(It.IsAny<Group>(), It.IsAny<CancellationToken>())).Verifiable();

            // Act
            var result = await _testClass.CreateAsync();

            // Assert
            Assert.IsNotNull(result);

            _groupRepository.Verify(mock => mock.CreateAsync(It.IsAny<Group>(), It.IsAny<CancellationToken>()));
        }

        [Test]
        public async Task CanCallDeleteAsync()
        {
            // Arrange
            var @group = new Group
            {
                Name = "TestValue357193126",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>()
            };
            var account = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1239226380",
                    FollowersCount = 474489076,
                    NextStatusId = 797729950,
                    UserTarget = 1789589242,
                    AccountId = 1453794472,
                    Account = default
                },
                Cread = "TestValue1771918713",
                Photo = "TestValue1895672987",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 1074941278,
                User = new User
                {
                    RoleName = "TestValue2074866315",
                    RefreshToken = "TestValue1541101076",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1337492176,
                    Account = default
                }
            };

            _groupRepository.Setup(mock => mock.DeleteAsync(It.IsAny<Group>(), It.IsAny<CancellationToken>())).Verifiable();
            _accountGroupRepository.Setup(mock => mock.DeleteAsync(It.IsAny<AccountGroup>())).Verifiable();

            // Act
            await _testClass.DeleteAsync(group, account);

            // Assert
            _groupRepository.Verify(mock => mock.DeleteAsync(It.IsAny<Group>(), It.IsAny<CancellationToken>()));
        }

        [Test]
        public void CannotCallDeleteAsyncWithNullGroup()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.DeleteAsync(default, new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1389320043",
                    FollowersCount = 630019878,
                    NextStatusId = 2016696089,
                    UserTarget = 1920567327,
                    AccountId = 2051726688,
                    Account = default
                },
                Cread = "TestValue747468292",
                Photo = "TestValue1667737983",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 583236450,
                User = new User
                {
                    RoleName = "TestValue345318980",
                    RefreshToken = "TestValue1934446989",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1470099983,
                    Account = default
                }
            }));
        }

        [Test]
        public void CannotCallDeleteAsyncWithNullAccount()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.DeleteAsync(new Group
            {
                Name = "TestValue1415982451",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>()
            }, default));
        }

        [Test]
        public async Task CanCallGetAllAsync()
        {
            // Arrange
            var id = 931057132;
            var pageNumber = 762076166;
            var pageSize = 636799771;

            _groupRepository.Setup(mock => mock.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new List<Group>());

            // Act
            var result = await _testClass.GetAllAsync(id, pageNumber, pageSize);

            // Assert
            _groupRepository.Verify(mock => mock.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
        }

        [Test]
        public async Task CanCallGetAsync()
        {
            // Arrange
            var id = 1288196015;

            _groupRepository.Setup(mock => mock.GetAsync(It.IsAny<int>())).ReturnsAsync(new Group
            {
                Name = "TestValue1698883156",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>()
            });

            // Act
            var result = await _testClass.GetAsync(id);

            // Assert
            _groupRepository.Verify(mock => mock.GetAsync(It.IsAny<int>()));
        }

        [Test]
        public async Task CanCallUpdateAsync()
        {
            // Arrange
            var @group = new Group
            {
                Name = "TestValue726161505",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>()
            };

            _groupRepository.Setup(mock => mock.UpdateAsync(It.IsAny<Group>(), It.IsAny<CancellationToken>())).Verifiable();

            // Act
            var result = await _testClass.UpdateAsync(group);

            // Assert
            _groupRepository.Verify(mock => mock.UpdateAsync(It.IsAny<Group>(), It.IsAny<CancellationToken>()));
        }

        [Test]
        public void CannotCallUpdateAsyncWithNullGroup()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.UpdateAsync(default));
        }
    }
}
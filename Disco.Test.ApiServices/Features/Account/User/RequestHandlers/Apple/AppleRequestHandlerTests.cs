namespace Disco.Test.Business.Features.Account.User.RequestHandlers.Apple
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.ApiServices.Features.Account.User.RequestHandlers.Apple;
    using Disco.Business.Interfaces.Dtos.Apple;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class AppleRequestHandlerTests
    {
        private AppleRequestHandler _testClass;
        private Mock<IAccountService> _accountService;
        private Mock<ITokenService> _tokenService;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void SetUp()
        {
            _accountService = new Mock<IAccountService>();
            _tokenService = new Mock<ITokenService>();
            _mapper = new Mock<IMapper>();
            _testClass = new AppleRequestHandler(_accountService.Object, _tokenService.Object, _mapper.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new AppleRequestHandler(_accountService.Object, _tokenService.Object, _mapper.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullAccountService()
        {
            Assert.Throws<ArgumentNullException>(() => new AppleRequestHandler(default(IAccountService), _tokenService.Object, _mapper.Object));
        }

        [Test]
        public void CannotConstructWithNullTokenService()
        {
            Assert.Throws<ArgumentNullException>(() => new AppleRequestHandler(_accountService.Object, default(ITokenService), _mapper.Object));
        }

        [Test]
        public void CannotConstructWithNullMapper()
        {
            Assert.Throws<ArgumentNullException>(() => new AppleRequestHandler(_accountService.Object, _tokenService.Object, default(IMapper)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new AppleRequest(new AppleLogInDto
            {
                Name = "TestValue459720736",
                Email = "TestValue1642113526",
                AppleId = "TestValue163842907",
                AppleIdCode = "TestValue249642514"
            });
            var cancellationToken = CancellationToken.None;

            _accountService.Setup(mock => mock.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync(new User
            {
                RoleName = "TestValue120674522",
                RefreshToken = "TestValue595478316",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1464928885,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue811636735",
                        FollowersCount = 1578122362,
                        NextStatusId = 1453035463,
                        UserTarget = 229407169,
                        AccountId = 1391902309,
                        Account = default(Account)
                    },
                    Cread = "TestValue489446012",
                    Photo = "TestValue1887588809",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1863067981,
                    User = default(User)
                }
            });
            _accountService.Setup(mock => mock.GetByLogInProviderAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new User
            {
                RoleName = "TestValue938051221",
                RefreshToken = "TestValue171684660",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 492229892,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue82473775",
                        FollowersCount = 1400952755,
                        NextStatusId = 1989996455,
                        UserTarget = 748508615,
                        AccountId = 1854127945,
                        Account = default(Account)
                    },
                    Cread = "TestValue627806432",
                    Photo = "TestValue1385816950",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 921804950,
                    User = default(User)
                }
            });
            _accountService.Setup(mock => mock.CreateAsync(It.IsAny<User>())).Verifiable();
            _tokenService.Setup(mock => mock.GenerateAccessToken(It.IsAny<User>())).Returns("TestValue1334225088");
            _tokenService.Setup(mock => mock.GenerateRefreshToken()).Returns("TestValue1763235236");

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            _accountService.Verify(mock => mock.GetByEmailAsync(It.IsAny<string>()));
            _accountService.Verify(mock => mock.GetByLogInProviderAsync(It.IsAny<string>(), It.IsAny<string>()));
            _accountService.Verify(mock => mock.CreateAsync(It.IsAny<User>()));
            _tokenService.Verify(mock => mock.GenerateAccessToken(It.IsAny<User>()));
            _tokenService.Verify(mock => mock.GenerateRefreshToken());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(AppleRequest), CancellationToken.None));
        }
    }
}
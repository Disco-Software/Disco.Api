namespace Disco.Test.Business.Features.Account.User.RequestHandlers.Facebook
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.ApiServices.Features.Account.User.RequestHandlers.Facebook;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using Disco.Integration.Interfaces.Dtos.Facebook;
    using Disco.Integration.Interfaces.Interfaces;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class FacebookRequestHandlerTests
    {
        private FacebookRequestHandler _testClass;
        private Mock<IAccountService> _accountService;
        private Mock<IFacebookClient> _facebookClient;
        private Mock<ITokenService> _tokenService;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void SetUp()
        {
            _accountService = new Mock<IAccountService>();
            _facebookClient = new Mock<IFacebookClient>();
            _tokenService = new Mock<ITokenService>();
            _mapper = new Mock<IMapper>();
            _testClass = new FacebookRequestHandler(_accountService.Object, _facebookClient.Object, _tokenService.Object, _mapper.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new FacebookRequestHandler(_accountService.Object, _facebookClient.Object, _tokenService.Object, _mapper.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullAccountService()
        {
            Assert.Throws<ArgumentNullException>(() => new FacebookRequestHandler(default(IAccountService), _facebookClient.Object, _tokenService.Object, _mapper.Object));
        }

        [Test]
        public void CannotConstructWithNullFacebookClient()
        {
            Assert.Throws<ArgumentNullException>(() => new FacebookRequestHandler(_accountService.Object, default(IFacebookClient), _tokenService.Object, _mapper.Object));
        }

        [Test]
        public void CannotConstructWithNullTokenService()
        {
            Assert.Throws<ArgumentNullException>(() => new FacebookRequestHandler(_accountService.Object, _facebookClient.Object, default(ITokenService), _mapper.Object));
        }

        [Test]
        public void CannotConstructWithNullMapper()
        {
            Assert.Throws<ArgumentNullException>(() => new FacebookRequestHandler(_accountService.Object, _facebookClient.Object, _tokenService.Object, default(IMapper)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new FacebookRequest(new FacebookRequestDto { AccessToken = "TestValue863825719" });
            var cancellationToken = CancellationToken.None;

            _accountService.Setup(mock => mock.GetByLogInProviderAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new User
            {
                RoleName = "TestValue8239688",
                RefreshToken = "TestValue1027074339",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 621149944,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue298770635",
                        FollowersCount = 255850883,
                        NextStatusId = 1587988227,
                        UserTarget = 951420659,
                        AccountId = 808803195,
                        Account = default(Account)
                    },
                    Cread = "TestValue1381192387",
                    Photo = "TestValue1603002745",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2081979591,
                    User = default(User)
                }
            });
            _accountService.Setup(mock => mock.SaveRefreshTokenAsync(It.IsAny<User>(), It.IsAny<string>())).Verifiable();
            _accountService.Setup(mock => mock.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync(new User
            {
                RoleName = "TestValue1848593317",
                RefreshToken = "TestValue1208731160",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1479826549,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue81911300",
                        FollowersCount = 378273267,
                        NextStatusId = 939866880,
                        UserTarget = 915640092,
                        AccountId = 1895854037,
                        Account = default(Account)
                    },
                    Cread = "TestValue1410736950",
                    Photo = "TestValue617820821",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 197660217,
                    User = default(User)
                }
            });
            _accountService.Setup(mock => mock.CreateAsync(It.IsAny<User>())).Verifiable();
            _facebookClient.Setup(mock => mock.GetInfoAsync(It.IsAny<string>())).ReturnsAsync(new FacebookDto
            {
                Id = "TestValue709350189",
                Name = "TestValue603314802",
                Email = "TestValue1576274608",
                FirstName = "TestValue2131973581",
                Picture = new Picture
                {
                    Data = new Data
                    {
                        Height = 2044579388,
                        IsSilhouette = true,
                        Url = "TestValue12417352",
                        Width = 318066719
                    }
                }
            });
            _tokenService.Setup(mock => mock.GenerateAccessToken(It.IsAny<User>())).Returns("TestValue35077711");
            _tokenService.Setup(mock => mock.GenerateRefreshToken()).Returns("TestValue878003835");

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            _accountService.Verify(mock => mock.GetByLogInProviderAsync(It.IsAny<string>(), It.IsAny<string>()));
            _accountService.Verify(mock => mock.SaveRefreshTokenAsync(It.IsAny<User>(), It.IsAny<string>()));
            _accountService.Verify(mock => mock.GetByEmailAsync(It.IsAny<string>()));
            _accountService.Verify(mock => mock.CreateAsync(It.IsAny<User>()));
            _facebookClient.Verify(mock => mock.GetInfoAsync(It.IsAny<string>()));
            _tokenService.Verify(mock => mock.GenerateAccessToken(It.IsAny<User>()));
            _tokenService.Verify(mock => mock.GenerateRefreshToken());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(FacebookRequest), CancellationToken.None));
        }
    }
}
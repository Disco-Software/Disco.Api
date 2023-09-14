namespace Disco.Test.Business.Features.Account.User.RequestHandlers.Google
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.ApiServices.Features.Account.User.RequestHandlers.Google;
    using Disco.Business.Interfaces.Dtos.Google;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Business.Services.Mappers;
    using Disco.Domain.Models.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class GoogleRequestHandlerTests
    {
        private GoogleRequestHandler _testClass;
        private Mock<IAccountService> _accountService;
        private Mock<ITokenService> _tokenService;
        
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _accountService = new Mock<IAccountService>();
            _tokenService = new Mock<ITokenService>();
            
            _mapper = new MapperConfiguration(x => x.AddProfile(new AccountMapProfile())).CreateMapper();
            
            _testClass = new GoogleRequestHandler(_accountService.Object, _tokenService.Object, _mapper);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GoogleRequestHandler(_accountService.Object, _tokenService.Object, _mapper);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallHandleWithEmail()
        {
            // Arrange
            var request = new GoogleRequest(new GoogleLogInDto
            {
                Email = "TestValue1164352459",
                UserName = "TestValue762346070",
                Photo = "TestValue1487171594",
                Id = "TestValue174116302",
                IdToken = "TestValue889167996",
                ServerAuthCode = "TestValue2024544646"
            });
            var cancellationToken = CancellationToken.None;

            _accountService.Setup(mock => mock.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync(new User
            {
                RoleName = "TestValue269091989",
                RefreshToken = "TestValue43471390",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 415269159,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1627410331",
                        FollowersCount = 1590099128,
                        NextStatusId = 1461568005,
                        UserTarget = 1794802323,
                        AccountId = 392850200,
                        Account = default(Account)
                    },
                    Cread = "TestValue1411847803",
                    Photo = "TestValue2022170330",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1289361540,
                    User = default(User)
                }
            });
            _accountService.Setup(mock => mock.SaveRefreshTokenAsync(It.IsAny<User>(), It.IsAny<string>())).Verifiable();
            _accountService.Setup(mock => mock.GetByLogInProviderAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new User
            {
                RoleName = "TestValue495510690",
                RefreshToken = "TestValue542837951",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1224981389,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1129437391",
                        FollowersCount = 1556239950,
                        NextStatusId = 598801804,
                        UserTarget = 690365389,
                        AccountId = 985370113,
                        Account = default(Account)
                    },
                    Cread = "TestValue77366783",
                    Photo = "TestValue87171242",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1642578808,
                    User = default(User)
                }
            });
            _accountService.Setup(mock => mock.CreateAsync(It.IsAny<User>())).Verifiable();
            _tokenService.Setup(mock => mock.GenerateAccessToken(It.IsAny<User>())).Returns("TestValue316966735");
            _tokenService.Setup(mock => mock.GenerateRefreshToken()).Returns("TestValue1802101694");

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            _accountService.Verify(mock => mock.GetByEmailAsync(It.IsAny<string>()));
            _accountService.Verify(mock => mock.SaveRefreshTokenAsync(It.IsAny<User>(), It.IsAny<string>()));
            _accountService.Verify(mock => mock.GetByLogInProviderAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Never());
            _accountService.Verify(mock => mock.CreateAsync(It.IsAny<User>()), Times.Never());
            _tokenService.Verify(mock => mock.GenerateAccessToken(It.IsAny<User>()));
            _tokenService.Verify(mock => mock.GenerateRefreshToken());
        }
        
        [Test]
        public async Task CanCallHandleWithLogInProvider()
        {
            // Arrange
            var request = new GoogleRequest(new GoogleLogInDto
            {
                Email = "TestValue1164352459",
                UserName = "TestValue762346070",
                Photo = "TestValue1487171594",
                Id = "TestValue174116302",
                IdToken = "TestValue889167996",
                ServerAuthCode = "TestValue2024544646"
            });
            var cancellationToken = CancellationToken.None;

            _accountService.Setup(mock => mock.SaveRefreshTokenAsync(It.IsAny<User>(), It.IsAny<string>())).Verifiable();
            _accountService.Setup(mock => mock.GetByLogInProviderAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new User
            {
                RoleName = "TestValue495510690",
                RefreshToken = "TestValue542837951",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1224981389,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1129437391",
                        FollowersCount = 1556239950,
                        NextStatusId = 598801804,
                        UserTarget = 690365389,
                        AccountId = 985370113,
                        Account = default(Account)
                    },
                    Cread = "TestValue77366783",
                    Photo = "TestValue87171242",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1642578808,
                    User = default(User)
                }
            });
            _accountService.Setup(mock => mock.CreateAsync(It.IsAny<User>())).Verifiable();
            _tokenService.Setup(mock => mock.GenerateAccessToken(It.IsAny<User>())).Returns("TestValue316966735");
            _tokenService.Setup(mock => mock.GenerateRefreshToken()).Returns("TestValue1802101694");

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            _accountService.Verify(mock => mock.GetByEmailAsync(It.IsAny<string>()));
            _accountService.Verify(mock => mock.SaveRefreshTokenAsync(It.IsAny<User>(), It.IsAny<string>()));
            _accountService.Verify(mock => mock.GetByLogInProviderAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            _accountService.Verify(mock => mock.CreateAsync(It.IsAny<User>()), Times.Never());
            _tokenService.Verify(mock => mock.GenerateAccessToken(It.IsAny<User>()));
            _tokenService.Verify(mock => mock.GenerateRefreshToken());
        }
        
        [Test]
        public async Task CanCallHandleWithNullUser()
        {
            // Arrange
            var request = new GoogleRequest(new GoogleLogInDto
            {
                Email = "TestValue1164352459",
                UserName = "TestValue762346070",
                Photo = "TestValue1487171594",
                Id = "TestValue174116302",
                IdToken = "TestValue889167996",
                ServerAuthCode = "TestValue2024544646"
            });
            var cancellationToken = CancellationToken.None;

            _accountService.Setup(mock => mock.SaveRefreshTokenAsync(It.IsAny<User>(), It.IsAny<string>())).Verifiable();
            _accountService.Setup(mock => mock.CreateAsync(It.IsAny<User>())).Verifiable();
            _tokenService.Setup(mock => mock.GenerateAccessToken(It.IsAny<User>())).Returns("TestValue316966735");
            _tokenService.Setup(mock => mock.GenerateRefreshToken()).Returns("TestValue1802101694");

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            _accountService.Verify(mock => mock.GetByEmailAsync(It.IsAny<string>()));
            _accountService.Verify(mock => mock.SaveRefreshTokenAsync(It.IsAny<User>(), It.IsAny<string>()));
            _accountService.Verify(mock => mock.GetByLogInProviderAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            _accountService.Verify(mock => mock.CreateAsync(It.IsAny<User>()), Times.Once());
            _tokenService.Verify(mock => mock.GenerateAccessToken(It.IsAny<User>()));
            _tokenService.Verify(mock => mock.GenerateRefreshToken());
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(GoogleRequest), CancellationToken.None));
        }
    }
}
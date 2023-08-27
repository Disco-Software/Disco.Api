namespace Disco.Test.Business.Features.Account.User.RequestHandlers.RefreshToken
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.ApiServices.Features.Account.Admin.RequestHandlers.RefreshToken;
    using Disco.ApiServices.Features.Account.User.RequestHandlers.RefreshToken;
    using Disco.Business.Interfaces.Dtos.Account;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class RefreshTokenRequestHandlerTests
    {
        private RefreshTokenRequestHandler _testClass;
        private Mock<IAccountService> _accountService;
        private Mock<ITokenService> _tokenService;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void SetUp()
        {
            _accountService = new Mock<IAccountService>();
            _tokenService = new Mock<ITokenService>();
            _mapper = new Mock<IMapper>();
            _testClass = new RefreshTokenRequestHandler(_accountService.Object, _tokenService.Object, _mapper.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new RefreshTokenRequestHandler(_accountService.Object, _tokenService.Object, _mapper.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullAccountService()
        {
            Assert.Throws<ArgumentNullException>(() => new RefreshTokenRequestHandler(default(IAccountService), _tokenService.Object, _mapper.Object));
        }

        [Test]
        public void CannotConstructWithNullTokenService()
        {
            Assert.Throws<ArgumentNullException>(() => new RefreshTokenRequestHandler(_accountService.Object, default(ITokenService), _mapper.Object));
        }

        [Test]
        public void CannotConstructWithNullMapper()
        {
            Assert.Throws<ArgumentNullException>(() => new RefreshTokenRequestHandler(_accountService.Object, _tokenService.Object, default(IMapper)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new Disco.ApiServices.Features.Account.Admin.RequestHandlers.RefreshToken.RefreshTokenRequest(new RefreshTokenDto
            {
                RefreshToken = "TestValue589974837",
                AccessToken = "TestValue241422784"
            });
            var cancellationToken = CancellationToken.None;

            _accountService.Setup(mock => mock.GetByRefreshTokenAsync(It.IsAny<string>())).ReturnsAsync(new User
            {
                RoleName = "TestValue2102671985",
                RefreshToken = "TestValue507167850",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1382282278,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1055421416",
                        FollowersCount = 1158525643,
                        NextStatusId = 1450231632,
                        UserTarget = 322472235,
                        AccountId = 572244654,
                        Account = default(Account)
                    },
                    Cread = "TestValue221353102",
                    Photo = "TestValue1260487563",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1880873792,
                    User = default(User)
                }
            });
            _accountService.Setup(mock => mock.SaveRefreshTokenAsync(It.IsAny<User>(), It.IsAny<string>())).Verifiable();
            _tokenService.Setup(mock => mock.GenerateAccessToken(It.IsAny<User>())).Returns("TestValue1640774998");
            _tokenService.Setup(mock => mock.GenerateRefreshToken()).Returns("TestValue2064753554");

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            _accountService.Verify(mock => mock.GetByRefreshTokenAsync(It.IsAny<string>()));
            _accountService.Verify(mock => mock.SaveRefreshTokenAsync(It.IsAny<User>(), It.IsAny<string>()));
            _tokenService.Verify(mock => mock.GenerateAccessToken(It.IsAny<User>()));
            _tokenService.Verify(mock => mock.GenerateRefreshToken());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
           Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(Disco.ApiServices.Features.Account.Admin.RequestHandlers.RefreshToken.RefreshTokenRequest), CancellationToken.None));
        }
    }
}
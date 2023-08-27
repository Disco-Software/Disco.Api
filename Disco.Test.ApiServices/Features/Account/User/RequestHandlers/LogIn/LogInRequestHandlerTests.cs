namespace Disco.Test.Business.Features.Account.User.RequestHandlers.LogIn
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.ApiServices.Features.Account.User.RequestHandlers.LogIn;
    using Disco.Business.Interfaces.Dtos.Account;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Identity;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class LogInRequestHandlerTests
    {
        private LogInRequestHandler _testClass;
        private Mock<IAccountService> _accountService;
        private Mock<IAccountPasswordService> _accountPasswordService;
        private Mock<ITokenService> _tokenService;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void SetUp()
        {
            _accountService = new Mock<IAccountService>();
            _accountPasswordService = new Mock<IAccountPasswordService>();
            _tokenService = new Mock<ITokenService>();
            _mapper = new Mock<IMapper>();
            _testClass = new LogInRequestHandler(_accountService.Object, _accountPasswordService.Object, _tokenService.Object, _mapper.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new LogInRequestHandler(_accountService.Object, _accountPasswordService.Object, _tokenService.Object, _mapper.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullAccountService()
        {
            Assert.Throws<ArgumentNullException>(() => new LogInRequestHandler(default(IAccountService), _accountPasswordService.Object, _tokenService.Object, _mapper.Object));
        }

        [Test]
        public void CannotConstructWithNullAccountPasswordService()
        {
            Assert.Throws<ArgumentNullException>(() => new LogInRequestHandler(_accountService.Object, default(IAccountPasswordService), _tokenService.Object, _mapper.Object));
        }

        [Test]
        public void CannotConstructWithNullTokenService()
        {
            Assert.Throws<ArgumentNullException>(() => new LogInRequestHandler(_accountService.Object, _accountPasswordService.Object, default(ITokenService), _mapper.Object));
        }

        [Test]
        public void CannotConstructWithNullMapper()
        {
            Assert.Throws<ArgumentNullException>(() => new LogInRequestHandler(_accountService.Object, _accountPasswordService.Object, _tokenService.Object, default(IMapper)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new LogInRequest(new LoginDto
            {
                Email = "TestValue1651165851",
                Password = "TestValue1534786804"
            });
            var cancellationToken = CancellationToken.None;

            _accountService.Setup(mock => mock.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync(new User
            {
                RoleName = "TestValue1814432099",
                RefreshToken = "TestValue1654369365",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 969123230,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue513610367",
                        FollowersCount = 2146881132,
                        NextStatusId = 1692053759,
                        UserTarget = 1494904594,
                        AccountId = 773996828,
                        Account = default(Account)
                    },
                    Cread = "TestValue1873988302",
                    Photo = "TestValue760651112",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 463057872,
                    User = default(User)
                }
            });
            _accountService.Setup(mock => mock.SaveRefreshTokenAsync(It.IsAny<User>(), It.IsAny<string>())).Verifiable();
            _accountPasswordService.Setup(mock => mock.VerifyPasswordAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(PasswordVerificationResult.Success);
            _tokenService.Setup(mock => mock.GenerateAccessToken(It.IsAny<User>())).Returns("TestValue2121880058");
            _tokenService.Setup(mock => mock.GenerateRefreshToken()).Returns("TestValue1620686021");

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            _accountService.Verify(mock => mock.GetByEmailAsync(It.IsAny<string>()));
            _accountService.Verify(mock => mock.SaveRefreshTokenAsync(It.IsAny<User>(), It.IsAny<string>()));
            _accountPasswordService.Verify(mock => mock.VerifyPasswordAsync(It.IsAny<User>(), It.IsAny<string>()));
            _tokenService.Verify(mock => mock.GenerateAccessToken(It.IsAny<User>()));
            _tokenService.Verify(mock => mock.GenerateRefreshToken());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(LogInRequest), CancellationToken.None));
        }
    }
}
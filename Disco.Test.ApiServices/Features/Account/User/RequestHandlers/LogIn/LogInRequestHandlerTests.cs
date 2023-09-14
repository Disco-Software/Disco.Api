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
    using Disco.Business.Services.Mappers;
    using Disco.Business.Utils.Exceptions;
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
        
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _accountService = new Mock<IAccountService>();
            _accountPasswordService = new Mock<IAccountPasswordService>();
            _tokenService = new Mock<ITokenService>();
            
            _mapper = new MapperConfiguration(x => x.AddProfile(new AccountMapProfile())).CreateMapper();
            
            _testClass = new LogInRequestHandler(_accountService.Object, _accountPasswordService.Object, _tokenService.Object, _mapper);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new LogInRequestHandler(_accountService.Object, _accountPasswordService.Object, _tokenService.Object, _mapper);

            // Assert
            Assert.That(instance, Is.Not.Null);
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
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(LogInRequest), CancellationToken.None));
        }

        [Test]
        public async Task CannotCallHandleWithInvalidPassword()
        {
            Assert.ThrowsAsync<InvalidPasswordException>(async () => {
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
                _accountPasswordService.Setup(mock => mock.VerifyPasswordAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(PasswordVerificationResult.Failed);
                _tokenService.Setup(mock => mock.GenerateAccessToken(It.IsAny<User>())).Returns("TestValue2121880058");
                _tokenService.Setup(mock => mock.GenerateRefreshToken()).Returns("TestValue1620686021");

                // Act
                await _testClass.Handle(request, cancellationToken);
            });
        }
    }
}
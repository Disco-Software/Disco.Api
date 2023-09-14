namespace Disco.Test.ApiServices.Features.Account.Admin.RequestHandlers.RefreshToken
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.ApiServices.Features.Account.Admin.RequestHandlers.RefreshToken;
    using Disco.Business.Exceptions;
    using Disco.Business.Interfaces.Dtos.Account;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Business.Services.Mappers;
    using Disco.Domain.Models.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class RefreshTokenRequestHandlerTests
    {
        private RefreshTokenRequestHandler _testClass;
        private IAccountService _accountService;
        private ITokenService _tokenService;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _accountService = Substitute.For<IAccountService>();
            _tokenService = Substitute.For<ITokenService>();

            _mapper = new MapperConfiguration(x => x.AddProfile(new AccountMapProfile())).CreateMapper();
            
            _testClass = new RefreshTokenRequestHandler(_accountService, _tokenService, _mapper);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new RefreshTokenRequestHandler(_accountService, _tokenService, _mapper);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new RefreshTokenRequest(new RefreshTokenDto
            {
                RefreshToken = "TestValue787896928",
                AccessToken = "TestValue2118845807"
            });
            var cancellationToken = CancellationToken.None;

            _accountService.GetByRefreshTokenAsync(Arg.Any<string>()).Returns(new User
            {
                RoleName = "TestValue81024130",
                RefreshToken = "TestValue1338515052",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 118116465,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue754187871",
                        FollowersCount = 2127836251,
                        NextStatusId = 849548465,
                        UserTarget = 1668205685,
                        AccountId = 74785567,
                        Account = default(Account)
                    },
                    Cread = "TestValue305800559",
                    Photo = "TestValue955711899",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1777339768,
                    User = default(User)
                }
            });
            _tokenService.GenerateAccessToken(Arg.Any<User>()).Returns("TestValue853280359");
            _tokenService.GenerateRefreshToken().Returns("TestValue1989550804");

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetByRefreshTokenAsync(Arg.Any<string>());
            await _accountService.Received(0).SaveRefreshTokenAsync(Arg.Any<User>(), Arg.Any<string>());
            _tokenService.Received().GenerateAccessToken(Arg.Any<User>());
            _tokenService.Received(0).GenerateRefreshToken();
        }
        
        [Test]
        public async Task CanCallHandleWithExpiredRefreshToken()
        {
            // Arrange
            var request = new RefreshTokenRequest(new RefreshTokenDto
            {
                RefreshToken = "TestValue787896928",
                AccessToken = "TestValue2118845807"
            });
            var cancellationToken = CancellationToken.None;

            _accountService.GetByRefreshTokenAsync(Arg.Any<string>()).Returns(new User
            {
                RoleName = "TestValue81024130",
                RefreshToken = "TestValue1338515052",
                RefreshTokenExpiress = DateTime.UtcNow.AddDays(8),
                DateOfRegister = DateTime.UtcNow,
                AccountId = 118116465,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue754187871",
                        FollowersCount = 2127836251,
                        NextStatusId = 849548465,
                        UserTarget = 1668205685,
                        AccountId = 74785567,
                        Account = default(Account)
                    },
                    Cread = "TestValue305800559",
                    Photo = "TestValue955711899",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1777339768,
                    User = default(User)
                }
            });
            _tokenService.GenerateAccessToken(Arg.Any<User>()).Returns("TestValue853280359");
            _tokenService.GenerateRefreshToken().Returns("TestValue1989550804");

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received(1).GetByRefreshTokenAsync(Arg.Any<string>());
            await _accountService.Received(1).SaveRefreshTokenAsync(Arg.Any<User>(), Arg.Any<string>());
            _tokenService.Received(1).GenerateAccessToken(Arg.Any<User>());
            _tokenService.Received(1).GenerateRefreshToken();
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(RefreshTokenRequest), CancellationToken.None));
        }

        [Test]
        public void CannotCallHandleWithNullUser()
        {
            Assert.ThrowsAsync<ResourceNotFoundException>(async () =>
            {
                var request = new RefreshTokenRequest(new RefreshTokenDto
                {
                    RefreshToken = "TestValue787896928",
                    AccessToken = "TestValue2118845807"
                });
                var cancellationToken = CancellationToken.None;

                _tokenService.GenerateAccessToken(Arg.Any<User>()).Returns("TestValue853280359");
                _tokenService.GenerateRefreshToken().Returns("TestValue1989550804");

                // Act
                var result = await _testClass.Handle(request, cancellationToken);
            });
        }
    }
}
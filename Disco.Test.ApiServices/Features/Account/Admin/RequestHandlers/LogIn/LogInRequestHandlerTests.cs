namespace Disco.Test.ApiServices.Features.Account.Admin.RequestHandlers.LogIn
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.ApiServices.Features.Account.Admin.RequestHandlers.LogIn;
    using Disco.Business.Exceptions;
    using Disco.Business.Interfaces.Dtos.Account;
    using Disco.Business.Interfaces.Dtos.Account.Admin.LogIn;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Business.Services.Mappers;
    using Disco.Business.Utils.Exceptions;
    using Disco.Domain.Models.Models;
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
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new Disco.ApiServices.Features.Account.Admin.RequestHandlers.LogIn.LogInRequest(new LogInRequestDto("TestValue393947024", "TestValue727404845"));
            var account = new Domain.Models.Models.Account()
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue105496015",
                    FollowersCount = 1992149780,
                    NextStatusId = 1755222771,
                    UserTarget = 2121905592,
                    AccountId = 133441750,
                    Account = default(Domain.Models.Models.Account)
                },
                Cread = "TestValue1469187632",
                Photo = "TestValue1530622572",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Domain.Models.Models.Connection>(),
                Messages = new List<Domain.Models.Models.Message>(),
                Posts = new List<Domain.Models.Models.Post>(),
                Comments = new List<Domain.Models.Models.Comment>(),
                Likes = new List<Domain.Models.Models.Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Domain.Models.Models.Story>(),
                UserId = 681797057,
                User = new User
                {
                    RoleName = "TestValue1016160451",
                    RefreshToken = "TestValue908706633",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 136942585,
                    Account = default(Domain.Models.Models.Account)
                }
            };

            var cancellationToken = CancellationToken.None;

            _accountService.Setup(x => x.GetByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(account.User);

            _accountPasswordService.Setup(x => x.VerifyPasswordAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success);

            _accountService.Setup(x => x.IsInRoleAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(true);

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(Disco.ApiServices.Features.Account.Admin.RequestHandlers.LogIn.LogInRequest), CancellationToken.None));
        }

        [Test]
        public void CannotCallHandleWithInvalidPassword()
        {
            Assert.ThrowsAsync<InvalidPasswordException>(async () =>
            {
                var request = new Disco.ApiServices.Features.Account.Admin.RequestHandlers.LogIn.LogInRequest(new LogInRequestDto(
                    "TestValue393947024",
                    "TestValue727404845"
                ));
                var account = new Domain.Models.Models.Account()
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue105496015",
                        FollowersCount = 1992149780,
                        NextStatusId = 1755222771,
                        UserTarget = 2121905592,
                        AccountId = 133441750,
                        Account = default(Domain.Models.Models.Account)
                    },
                    Cread = "TestValue1469187632",
                    Photo = "TestValue1530622572",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Domain.Models.Models.Connection>(),
                    Messages = new List<Domain.Models.Models.Message>(),
                    Posts = new List<Domain.Models.Models.Post>(),
                    Comments = new List<Domain.Models.Models.Comment>(),
                    Likes = new List<Domain.Models.Models.Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Domain.Models.Models.Story>(),
                    UserId = 681797057,
                    User = new User
                    {
                        RoleName = "TestValue1016160451",
                        RefreshToken = "TestValue908706633",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 136942585,
                        Account = default(Domain.Models.Models.Account)
                    }
                };

                var cancellationToken = CancellationToken.None;

                _accountService.Setup(x => x.GetByEmailAsync(It.IsAny<string>()))
                    .ReturnsAsync(account.User);

                _accountPasswordService.Setup(x => x.VerifyPasswordAsync(It.IsAny<User>(), It.IsAny<string>()))
                    .ReturnsAsync(Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed);

                _accountService.Setup(x => x.IsInRoleAsync(It.IsAny<User>(), It.IsAny<string>()))
                    .ReturnsAsync(true);

                // Act
                var result = await _testClass.Handle(request, cancellationToken);

                // Assert
                Assert.That(result, Is.Not.Null);
            });
        }
        
        [Test]
        public void CannotCallHandleWithInvalidRole()
        {
            Assert.ThrowsAsync<InvalidRoleException>(async () =>
            {
                var request = new Disco.ApiServices.Features.Account.Admin.RequestHandlers.LogIn.LogInRequest(new LogInRequestDto(
                    "TestValue393947024",
                    "TestValue727404845"
                 ));
                var account = new Domain.Models.Models.Account()
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue105496015",
                        FollowersCount = 1992149780,
                        NextStatusId = 1755222771,
                        UserTarget = 2121905592,
                        AccountId = 133441750,
                        Account = default(Domain.Models.Models.Account)
                    },
                    Cread = "TestValue1469187632",
                    Photo = "TestValue1530622572",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Domain.Models.Models.Connection>(),
                    Messages = new List<Domain.Models.Models.Message>(),
                    Posts = new List<Domain.Models.Models.Post>(),
                    Comments = new List<Domain.Models.Models.Comment>(),
                    Likes = new List<Domain.Models.Models.Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Domain.Models.Models.Story>(),
                    UserId = 681797057,
                    User = new User
                    {
                        RoleName = "TestValue1016160451",
                        RefreshToken = "TestValue908706633",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 136942585,
                        Account = default(Domain.Models.Models.Account)
                    }
                };

                var cancellationToken = CancellationToken.None;

                _accountService.Setup(x => x.GetByEmailAsync(It.IsAny<string>()))
                    .ReturnsAsync(account.User);

                _accountPasswordService.Setup(x => x.VerifyPasswordAsync(It.IsAny<User>(), It.IsAny<string>()))
                    .ReturnsAsync(Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success);

                _accountService.Setup(x => x.IsInRoleAsync(It.IsAny<User>(), It.IsAny<string>()))
                    .ReturnsAsync(false);

                // Act
                 await _testClass.Handle(request, cancellationToken);
            });
        }
    }
}
namespace Disco.Test.ApiServices.Features.AccountPassword.Admin.RequestHandlers.ForgotPassword
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.AccountPassword.Admin.RequestHandlers.ForgotPassword;
    using Disco.Business.Interfaces.Dtos.Account;
    using Disco.Business.Interfaces.Dtos.EmailNotifications;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class ForgotPasswordRequestHandlerTests
    {
        private ForgotPasswordRequestHandler _testClass;
        private IAccountService _accountService;
        private IAccountPasswordService _accountPasswordService;
        private IEmailService _emailService;

        [SetUp]
        public void SetUp()
        {
            _accountService = Substitute.For<IAccountService>();
            _accountPasswordService = Substitute.For<IAccountPasswordService>();
            _emailService = Substitute.For<IEmailService>();
            _testClass = new ForgotPasswordRequestHandler(_accountService, _accountPasswordService, _emailService);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new ForgotPasswordRequestHandler(_accountService, _accountPasswordService, _emailService);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new ForgotPasswordRequest(new ForgotPasswordDto { Email = "TestValue1956726538" });
            var cancellationToken = CancellationToken.None;

            _accountService.GetByEmailAsync(Arg.Any<string>()).Returns(new User
            {
                RoleName = "TestValue600758905",
                RefreshToken = "TestValue1351806660",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1107357412,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue934491085",
                        FollowersCount = 1887625428,
                        NextStatusId = 709992106,
                        UserTarget = 614369917,
                        AccountId = 1086495852,
                        Account = default(Account)
                    },
                    Cread = "TestValue2030621444",
                    Photo = "TestValue1773963890",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1739127886,
                    User = default(User)
                }
            });
            _accountPasswordService.GetPasswordConfirmationTokenAsync(Arg.Any<User>()).Returns("TestValue1424129986");

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetByEmailAsync(Arg.Any<string>());
            await _accountPasswordService.Received().GetPasswordConfirmationTokenAsync(Arg.Any<User>());
            await _emailService.Received().EmailConfirmationAsync(Arg.Any<EmailConfirmationDto>());
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(ForgotPasswordRequest), CancellationToken.None));
        }
    }
}
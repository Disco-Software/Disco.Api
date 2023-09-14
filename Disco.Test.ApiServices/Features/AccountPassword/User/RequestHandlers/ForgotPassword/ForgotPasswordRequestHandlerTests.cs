namespace Disco.Test.ApiServices.Features.AccountPassword.User.RequestHandlers.ForgotPassword
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.AccountPassword.User.RequestHandlers.ForgotPassword;
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
            var request = new ForgotPasswordRequest(new ForgotPasswordDto { Email = "TestValue1100032041" });
            var cancellationToken = CancellationToken.None;

            _accountService.GetByEmailAsync(Arg.Any<string>()).Returns(new User
            {
                RoleName = "TestValue1847345546",
                RefreshToken = "TestValue1197555351",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1451556158,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue2090978050",
                        FollowersCount = 230555742,
                        NextStatusId = 1594760184,
                        UserTarget = 2063833271,
                        AccountId = 651315179,
                        Account = default(Account)
                    },
                    Cread = "TestValue731421216",
                    Photo = "TestValue1409276956",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 911237128,
                    User = default(User)
                }
            });
            _accountPasswordService.GetPasswordConfirmationTokenAsync(Arg.Any<User>()).Returns("TestValue857159676");

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetByEmailAsync(Arg.Any<string>());
            await _accountPasswordService.Received().GetPasswordConfirmationTokenAsync(Arg.Any<User>());
            _emailService.Received().EmailConfirmation(Arg.Any<EmailConfirmationDto>());
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(ForgotPasswordRequest), CancellationToken.None));
        }
    }
}
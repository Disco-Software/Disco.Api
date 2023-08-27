namespace Disco.Test.ApiServices.Features.AccountPassword.Admin.RequestHandlers.ResetPassword
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.AccountPassword.Admin.RequestHandlers.ResetPassword;
    using Disco.Business.Interfaces.Dtos.Account;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class ResetPasswordRequestHandlerTests
    {
        private ResetPasswordRequestHandler _testClass;
        private IAccountService _accountService;
        private IAccountPasswordService _accountPasswordService;

        [SetUp]
        public void SetUp()
        {
            _accountService = Substitute.For<IAccountService>();
            _accountPasswordService = Substitute.For<IAccountPasswordService>();
            _testClass = new ResetPasswordRequestHandler(_accountService, _accountPasswordService);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new ResetPasswordRequestHandler(_accountService, _accountPasswordService);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullAccountService()
        {
            Assert.Throws<ArgumentNullException>(() => new ResetPasswordRequestHandler(default(IAccountService), _accountPasswordService));
        }

        [Test]
        public void CannotConstructWithNullAccountPasswordService()
        {
            Assert.Throws<ArgumentNullException>(() => new ResetPasswordRequestHandler(_accountService, default(IAccountPasswordService)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new ResetPasswordRequest(new ResetPasswordDto
            {
                Email = "TestValue940158662",
                ConfirmationToken = "TestValue154173811",
                Password = "TestValue1371833985",
                ConfirmPassword = "TestValue1028630960"
            });
            var cancellationToken = CancellationToken.None;

            _accountService.GetByEmailAsync(Arg.Any<string>()).Returns(new User
            {
                RoleName = "TestValue1503852159",
                RefreshToken = "TestValue871589981",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1040542728,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue468282054",
                        FollowersCount = 341654167,
                        NextStatusId = 1098509549,
                        UserTarget = 159440988,
                        AccountId = 1079220852,
                        Account = default(Account)
                    },
                    Cread = "TestValue1023111601",
                    Photo = "TestValue1055768447",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1287182286,
                    User = default(User)
                }
            });

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetByEmailAsync(Arg.Any<string>());
            await _accountPasswordService.Received().ChengePasswordAsync(Arg.Any<User>(), Arg.Any<string>(), Arg.Any<string>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(ResetPasswordRequest), CancellationToken.None));
        }
    }
}
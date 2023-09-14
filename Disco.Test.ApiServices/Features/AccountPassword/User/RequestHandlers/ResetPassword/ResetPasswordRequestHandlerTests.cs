namespace Disco.Test.ApiServices.Features.AccountPassword.User.RequestHandlers.ResetPassword
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.AccountPassword.User.RequestHandlers.ResetPassword;
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
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new ResetPasswordRequest(new ResetPasswordDto
            {
                Email = "TestValue1075565091",
                ConfirmationToken = "TestValue1882685535",
                Password = "TestValue864418864",
                ConfirmPassword = "TestValue1881190004"
            });
            var cancellationToken = CancellationToken.None;

            _accountService.GetByEmailAsync(Arg.Any<string>()).Returns(new User
            {
                RoleName = "TestValue1834704542",
                RefreshToken = "TestValue277630969",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1174243586,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1086838414",
                        FollowersCount = 1741530991,
                        NextStatusId = 1918385832,
                        UserTarget = 700210113,
                        AccountId = 1386815690,
                        Account = default(Account)
                    },
                    Cread = "TestValue2011718005",
                    Photo = "TestValue57492352",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1760621088,
                    User = default(User)
                }
            });

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetByEmailAsync(Arg.Any<string>());
            await _accountPasswordService.Received().ChengePasswordAsync(Arg.Any<User>(), Arg.Any<string>(), Arg.Any<string>());
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(ResetPasswordRequest), CancellationToken.None));
        }
    }
}
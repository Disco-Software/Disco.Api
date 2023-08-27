namespace Disco.Test.ApiServices.Features.AccountDetails.Admin.RequestHandlers.DeleteAccount
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.DeleteAccount;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class DeleteAccountRequestHandlerTests
    {
        private DeleteAccountRequestHandler _testClass;
        private IAccountService _accountService;
        private IAccountDetailsService _accountDetailsService;

        [SetUp]
        public void SetUp()
        {
            _accountService = Substitute.For<IAccountService>();
            _accountDetailsService = Substitute.For<IAccountDetailsService>();
            _testClass = new DeleteAccountRequestHandler(_accountService, _accountDetailsService);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new DeleteAccountRequestHandler(_accountService, _accountDetailsService);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullAccountService()
        {
            Assert.Throws<ArgumentNullException>(() => new DeleteAccountRequestHandler(default(IAccountService), _accountDetailsService));
        }

        [Test]
        public void CannotConstructWithNullAccountDetailsService()
        {
            Assert.Throws<ArgumentNullException>(() => new DeleteAccountRequestHandler(_accountService, default(IAccountDetailsService)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new DeleteAccountRequest(1351384920);
            var cancellationToken = CancellationToken.None;

            _accountService.GetByIdAsync(Arg.Any<int>()).Returns(new User
            {
                RoleName = "TestValue1894265678",
                RefreshToken = "TestValue36575088",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1707801184,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1194222593",
                        FollowersCount = 418735679,
                        NextStatusId = 851292031,
                        UserTarget = 570766764,
                        AccountId = 1275388260,
                        Account = default(Account)
                    },
                    Cread = "TestValue1792647141",
                    Photo = "TestValue1186691449",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 601605462,
                    User = default(User)
                }
            });

            // Act
            await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetByIdAsync(Arg.Any<int>());
            await _accountService.Received().RemoveAsync(Arg.Any<User>());
            await _accountDetailsService.Received().RemoveAsync(Arg.Any<Account>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(DeleteAccountRequest), CancellationToken.None));
        }
    }
}
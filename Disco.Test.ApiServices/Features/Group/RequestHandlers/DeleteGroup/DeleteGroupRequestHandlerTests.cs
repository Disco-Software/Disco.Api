namespace Disco.Test.ApiServices.Features.Group.RequestHandlers.DeleteGroup
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Group.RequestHandlers.DeleteGroup;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class DeleteGroupRequestHandlerTests
    {
        private DeleteGroupRequestHandler _testClass;
        private IAccountService _accountService;
        private IGroupService _groupService;
        private IHttpContextAccessor _contextAccessor;

        [SetUp]
        public void SetUp()
        {
            _accountService = Substitute.For<IAccountService>();
            _groupService = Substitute.For<IGroupService>();
            _contextAccessor = Substitute.For<IHttpContextAccessor>();
            _testClass = new DeleteGroupRequestHandler(_accountService, _groupService, _contextAccessor);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new DeleteGroupRequestHandler(_accountService, _groupService, _contextAccessor);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullAccountService()
        {
            Assert.Throws<ArgumentNullException>(() => new DeleteGroupRequestHandler(default(IAccountService), _groupService, _contextAccessor));
        }

        [Test]
        public void CannotConstructWithNullGroupService()
        {
            Assert.Throws<ArgumentNullException>(() => new DeleteGroupRequestHandler(_accountService, default(IGroupService), _contextAccessor));
        }

        [Test]
        public void CannotConstructWithNullContextAccessor()
        {
            Assert.Throws<ArgumentNullException>(() => new DeleteGroupRequestHandler(_accountService, _groupService, default(IHttpContextAccessor)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new DeleteGroupRequest(1314707223);
            var cancellationToken = CancellationToken.None;

            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue568568847",
                RefreshToken = "TestValue453779139",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 589806871,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1663440526",
                        FollowersCount = 1075800037,
                        NextStatusId = 503361118,
                        UserTarget = 1865493580,
                        AccountId = 1993524947,
                        Account = default(Account)
                    },
                    Cread = "TestValue520275814",
                    Photo = "TestValue1619320887",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1598523102,
                    User = default(User)
                }
            });
            _groupService.GetAsync(Arg.Any<int>()).Returns(new Group
            {
                Name = "TestValue2018560381",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>()
            });
            _contextAccessor.HttpContext.Returns(new DefaultHttpContext());

            // Act
            await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());
            await _groupService.Received().GetAsync(Arg.Any<int>());
            await _groupService.Received().DeleteAsync(Arg.Any<Group>(), Arg.Any<Account>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(DeleteGroupRequest), CancellationToken.None));
        }
    }
}
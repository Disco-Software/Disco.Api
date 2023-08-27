namespace Disco.Test.ApiServices.Features.Group.RequestHandlers.CreateGroup
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Group.RequestHandlers.CreateGroup;
    using Disco.Business.Interfaces.Dtos.Chat;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class CreateGroupRequestHandlerTests
    {
        private CreateGroupRequestHandler _testClass;
        private IAccountService _accountService;
        private IGroupService _groupService;
        private IAccountGroupService _accountGroupService;
        private IHttpContextAccessor _contextAccessor;

        [SetUp]
        public void SetUp()
        {
            _accountService = Substitute.For<IAccountService>();
            _groupService = Substitute.For<IGroupService>();
            _accountGroupService = Substitute.For<IAccountGroupService>();
            _contextAccessor = Substitute.For<IHttpContextAccessor>();
            _testClass = new CreateGroupRequestHandler(_accountService, _groupService, _accountGroupService, _contextAccessor);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new CreateGroupRequestHandler(_accountService, _groupService, _accountGroupService, _contextAccessor);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullAccountService()
        {
            Assert.Throws<ArgumentNullException>(() => new CreateGroupRequestHandler(default(IAccountService), _groupService, _accountGroupService, _contextAccessor));
        }

        [Test]
        public void CannotConstructWithNullGroupService()
        {
            Assert.Throws<ArgumentNullException>(() => new CreateGroupRequestHandler(_accountService, default(IGroupService), _accountGroupService, _contextAccessor));
        }

        [Test]
        public void CannotConstructWithNullAccountGroupService()
        {
            Assert.Throws<ArgumentNullException>(() => new CreateGroupRequestHandler(_accountService, _groupService, default(IAccountGroupService), _contextAccessor));
        }

        [Test]
        public void CannotConstructWithNullContextAccessor()
        {
            Assert.Throws<ArgumentNullException>(() => new CreateGroupRequestHandler(_accountService, _groupService, _accountGroupService, default(IHttpContextAccessor)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new CreateGroupRequest(new CreateGroupRequestDto { UserId = 1344242590 });
            var cancellationToken = CancellationToken.None;

            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue435380401",
                RefreshToken = "TestValue214172563",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1913853410,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1580522384",
                        FollowersCount = 1793150991,
                        NextStatusId = 1089333796,
                        UserTarget = 895610358,
                        AccountId = 1626611859,
                        Account = default(Account)
                    },
                    Cread = "TestValue2012956855",
                    Photo = "TestValue927274400",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 212967815,
                    User = default(User)
                }
            });
            _accountService.GetByIdAsync(Arg.Any<int>()).Returns(new User
            {
                RoleName = "TestValue1346253791",
                RefreshToken = "TestValue1049025146",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1858745277,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue611983100",
                        FollowersCount = 768841010,
                        NextStatusId = 1672051230,
                        UserTarget = 1855172622,
                        AccountId = 1200439829,
                        Account = default(Account)
                    },
                    Cread = "TestValue1716700111",
                    Photo = "TestValue410851083",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 919423522,
                    User = default(User)
                }
            });
            _groupService.CreateAsync().Returns(new Group
            {
                Name = "TestValue1285856173",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>()
            });
            _accountGroupService.CreateAsync(Arg.Any<Account>(), Arg.Any<Group>()).Returns(new AccountGroup
            {
                AccountId = 1410492292,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1862512451",
                        FollowersCount = 1947109691,
                        NextStatusId = 569057982,
                        UserTarget = 1423773118,
                        AccountId = 28088757,
                        Account = default(Account)
                    },
                    Cread = "TestValue2141880121",
                    Photo = "TestValue1760050824",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1636467710,
                    User = new User
                    {
                        RoleName = "TestValue957702899",
                        RefreshToken = "TestValue1657416392",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 16174563,
                        Account = default(Account)
                    }
                },
                GroupId = 1824290141,
                Group = new Group
                {
                    Name = "TestValue279737061",
                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>()
                }
            });
            _contextAccessor.HttpContext.Returns(new DefaultHttpContext());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());
            await _accountService.Received().GetByIdAsync(Arg.Any<int>());
            await _groupService.Received().CreateAsync();
            await _accountGroupService.Received().CreateAsync(Arg.Any<Account>(), Arg.Any<Group>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(CreateGroupRequest), CancellationToken.None));
        }
    }
}
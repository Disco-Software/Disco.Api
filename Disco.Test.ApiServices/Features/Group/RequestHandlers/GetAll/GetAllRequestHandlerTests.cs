namespace Disco.Test.ApiServices.Features.Group.RequestHandlers.GetAll
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Group.RequestHandlers.GetAll;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class GetAllRequestHandlerTests
    {
        private GetAllGroupsRequestHandler _testClass;
        private IAccountService _accountService;
        private IGroupService _groupService;
        private IHttpContextAccessor _contextAccessor;

        [SetUp]
        public void SetUp()
        {
            _accountService = Substitute.For<IAccountService>();
            _groupService = Substitute.For<IGroupService>();
            _contextAccessor = Substitute.For<IHttpContextAccessor>();
            _testClass = new GetAllGroupsRequestHandler(_accountService, _groupService, _contextAccessor);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetAllGroupsRequestHandler(_accountService, _groupService, _contextAccessor);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new GetAllGroupsRequest(1017701661, 1107648813);
            var cancellationToken = CancellationToken.None;

            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue1414847164",
                RefreshToken = "TestValue1589814540",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1962903850,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1067898863",
                        FollowersCount = 503923760,
                        NextStatusId = 1067609521,
                        UserTarget = 500217684,
                        AccountId = 748490104,
                        Account = default(Account)
                    },
                    Cread = "TestValue1923859590",
                    Photo = "TestValue1626232657",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 84443692,
                    User = default(User)
                }
            });
            _groupService.GetAllAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(new[] {
                new Group
                {
                    Name = "TestValue1507053049",
                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>()
                },
                new Group
                {
                    Name = "TestValue1831598025",
                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>()
                },
                new Group
                {
                    Name = "TestValue48316375",
                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>()
                }
            });
            _contextAccessor.HttpContext.Returns(new DefaultHttpContext());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());
            await _groupService.Received().GetAllAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>());
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(GetAllGroupsRequest), CancellationToken.None));
        }
    }
}
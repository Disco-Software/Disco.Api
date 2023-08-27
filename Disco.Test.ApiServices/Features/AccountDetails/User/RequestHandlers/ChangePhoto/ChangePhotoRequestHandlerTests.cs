namespace Disco.Test.ApiServices.Features.AccountDetails.User.RequestHandlers.ChangePhoto
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.ChangePhoto;
    using Disco.ApiServices.Features.AccountPassword.User.RequestHandlers.ResetPassword;
    using Disco.Business.Interfaces.Dtos.AccountDetails;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class ChangePhotoRequestHandlerTests
    {
        private ChangePhotoRequestHandler _testClass;
        private IAccountService _accountService;
        private IAccountPasswordService _accountPasswordService;
        private IAccountDetailsService _accountDetailsService;
        private IHttpContextAccessor _contextAccessor;

        [SetUp]
        public void SetUp()
        {
            _accountService = Substitute.For<IAccountService>();
            _accountPasswordService = Substitute.For<IAccountPasswordService>();
            _accountDetailsService = Substitute.For<IAccountDetailsService>();
            _contextAccessor = Substitute.For<IHttpContextAccessor>();
            _testClass = new ChangePhotoRequestHandler(_accountService, _accountDetailsService, _contextAccessor);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new ChangePhotoRequestHandler(_accountService, _accountDetailsService, _contextAccessor);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullAccountService()
        {
            Assert.Throws<ArgumentNullException>(() => new ChangePhotoRequestHandler(default(IAccountService), _accountDetailsService, _contextAccessor));
        }

        [Test]
        public void CannotConstructWithNullAccountDetailsService()
        {
            Assert.Throws<ArgumentNullException>(() => new ChangePhotoRequestHandler(_accountService, default(IAccountDetailsService), _contextAccessor));
        }

        [Test]
        public void CannotConstructWithNullContextAccessor()
        {
            Assert.Throws<ArgumentNullException>(() => new ChangePhotoRequestHandler(_accountService, _accountDetailsService, default(IHttpContextAccessor)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new ChangePhotoRequest(new UpdateAccountDto { Photo = Substitute.For<IFormFile>() });
            var cancellationToken = CancellationToken.None;

            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue1864715415",
                RefreshToken = "TestValue1323030289",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1992425257,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1580886257",
                        FollowersCount = 1882951508,
                        NextStatusId = 2091768347,
                        UserTarget = 139717059,
                        AccountId = 162258631,
                        Account = default(Account)
                    },
                    Cread = "TestValue1504639067",
                    Photo = "TestValue741999767",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 704024346,
                    User = default(User)
                }
            });
            _accountDetailsService.ChengePhotoAsync(Arg.Any<User>(), Arg.Any<IFormFile>()).Returns(new User
            {
                RoleName = "TestValue1137489230",
                RefreshToken = "TestValue911664758",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 42821282,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue453634755",
                        FollowersCount = 60284683,
                        NextStatusId = 659085559,
                        UserTarget = 2102071559,
                        AccountId = 1482372230,
                        Account = default(Account)
                    },
                    Cread = "TestValue382603196",
                    Photo = "TestValue204184810",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1418928092,
                    User = default(User)
                }
            });
            _contextAccessor.HttpContext.Returns(new DefaultHttpContext());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());
            await _accountDetailsService.Received().ChengePhotoAsync(Arg.Any<User>(), Arg.Any<IFormFile>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(ChangePhotoRequest), CancellationToken.None));
        }
    }
}
namespace Disco.Test.ApiServices.Features.AccountDetails.User.RequestHandlers.GetUserById
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.GetUserById;
    using Disco.Business.Interfaces.Dtos.AccountDetails;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class GetUserByIdRequestHandlerTests
    {
        private GetUserByIdRequestHandler _testClass;
        private IAccountService _accountService;
        private IAccountDetailsService _accountDetailsService;
        private IPostService _postService;
        private IFollowerService _followerService;

        [SetUp]
        public void SetUp()
        {
            _accountService = Substitute.For<IAccountService>();
            _accountDetailsService = Substitute.For<IAccountDetailsService>();
            _postService = Substitute.For<IPostService>();
            _followerService = Substitute.For<IFollowerService>();
            _testClass = new GetUserByIdRequestHandler(_accountService, _accountDetailsService, _postService, _followerService);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetUserByIdRequestHandler(_accountService, _accountDetailsService, _postService, _followerService);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullAccountService()
        {
            Assert.Throws<ArgumentNullException>(() => new GetUserByIdRequestHandler(default(IAccountService), _accountDetailsService, _postService, _followerService));
        }

        [Test]
        public void CannotConstructWithNullAccountDetailsService()
        {
            Assert.Throws<ArgumentNullException>(() => new GetUserByIdRequestHandler(_accountService, default(IAccountDetailsService), _postService, _followerService));
        }

        [Test]
        public void CannotConstructWithNullPostService()
        {
            Assert.Throws<ArgumentNullException>(() => new GetUserByIdRequestHandler(_accountService, _accountDetailsService, default(IPostService), _followerService));
        }

        [Test]
        public void CannotConstructWithNullFollowerService()
        {
            Assert.Throws<ArgumentNullException>(() => new GetUserByIdRequestHandler(_accountService, _accountDetailsService, _postService, default(IFollowerService)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new GetUserByIdRequest(2047066416);
            var cancellationToken = CancellationToken.None;

            _accountService.GetByIdAsync(Arg.Any<int>()).Returns(new User
            {
                RoleName = "TestValue1343967951",
                RefreshToken = "TestValue1664194658",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1756824233,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue459285487",
                        FollowersCount = 1490884511,
                        NextStatusId = 1564274658,
                        UserTarget = 233419405,
                        AccountId = 36901979,
                        Account = default(Account)
                    },
                    Cread = "TestValue918434164",
                    Photo = "TestValue1580901399",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 823404316,
                    User = default(User)
                }
            });
            _accountDetailsService.GetUserDatailsAsync(Arg.Any<User>()).Returns(new UserDetailsResponseDto
            {
                User = new User
                {
                    RoleName = "TestValue1399915685",
                    RefreshToken = "TestValue1068178698",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 2042288036,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue339903839",
                            FollowersCount = 900304433,
                            NextStatusId = 1183069271,
                            UserTarget = 1517705281,
                            AccountId = 1641301633,
                            Account = default(Account)
                        },
                        Cread = "TestValue1820088714",
                        Photo = "TestValue1449011579",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 2033000634,
                        User = default(User)
                    }
                }
            });
            _postService.GetAllUserPosts(Arg.Any<User>()).Returns(new List<Post>());
            _followerService.GetFollowersAsync(Arg.Any<int>()).Returns(new List<UserFollower>());
            _followerService.GetFollowingAsync(Arg.Any<int>()).Returns(new List<UserFollower>());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetByIdAsync(Arg.Any<int>());
            await _accountDetailsService.Received().GetUserDatailsAsync(Arg.Any<User>());
            await _postService.Received().GetAllUserPosts(Arg.Any<User>());
            await _followerService.Received().GetFollowersAsync(Arg.Any<int>());
            await _followerService.Received().GetFollowingAsync(Arg.Any<int>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(GetUserByIdRequest), CancellationToken.None));
        }
    }
}
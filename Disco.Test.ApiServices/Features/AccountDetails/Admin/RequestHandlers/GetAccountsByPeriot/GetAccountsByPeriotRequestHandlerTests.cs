namespace Disco.Test.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAccountsByPeriot
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAccountsByPeriot;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class GetAccountsByPeriotRequestHandlerTests
    {
        private GetAccountsByPeriotRequestHandler _testClass;
        private IAccountService _accountService;

        [SetUp]
        public void SetUp()
        {
            _accountService = Substitute.For<IAccountService>();
            _testClass = new GetAccountsByPeriotRequestHandler(_accountService);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetAccountsByPeriotRequestHandler(_accountService);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new GetAccountsByPeriotRequest(2023635504);
            var cancellationToken = CancellationToken.None;

            _accountService.GetUsersByPeriotAsync(Arg.Any<int>()).Returns(new[] {
                new User
                {
                    RoleName = "TestValue762938508",
                    RefreshToken = "TestValue1653730395",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 340118902,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1526749482",
                            FollowersCount = 1551241348,
                            NextStatusId = 50062274,
                            UserTarget = 2124458420,
                            AccountId = 2080134100,
                            Account = default(Account)
                        },
                        Cread = "TestValue1824197959",
                        Photo = "TestValue922442698",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 388335295,
                        User = default(User)
                    }
                },
                new User
                {
                    RoleName = "TestValue840685596",
                    RefreshToken = "TestValue1437816643",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 874723505,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1351878879",
                            FollowersCount = 1144534660,
                            NextStatusId = 166391527,
                            UserTarget = 1436076828,
                            AccountId = 2000354485,
                            Account = default(Account)
                        },
                        Cread = "TestValue538749847",
                        Photo = "TestValue1823517097",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 169808824,
                        User = default(User)
                    }
                },
                new User
                {
                    RoleName = "TestValue1322370171",
                    RefreshToken = "TestValue1320905596",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1276259816,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue594567515",
                            FollowersCount = 1363414940,
                            NextStatusId = 487117328,
                            UserTarget = 214579066,
                            AccountId = 1107319956,
                            Account = default(Account)
                        },
                        Cread = "TestValue1377661862",
                        Photo = "TestValue1540367214",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 1371807715,
                        User = default(User)
                    }
                }
            });

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetUsersByPeriotAsync(Arg.Any<int>());
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(GetAccountsByPeriotRequest), CancellationToken.None));
        }
    }
}
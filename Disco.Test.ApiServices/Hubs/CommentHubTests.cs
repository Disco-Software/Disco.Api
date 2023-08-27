namespace Disco.Test.ApiServices.Hubs
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.ApiServices.Hubs;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class CommentHubTests
    {
        private CommentHub _testClass;
        private IAccountService _accountService;
        private ICommentService _commentService;
        private IPostService _postService;
        private IConnectionService _connectionService;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _accountService = Substitute.For<IAccountService>();
            _commentService = Substitute.For<ICommentService>();
            _postService = Substitute.For<IPostService>();
            _connectionService = Substitute.For<IConnectionService>();
            _mapper = Substitute.For<IMapper>();
            _testClass = new CommentHub(_accountService, _commentService, _postService, _connectionService, _mapper);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new CommentHub(_accountService, _commentService, _postService, _connectionService, _mapper);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullAccountService()
        {
            Assert.Throws<ArgumentNullException>(() => new CommentHub(default(IAccountService), _commentService, _postService, _connectionService, _mapper));
        }

        [Test]
        public void CannotConstructWithNullCommentService()
        {
            Assert.Throws<ArgumentNullException>(() => new CommentHub(_accountService, default(ICommentService), _postService, _connectionService, _mapper));
        }

        [Test]
        public void CannotConstructWithNullPostService()
        {
            Assert.Throws<ArgumentNullException>(() => new CommentHub(_accountService, _commentService, default(IPostService), _connectionService, _mapper));
        }

        [Test]
        public void CannotConstructWithNullConnectionService()
        {
            Assert.Throws<ArgumentNullException>(() => new CommentHub(_accountService, _commentService, _postService, default(IConnectionService), _mapper));
        }

        [Test]
        public void CannotConstructWithNullMapper()
        {
            Assert.Throws<ArgumentNullException>(() => new CommentHub(_accountService, _commentService, _postService, _connectionService, default(IMapper)));
        }

        [Test]
        public async Task CanCallOnConnectedAsync()
        {
            // Arrange
            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue2122151198",
                RefreshToken = "TestValue1540995888",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1978090855,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1537835942",
                        FollowersCount = 2047995739,
                        NextStatusId = 886442548,
                        UserTarget = 1934317491,
                        AccountId = 12336269,
                        Account = default(Account)
                    },
                    Cread = "TestValue643375101",
                    Photo = "TestValue982039392",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 677025717,
                    User = default(User)
                }
            });

            // Act
            await _testClass.OnConnectedAsync();

            // Assert
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());
            await _connectionService.Received().CreateAsync(Arg.Any<Connection>(), Arg.Any<Account>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public async Task CanCallSendCommentAsync()
        {
            // Arrange
            var message = "TestValue45340498";
            var userId = 1848051632;
            var postId = 1806628922;

            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue1029580193",
                RefreshToken = "TestValue2021471659",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 2028942764,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue149187609",
                        FollowersCount = 433861409,
                        NextStatusId = 2126111989,
                        UserTarget = 1549683692,
                        AccountId = 1719221560,
                        Account = default(Account)
                    },
                    Cread = "TestValue1936599300",
                    Photo = "TestValue1263622583",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1017798150,
                    User = default(User)
                }
            });
            _postService.GetPostAsync(Arg.Any<int>()).Returns(new Post
            {
                Description = "TestValue1456918332",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 42177804,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue2146134026",
                        FollowersCount = 367657890,
                        NextStatusId = 933523654,
                        UserTarget = 1973620368,
                        AccountId = 2040010850,
                        Account = default(Account)
                    },
                    Cread = "TestValue2118324917",
                    Photo = "TestValue1475416725",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 280156188,
                    User = new User
                    {
                        RoleName = "TestValue1614886223",
                        RefreshToken = "TestValue1347252012",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1125904679,
                        Account = default(Account)
                    }
                }
            });

            // Act
            await _testClass.SendCommentAsync(message, userId, postId);

            // Assert
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());
            await _commentService.Received().AddCommentAsync(Arg.Any<Comment>());
            await _postService.Received().GetPostAsync(Arg.Any<int>());

            Assert.Fail("Create or modify test");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallSendCommentAsyncWithInvalidMessage(string value)
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.SendCommentAsync(value, 1752279910, 1301014607));
        }

        [Test]
        public async Task CanCallRemoveCommentAsync()
        {
            // Arrange
            var commentId = 2059622228;
            var postId = 267443359;
            var userId = 71942061;

            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue1281866362",
                RefreshToken = "TestValue1728781534",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 147552176,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue858272135",
                        FollowersCount = 1265182763,
                        NextStatusId = 1085722204,
                        UserTarget = 1445831010,
                        AccountId = 111707016,
                        Account = default(Account)
                    },
                    Cread = "TestValue1368217263",
                    Photo = "TestValue1406921576",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1304046065,
                    User = default(User)
                }
            });
            _commentService.GetCommentAsync(Arg.Any<int>()).Returns(new Comment
            {
                CommentDescription = "TestValue1508223411",
                AccountId = 512326405,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1713544721",
                        FollowersCount = 1982406307,
                        NextStatusId = 1104353048,
                        UserTarget = 84077556,
                        AccountId = 1935913051,
                        Account = default(Account)
                    },
                    Cread = "TestValue1539185563",
                    Photo = "TestValue1680337849",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2100402541,
                    User = new User
                    {
                        RoleName = "TestValue2108180770",
                        RefreshToken = "TestValue119809066",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 672533831,
                        Account = default(Account)
                    }
                },
                PostId = 1654106314,
                Post = new Post
                {
                    Description = "TestValue396869529",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1562177617,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue674219647",
                            FollowersCount = 903038085,
                            NextStatusId = 103847111,
                            UserTarget = 733293424,
                            AccountId = 319483067,
                            Account = default(Account)
                        },
                        Cread = "TestValue1944887429",
                        Photo = "TestValue418206953",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 654732938,
                        User = new User
                        {
                            RoleName = "TestValue1682324696",
                            RefreshToken = "TestValue870245974",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 598646197,
                            Account = default(Account)
                        }
                    }
                }
            });
            _postService.GetPostAsync(Arg.Any<int>()).Returns(new Post
            {
                Description = "TestValue924478688",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1060411822,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1069310527",
                        FollowersCount = 821816638,
                        NextStatusId = 605403105,
                        UserTarget = 633089274,
                        AccountId = 814278852,
                        Account = default(Account)
                    },
                    Cread = "TestValue2114676961",
                    Photo = "TestValue1915313430",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2048825149,
                    User = new User
                    {
                        RoleName = "TestValue1512329352",
                        RefreshToken = "TestValue21551631",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2108746589,
                        Account = default(Account)
                    }
                }
            });

            // Act
            await _testClass.RemoveCommentAsync(commentId, postId, userId);

            // Assert
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());
            await _commentService.Received().GetCommentAsync(Arg.Any<int>());
            await _commentService.Received().RemoveCommentAsync(Arg.Any<Comment>());
            await _postService.Received().GetPostAsync(Arg.Any<int>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public async Task CanCallOnDisconnectedAsync()
        {
            // Arrange
            var exception = new Exception();

            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue1348095713",
                RefreshToken = "TestValue1321169239",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1608972468,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1622501992",
                        FollowersCount = 1351649468,
                        NextStatusId = 868313234,
                        UserTarget = 1671028234,
                        AccountId = 771611363,
                        Account = default(Account)
                    },
                    Cread = "TestValue1356152578",
                    Photo = "TestValue1264370152",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 673628152,
                    User = default(User)
                }
            });
            _connectionService.GetAsync(Arg.Any<string>()).Returns(new Connection
            {
                UserAgent = "TestValue984562998",
                IsConnected = true
            });

            // Act
            await _testClass.OnDisconnectedAsync(exception);

            // Assert
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());
            await _connectionService.Received().GetAsync(Arg.Any<string>());
            await _connectionService.Received().DeleteAsync(Arg.Any<Connection>(), Arg.Any<Account>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallOnDisconnectedAsyncWithNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.OnDisconnectedAsync(default(Exception)));
        }
    }
}
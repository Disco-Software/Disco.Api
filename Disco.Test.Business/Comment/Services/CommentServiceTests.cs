namespace Disco.Test.Business.Comment.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Disco.Business.Services.Services;
    using Disco.Domain.EF;
    using Disco.Domain.Models.Models;
    using Disco.Domain.Repositories.Repositories;
    using Disco.Domain.Repositories.Repositories.Base;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class CommentServiceTests
    {
        private CommentService _testClass;
        
        private Mock<CommentRepository> _commentRepository;

        private List<Comment> _comments = new List<Comment>();

        [SetUp]
        public void SetUp()
        {
            var context = AddMockDbContext();

            _commentRepository = new Mock<CommentRepository>(context.Object);
            _testClass = new CommentService(_commentRepository.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new CommentService(_commentRepository.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallAddCommentAsync()
        {
            // Arrange
            var comment = new Comment
            {
                CommentDescription = "TestValue338016912",
                AccountId = 1282427384,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1905964535",
                        FollowersCount = 821406591,
                        NextStatusId = 1648622646,
                        UserTarget = 117980180,
                        AccountId = 1324546570,
                        Account = default
                    },
                    Cread = "TestValue761857044",
                    Photo = "TestValue540549616",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1549093521,
                    User = new User
                    {
                        RoleName = "TestValue1094762677",
                        RefreshToken = "TestValue175586030",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2081759059,
                        Account = default
                    }
                },
                PostId = 604437407,
                Post = new Post
                {
                    Description = "TestValue745599140",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1235490250,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1665612728",
                            FollowersCount = 1533338776,
                            NextStatusId = 1928843414,
                            UserTarget = 241439673,
                            AccountId = 1663070026,
                            Account = default
                        },
                        Cread = "TestValue1018686555",
                        Photo = "TestValue2006086023",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 1572840122,
                        User = new User
                        {
                            RoleName = "TestValue249286363",
                            RefreshToken = "TestValue1396403314",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 61741159,
                            Account = default
                        }
                    }
                }
            };

            _commentRepository.Setup(x => x.AddAsync(It.IsAny<Comment>()))
                 .Callback(() => _comments.Add(comment));

            // Act
            await _testClass.AddCommentAsync(comment);

            // Assert
            _commentRepository.Verify(x => x.AddAsync(It.IsAny<Comment>()));
        }

        [Test]
        public async Task CanCallRemoveCommentAsync()
        {
            // Arrange
            var comment = new Comment
            {
                CommentDescription = "TestValue1489468232",
                AccountId = 950901948,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1707529144",
                        FollowersCount = 1096337925,
                        NextStatusId = 2048064224,
                        UserTarget = 690604338,
                        AccountId = 234311137,
                        Account = default
                    },
                    Cread = "TestValue949690705",
                    Photo = "TestValue1532537894",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 329386099,
                    User = new User
                    {
                        RoleName = "TestValue1763922999",
                        RefreshToken = "TestValue2057014055",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1248165573,
                        Account = default
                    }
                },
                PostId = 300749810,
                Post = new Post
                {
                    Description = "TestValue1238490620",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1512169922,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1575625425",
                            FollowersCount = 1091667144,
                            NextStatusId = 203563963,
                            UserTarget = 172350670,
                            AccountId = 358898441,
                            Account = default
                        },
                        Cread = "TestValue1776350557",
                        Photo = "TestValue448815615",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 601384242,
                        User = new User
                        {
                            RoleName = "TestValue763976814",
                            RefreshToken = "TestValue1349739638",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1509531037,
                            Account = default
                        }
                    }
                }
            };

            // Act
            await _testClass.RemoveCommentAsync(comment);

            // Assert
            _commentRepository.Verify(x => x.RemoveAsync(It.IsAny<Comment>()));
        }

        [Test]
        public void CannotCallRemoveCommentAsyncWithNullComment()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.RemoveCommentAsync(default));
        }

        [Test]
        public async Task CanCallGetCommentAsync()
        {
            // Arrange
            var id = 1759709381;

            // Act
            var result = await _testClass.GetCommentAsync(id);

            // Assert
            _commentRepository.Verify(x => x.GetAsync(It.IsAny<int>()));
        }

        private Mock<ApiDbContext> AddMockDbContext()
        {
            var options = new DbContextOptionsBuilder<ApiDbContext>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options;
            
            var context = new Mock<ApiDbContext>(options);

            context.Setup(x => x.Database)
                .Returns(new Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade(context.Object));

            return context;
        }
    }
}
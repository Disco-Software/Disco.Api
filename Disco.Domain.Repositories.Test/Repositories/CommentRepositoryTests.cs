namespace Disco.Domain.Repositories.Test
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Disco.Domain.EF;
    using Disco.Domain.Models.Models;
    using Disco.Domain.Repositories.Repositories;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    [TestFixture]
    public class CommentRepositoryTests
    {
        private CommentRepository _testClass;
        private ApiDbContext _ctx;

        [SetUp]
        public void SetUp()
        {
            _ctx = new ApiDbContext(AddMockDbContextOptions());
            _testClass = new CommentRepository(_ctx);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new CommentRepository(_ctx);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallAddAsync()
        {
            // Arrange
            var item = new Comment
            {
                CommentDescription = "TestValue36695988",
                AccountId = 197115249,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue538746890",
                        FollowersCount = 671626892,
                        NextStatusId = 1044176604,
                        UserTarget = 732366588,
                        AccountId = 340252185,
                        Account = default(Account)
                    },
                    Cread = "TestValue354300459",
                    Photo = "TestValue2011543526",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2062724951,
                    User = new User
                    {
                        RoleName = "TestValue638866859",
                        RefreshToken = "TestValue990773408",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1354611317,
                        Account = default(Account)
                    }
                },
                PostId = 1719435635,
                Post = new Post
                {
                    Description = "TestValue1833568051",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 473402911,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue478432581",
                            FollowersCount = 1042420168,
                            NextStatusId = 147794672,
                            UserTarget = 1536184355,
                            AccountId = 973814786,
                            Account = default(Account)
                        },
                        Cread = "TestValue1952303602",
                        Photo = "TestValue2113941217",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 1312584008,
                        User = new User
                        {
                            RoleName = "TestValue1605798118",
                            RefreshToken = "TestValue1636442003",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1271415657,
                            Account = default(Account)
                        }
                    }
                }
            };

            // Act
            await _testClass.AddAsync(item);

            // Assert
            var comments = await _ctx.Comments.ToListAsync();

            comments.Should().NotBeNull();
            comments.Should().HaveCount(1);
        }

        [Test]
        public void CannotCallAddAsyncWithNullItem()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.AddAsync(default(Comment)));
        }

        [Test]
        public async Task CanCallRemove()
        {
            // Arrange
            var item = new Comment
            {
                CommentDescription = "TestValue36695988",
                AccountId = 197115249,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue538746890",
                        FollowersCount = 671626892,
                        NextStatusId = 1044176604,
                        UserTarget = 732366588,
                        AccountId = 340252185,
                        Account = default(Account)
                    },
                    Cread = "TestValue354300459",
                    Photo = "TestValue2011543526",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2062724951,
                    User = new User
                    {
                        RoleName = "TestValue638866859",
                        RefreshToken = "TestValue990773408",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1354611317,
                        Account = default(Account)
                    }
                },
                PostId = 1719435635,
                Post = new Post
                {
                    Description = "TestValue1833568051",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 473402911,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue478432581",
                            FollowersCount = 1042420168,
                            NextStatusId = 147794672,
                            UserTarget = 1536184355,
                            AccountId = 973814786,
                            Account = default(Account)
                        },
                        Cread = "TestValue1952303602",
                        Photo = "TestValue2113941217",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 1312584008,
                        User = new User
                        {
                            RoleName = "TestValue1605798118",
                            RefreshToken = "TestValue1636442003",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1271415657,
                            Account = default(Account)
                        }
                    }
                }
            };

            await _ctx.Comments.AddAsync(item);

            await _ctx.SaveChangesAsync();

            // Act
            await _testClass.Remove(item.Id);

            // Assert
            var comment = await _testClass.GetAsync(item.Id);
        }

        private DbContextOptions<ApiDbContext> AddMockDbContextOptions()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();

            dbContextOptionsBuilder.UseInMemoryDatabase<ApiDbContext>("TestDb");

            return dbContextOptionsBuilder.Options;
        }
    }
}
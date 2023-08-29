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
    public class SongRepositoryTests
    {
        private SongRepository _testClass;
        private ApiDbContext _ctx;

        [SetUp]
        public void SetUp()
        {
            _ctx = new ApiDbContext(AddMockDbContextOptions());
            _testClass = new SongRepository(_ctx);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new SongRepository(_ctx);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallAddAsync()
        {
            // Arrange
            var song = new PostSong
            {
                Name = "TestValue1475691690",
                ImageUrl = "TestValue459941055",
                Source = "TestValue1860198101",
                ExecutorName = "TestValue2080550471",
                PostId = 1473520326,
                Post = new Post
                {
                    Description = "TestValue1156923440",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 608077801,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue733100108",
                            FollowersCount = 2104084635,
                            NextStatusId = 406593881,
                            UserTarget = 673969987,
                            AccountId = 1812622670,
                            Account = default(Account)
                        },
                        Cread = "TestValue525821493",
                        Photo = "TestValue1224499163",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 1384982726,
                        User = new User
                        {
                            RoleName = "TestValue1106271173",
                            RefreshToken = "TestValue335639115",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 221643233,
                            Account = default(Account)
                        }
                    }
                }
            };

            // Act
            await _testClass.AddAsync(song);

            // Assert
            song.Post.PostSongs.Should().NotBeNull();
        }

        [Test]
        public void CannotCallAddAsyncWithNullSong()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.AddAsync(default(PostSong)));
        }

        [Test]
        public async Task CanCallRemoveAsync()
        {
            // Arrange
            var id = 1;
            var post = new Post
            {
                Description = "TestValue1156923440",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 608077801,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue733100108",
                        FollowersCount = 2104084635,
                        NextStatusId = 406593881,
                        UserTarget = 673969987,
                        AccountId = 1812622670,
                        Account = default(Account)
                    },
                    Cread = "TestValue525821493",
                    Photo = "TestValue1224499163",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1384982726,
                    User = new User
                    {
                        RoleName = "TestValue1106271173",
                        RefreshToken = "TestValue335639115",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 221643233,
                        Account = default(Account)
                    }
                }
            };
            var song = new PostSong
            {
                Name = "TestValue1475691690",
                ImageUrl = "TestValue459941055",
                Source = "TestValue1860198101",
                ExecutorName = "TestValue2080550471",
                PostId = 1473520326,
                Post = post
            };

            await _ctx.PostSongs.AddAsync(song);

            await _ctx.SaveChangesAsync();

            // Act
            await _testClass.RemoveAsync(song);

            // Assert
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.GetAsync(id));
        }

        private DbContextOptions<ApiDbContext> AddMockDbContextOptions()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();

            dbContextOptionsBuilder.UseInMemoryDatabase<ApiDbContext>(Guid.NewGuid().ToString());

            return dbContextOptionsBuilder.Options;
        }

    }
}
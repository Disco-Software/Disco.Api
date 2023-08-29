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
    public class ImageRepositoryTests
    {
        private ImageRepository _testClass;
        private ApiDbContext _ctx;

        [SetUp]
        public void SetUp()
        {
            _ctx = new ApiDbContext(AddMockDbContextOptions());
            _testClass = new ImageRepository(_ctx);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new ImageRepository(_ctx);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallAddAsync()
        {
            // Arrange
            var item = new PostImage
            {
                Source = "TestValue1693355988",
                PostId = 1289055417,
                Post = new Post
                {
                    Description = "TestValue100313597",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1532350885,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1965962699",
                            FollowersCount = 1316628158,
                            NextStatusId = 655996766,
                            UserTarget = 1573191090,
                            AccountId = 1529718656,
                            Account = default(Account)
                        },
                        Cread = "TestValue255231795",
                        Photo = "TestValue1336435885",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 1158277240,
                        User = new User
                        {
                            RoleName = "TestValue2023679244",
                            RefreshToken = "TestValue2068014770",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1435080367,
                            Account = default(Account)
                        }
                    }
                }
            };

            // Act
            await _testClass.AddAsync(item);

            _ctx.SaveChanges();

            // Assert
            var result = _ctx.PostImages.First();

            result.Should().NotBeNull();
            result.Post.Should().NotBeNull();
            result.Source.Should().NotBeNull();
            result.PostId.Should().NotBe(0);
        }

        [Test]
        public void CannotCallAddAsyncWithNullItem()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.AddAsync(default(PostImage)));
        }

        [Test]
        public async Task CanCallRemove()
        {
            // Arrange

            var item = new PostImage
            {
                Source = "TestValue1693355988",
                PostId = 1289055417,
                Post = new Post
                {
                    Description = "TestValue100313597",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1532350885,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1965962699",
                            FollowersCount = 1316628158,
                            NextStatusId = 655996766,
                            UserTarget = 1573191090,
                            AccountId = 1529718656,
                            Account = default(Account)
                        },
                        Cread = "TestValue255231795",
                        Photo = "TestValue1336435885",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 1158277240,
                        User = new User
                        {
                            RoleName = "TestValue2023679244",
                            RefreshToken = "TestValue2068014770",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1435080367,
                            Account = default(Account)
                        }
                    }
                }
            };

            await _ctx.PostImages.AddAsync(item);

            await _ctx.SaveChangesAsync();

            // Act
            await _testClass.RemoveAsync(item);

            // Assert
            Assert.ThrowsAsync<NullReferenceException>(async () => await _testClass.GetAsync(item.Id));
        }

        [Test]
        public async Task CanCallGetAsync()
        {
            //Arrange
            var item = new PostImage
            {
                Source = "TestValue1693355988",
                PostId = 1289055417,
                Post = new Post
                {
                    Description = "TestValue100313597",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1532350885,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1965962699",
                            FollowersCount = 1316628158,
                            NextStatusId = 655996766,
                            UserTarget = 1573191090,
                            AccountId = 1529718656,
                            Account = default(Account)
                        },
                        Cread = "TestValue255231795",
                        Photo = "TestValue1336435885",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 1158277240,
                        User = new User
                        {
                            RoleName = "TestValue2023679244",
                            RefreshToken = "TestValue2068014770",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1435080367,
                            Account = default(Account)
                        }
                    }
                }
            };

            await _ctx.PostImages.AddAsync(item);

            await _ctx.SaveChangesAsync();

            //Act
            var result = await _testClass.GetAsync(item.Id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo<PostImage>(item);
        }

        [Test]
        public async Task CannotCallGetAsync()
        {
            Assert.ThrowsAsync<NullReferenceException>(async () => await _testClass.GetAsync(1));
        }

        private DbContextOptions<ApiDbContext> AddMockDbContextOptions()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();

            dbContextOptionsBuilder.UseInMemoryDatabase<ApiDbContext>(Guid.NewGuid().ToString());

            return dbContextOptionsBuilder.Options;
        }

    }
}
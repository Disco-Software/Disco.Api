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
    public class VideoRepositoryTests
    {
        private VideoRepository _testClass;
        private ApiDbContext _ctx;

        [SetUp]
        public void SetUp()
        {
            _ctx = new ApiDbContext(AddMockDbContextOptions());
            _testClass = new VideoRepository(_ctx);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new VideoRepository(_ctx);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallAddAsync()
        {
            // Arrange
            var postVideo = new PostVideo
            {
                VideoSource = "TestValue2055230050",
                PostId = 973005875,
                Post = new Post
                {
                    Description = "TestValue1148833773",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 588080504,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue64736755",
                            FollowersCount = 1565507486,
                            NextStatusId = 1351773223,
                            UserTarget = 1861426870,
                            AccountId = 37336429,
                            Account = default(Account)
                        },
                        Cread = "TestValue968185866",
                        Photo = "TestValue1147318100",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 867629368,
                        User = new User
                        {
                            RoleName = "TestValue130040222",
                            RefreshToken = "TestValue1974299148",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1644707456,
                            Account = default(Account)
                        }
                    }
                }
            };

            postVideo.Post.PostVideos.Add(postVideo);

            // Act
            await _testClass.AddAsync(postVideo);

            // Assert
            postVideo.Post.PostVideos.Should().NotBeEmpty();
        }

        [Test]
        public void CannotCallAddAsyncWithNullPostVideo()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.AddAsync(default(PostVideo)));
        }

        [Test]
        public async Task CanCallRemoveAsync()
        {
            // Arrange
            var postVideo = new PostVideo
            {
                VideoSource = "TestValue2055230050",
                PostId = 973005875,
                Post = new Post
                {
                    Description = "TestValue1148833773",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 588080504,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue64736755",
                            FollowersCount = 1565507486,
                            NextStatusId = 1351773223,
                            UserTarget = 1861426870,
                            AccountId = 37336429,
                            Account = default(Account)
                        },
                        Cread = "TestValue968185866",
                        Photo = "TestValue1147318100",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 867629368,
                        User = new User
                        {
                            RoleName = "TestValue130040222",
                            RefreshToken = "TestValue1974299148",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1644707456,
                            Account = default(Account)
                        }
                    }
                }
            };

            await _ctx.PostVideos.AddAsync(postVideo);

            await _ctx.SaveChangesAsync();

            // Act
            await _testClass.RemoveAsync(postVideo);

            // Assert
            postVideo.Post.PostVideos.Count.Should().Be(0);
        }

        private DbContextOptions<ApiDbContext> AddMockDbContextOptions()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();

            dbContextOptionsBuilder.UseInMemoryDatabase<ApiDbContext>(Guid.NewGuid().ToString());

            return dbContextOptionsBuilder.Options;
        }

    }
}
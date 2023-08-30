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
    public class StoryRepositoryTests
    {
        private StoryRepository _testClass;
        private ApiDbContext _ctx;

        [SetUp]
        public void SetUp()
        {
            _ctx = new ApiDbContext(AddMockDbContextOptions());
            _testClass = new StoryRepository(_ctx);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new StoryRepository(_ctx);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallAddAsync()
        {
            // Arrange
            var story = new Story
            {
                StoryImages = new List<StoryImage>(),
                StoryVideos = new List<StoryVideo>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 161980168,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue254295221",
                        FollowersCount = 728145564,
                        NextStatusId = 888929598,
                        UserTarget = 1341380959,
                        AccountId = 476838644,
                        Account = default(Account)
                    },
                    Cread = "TestValue1643157843",
                    Photo = "TestValue332985052",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1956396971,
                    User = new User
                    {
                        RoleName = "TestValue1038343007",
                        RefreshToken = "TestValue1576332096",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1562917880,
                        Account = default(Account)
                    }
                }
            };

            // Act
            await _testClass.AddAsync(story);

            // Assert
            var result = await _testClass.GetAsync(story.Id);

            result.Should().NotBeNull();
        }

        [Test]
        public void CannotCallAddAsyncWithNullStory()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.AddAsync(default(Story)));
        }

        [Test]
        public async Task CanCallGetAllAsync()
        {
            // Arrange
            var accountId = 1;
            var pageNumber = 1;
            var pageSize = 10;

            var list = new List<Story>
            {
                new Story
                {
                    StoryImages = new List<StoryImage>(),
                    StoryVideos = new List<StoryVideo>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue254295221",
                            FollowersCount = 728145564,
                            NextStatusId = 888929598,
                            UserTarget = 1341380959,
                            AccountId = 476838644,
                            Account = default(Account)
                        },
                        Cread = "TestValue1643157843",
                        Photo = "TestValue332985052",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 1956396971,
                        User = new User
                        {
                            RoleName = "TestValue1038343007",
                            RefreshToken = "TestValue1576332096",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1562917880,
                            Account = default(Account)
                        }
                    }
                },
                new Story
                {
                    StoryImages = new List<StoryImage>(),
                    StoryVideos = new List<StoryVideo>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue254295221",
                            FollowersCount = 728145564,
                            NextStatusId = 888929598,
                            UserTarget = 1341380959,
                            AccountId = 476838644,
                            Account = default(Account)
                        },
                        Cread = "TestValue1643157843",
                        Photo = "TestValue332985052",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 1956396971,
                        User = new User
                        {
                            RoleName = "TestValue1038343007",
                            RefreshToken = "TestValue1576332096",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1562917880,
                            Account = default(Account)
                        }
                    }
                },
                new Story
                {
                    StoryImages = new List<StoryImage>(),
                    StoryVideos = new List<StoryVideo>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue254295221",
                            FollowersCount = 728145564,
                            NextStatusId = 888929598,
                            UserTarget = 1341380959,
                            AccountId = 476838644,
                            Account = default(Account)
                        },
                        Cread = "TestValue1643157843",
                        Photo = "TestValue332985052",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 1956396971,
                        User = new User
                        {
                            RoleName = "TestValue1038343007",
                            RefreshToken = "TestValue1576332096",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1562917880,
                            Account = default(Account)
                        }
                    }
                },
                new Story
            {
                StoryImages = new List<StoryImage>(),
                StoryVideos = new List<StoryVideo>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue254295221",
                        FollowersCount = 728145564,
                        NextStatusId = 888929598,
                        UserTarget = 1341380959,
                        AccountId = 476838644,
                        Account = default(Account)
                    },
                    Cread = "TestValue1643157843",
                    Photo = "TestValue332985052",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1956396971,
                    User = new User
                    {
                        RoleName = "TestValue1038343007",
                        RefreshToken = "TestValue1576332096",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1562917880,
                        Account = default(Account)
                    }
                }
            }
            };

            await _ctx.Stories.AddRangeAsync(list);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetAllAsync(accountId, pageNumber, pageSize);

            // Assert
            result.Should().NotBeNull();
        }

        [Test]
        public async Task CanCallRemove()
        {
            // Arrange
            var id = 1388860481;

            // Act
            await _testClass.RemoveAsync(id);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public async Task CanCallGetAsync()
        {
            // Arrange
            var id = 1;
            var story = new Story
            {
                StoryImages = new List<StoryImage>(),
                StoryVideos = new List<StoryVideo>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 161980168,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue254295221",
                        FollowersCount = 728145564,
                        NextStatusId = 888929598,
                        UserTarget = 1341380959,
                        AccountId = 476838644,
                        Account = default(Account)
                    },
                    Cread = "TestValue1643157843",
                    Photo = "TestValue332985052",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1956396971,
                    User = new User
                    {
                        RoleName = "TestValue1038343007",
                        RefreshToken = "TestValue1576332096",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1562917880,
                        Account = default(Account)
                    }
                }
            };

            await _ctx.Stories.AddAsync(story);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetAsync(id);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(id);
        }

        private DbContextOptions<ApiDbContext> AddMockDbContextOptions()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();

            dbContextOptionsBuilder.UseInMemoryDatabase<ApiDbContext>(Guid.NewGuid().ToString());

            return dbContextOptionsBuilder.Options;
        }

    }
}
namespace Disco.Domain.Repositories.Test
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Disco.Domain.EF;
    using Disco.Domain.Models.Models;
    using Disco.Domain.Repositories.Repositories;
    using NUnit.Framework;

    [TestFixture]
    public class StoryImageRepositoryTests
    {
        private StoryImageRepository _testClass;
        private ApiDbContext _ctx;

        [SetUp]
        public void SetUp()
        {
            _ctx = new ApiDbContext();
            _testClass = new StoryImageRepository(_ctx);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new StoryImageRepository(_ctx);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullCtx()
        {
            Assert.Throws<ArgumentNullException>(() => new StoryImageRepository(default(ApiDbContext)));
        }

        [Test]
        public async Task CanCallAddAsync()
        {
            // Arrange
            var item = new StoryImage
            {
                Source = "TestValue496353599",
                DateOfCreation = DateTime.UtcNow,
                StoryId = 496053128,
                Story = new Story
                {
                    StoryImages = new List<StoryImage>(),
                    StoryVideos = new List<StoryVideo>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1912373861,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue2006284118",
                            FollowersCount = 725969037,
                            NextStatusId = 1105240788,
                            UserTarget = 1241581821,
                            AccountId = 565019639,
                            Account = default(Account)
                        },
                        Cread = "TestValue111389351",
                        Photo = "TestValue1441522144",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 1190328538,
                        User = new User
                        {
                            RoleName = "TestValue611761612",
                            RefreshToken = "TestValue30062360",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 2084588480,
                            Account = default(Account)
                        }
                    }
                }
            };

            // Act
            await _testClass.AddAsync(item);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallAddAsyncWithNullItem()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.AddAsync(default(StoryImage)));
        }

        [Test]
        public async Task CanCallRemove()
        {
            // Arrange
            var id = 978852259;

            // Act
            await _testClass.Remove(id);

            // Assert
            Assert.Fail("Create or modify test");
        }
    }
}
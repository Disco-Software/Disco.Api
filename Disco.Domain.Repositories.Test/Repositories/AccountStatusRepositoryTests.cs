namespace Disco.Domain.Repositories.Test
{
    using System;
    using System.Threading.Tasks;
    using Disco.Domain.EF;
    using Disco.Domain.Models.Models;
    using Disco.Domain.Repositories.Repositories;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    [TestFixture]
    public class AccountStatusRepositoryTests
    {
        private AccountStatusRepository _testClass;
        private ApiDbContext _ctx;

        [SetUp]
        public void SetUp()
        {
            _ctx = new ApiDbContext(AddMockDbContextOptions());
            _testClass = new AccountStatusRepository(_ctx);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new AccountStatusRepository(_ctx);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallGetStatusByFollowersCountAsync()
        {
            // Arrange
            var followersCount = 1000000;

            var statuses = new List<Status>
            {
                new Status { Id = 1, FollowersCount = 0, LastStatus = "Newbie", NextStatusId = 2, UserTarget = 1000 },
                new Status { Id = 2, FollowersCount = 1000, LastStatus = "Music lover", NextStatusId = 3, UserTarget = 10000 },
                new Status { Id = 3, FollowersCount = 10000, LastStatus = "Music Master", NextStatusId = 4, UserTarget = 1000000 },
                new Status { Id = 5, FollowersCount = 1000000, LastStatus = "Music Profesor", NextStatusId = 5, UserTarget = 10000000 },
            };

            _ctx.Statuses.AddRange(statuses);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetStatusByFollowersCountAsync(followersCount);

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task GetStatusByFollowersCountAsyncPerformsMapping()
        {
            // Arrange
            var followersCount = 1000000;

            var statuses = new List<Status>
            {
                new Status { Id = 1, FollowersCount = 0, LastStatus = "Newbie", NextStatusId = 2, UserTarget = 1000 },
                new Status { Id = 2, FollowersCount = 1000, LastStatus = "Music lover", NextStatusId = 3, UserTarget = 10000 },
                new Status { Id = 3, FollowersCount = 10000, LastStatus = "Music Master", NextStatusId = 4, UserTarget = 1000000 },
                new Status { Id = 4, FollowersCount = 1000000, LastStatus = "Music Profesor", NextStatusId = 5, UserTarget = 10000000 },
            };

            await _ctx.Statuses.AddRangeAsync(statuses);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetStatusByFollowersCountAsync(followersCount);

            // Assert
            Assert.That(result.FollowersCount, Is.EqualTo(followersCount));
        }

        private DbContextOptions<ApiDbContext> AddMockDbContextOptions()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();

            dbContextOptionsBuilder.UseInMemoryDatabase<ApiDbContext>("TestDb");

            return dbContextOptionsBuilder.Options;
        }
    }
}
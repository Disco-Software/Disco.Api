namespace Disco.Domain.Repositories.Test
{
    using System;
    using System.Threading.Tasks;
    using Disco.Domain.EF;
    using Disco.Domain.Models.Models;
    using Disco.Domain.Repositories.Repositories;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    [TestFixture]
    public class RoleRepositoryTests
    {
        private RoleRepository _testClass;
        private ApiDbContext _ctx;

        [SetUp]
        public void SetUp()
        {
            _ctx = new ApiDbContext(AddMockDbContextOptions());
            _testClass = new RoleRepository(_ctx);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new RoleRepository(_ctx);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallGetAll()
        {
            // Arrange
            var pageNumber = 1;
            var pageSize = 5;

            var roles = new List<Role>
            {
                new Role {Name = "Admin", NormalizedName = "ADMIN"},
                new Role {Name = "User", NormalizedName = "USER"}
            };

            await _ctx.Roles.AddRangeAsync(roles);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetAll(pageNumber, pageSize);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(2);
        }

        private DbContextOptions<ApiDbContext> AddMockDbContextOptions()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();

            dbContextOptionsBuilder.UseInMemoryDatabase<ApiDbContext>(Guid.NewGuid().ToString());

            return dbContextOptionsBuilder.Options;
        }

    }
}
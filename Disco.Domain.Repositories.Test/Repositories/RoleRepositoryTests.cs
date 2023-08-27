namespace Disco.Domain.Repositories.Test
{
    using System;
    using System.Threading.Tasks;
    using Disco.Domain.EF;
    using Disco.Domain.Repositories.Repositories;
    using NUnit.Framework;

    [TestFixture]
    public class RoleRepositoryTests
    {
        private RoleRepository _testClass;
        private ApiDbContext _ctx;

        [SetUp]
        public void SetUp()
        {
            _ctx = new ApiDbContext();
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
        public void CannotConstructWithNullCtx()
        {
            Assert.Throws<ArgumentNullException>(() => new RoleRepository(default(ApiDbContext)));
        }

        [Test]
        public async Task CanCallGetAll()
        {
            // Arrange
            var pageNumber = 1972045289;
            var pageSize = 955994183;

            // Act
            var result = await _testClass.GetAll(pageNumber, pageSize);

            // Assert
            Assert.Fail("Create or modify test");
        }
    }
}
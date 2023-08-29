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
    public class ConnectionRepositoryTests
    {
        private ConnectionRepository _testClass;
        private ApiDbContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new ApiDbContext(AddMockDbContextOptions());
            _testClass = new ConnectionRepository(_context);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new ConnectionRepository(_context);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreateAsync()
        {
            // Arrange
            var connection = new Connection
            {
                Id = Guid.NewGuid().ToString(),
                UserAgent = "TestValue1152922737",
                IsConnected = true
            };

            // Act
            await _testClass.CreateAsync(connection);

            // Assert
            var connections = await _context.Connections.ToListAsync();

            Assert.That(connections, Is.Not.Null);
            Assert.That(connections.Count, Is.EqualTo(1));
            Assert.That(connections[0].Id, Is.EqualTo(connection.Id));
            Assert.That(connections[0].UserAgent, Is.EqualTo(connection.UserAgent));
            Assert.That(connections[0].IsConnected, Is.True);
        }

        [Test]
        public void CannotCallCreateAsyncWithNullConnection()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.CreateAsync(default(Connection)));
        }

        [Test]
        public async Task CanCallDeleteAsync()
        {
            // Arrange
            var connection = new Connection
            {
                Id = Guid.NewGuid().ToString(),
                UserAgent = "TestValue1826639618",
                IsConnected = true
            };

            _context.Connections.Add(connection);

            await _context.SaveChangesAsync();

            // Act
            await _testClass.DeleteAsync(connection);

            // Assert
            var result = await _context.Connections.ToListAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void CannotCallDeleteAsyncWithNullConnection()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.DeleteAsync(default(Connection)));
        }

        [Test]
        public async Task CanCallGetAsync()
        {
            // Arrange
            var id = "TestValue246135553";

            var connection = new Connection
            {
                Id = "TestValue246135553",
                UserAgent = "TestValue1826639618",
                IsConnected = true
            };

            await _context.Connections.AddAsync(connection);

            await _context.SaveChangesAsync();

            // Act
            var result = await _testClass.GetAsync(id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.True(result.IsConnected);
            Assert.AreEqual(id, result.Id);
        }

        [Test]
        public async Task CanCallUpdateAsync()
        {
            // Arrange

            var oldUserAgent = "TestValue1173567571";
            var newUserAgent = Guid.NewGuid().ToString();

            var connection = new Connection
            {
                Id = Guid.NewGuid().ToString(),
                UserAgent = oldUserAgent,
                IsConnected = false
            };

            await _context.Connections.AddAsync(connection);

            await _context.SaveChangesAsync();

            connection.UserAgent = newUserAgent;

            // Act
            var result = await _testClass.UpdateAsync(connection);

            // Assert
            result.UserAgent.Should().BeEquivalentTo(newUserAgent);
            result.UserAgent.Should().NotBeEquivalentTo(oldUserAgent);
        }

        [Test]
        public void CannotCallUpdateAsyncWithNullConnection()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.UpdateAsync(default(Connection)));
        }

        private DbContextOptions<ApiDbContext> AddMockDbContextOptions()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();

            dbContextOptionsBuilder.UseInMemoryDatabase<ApiDbContext>(Guid.NewGuid().ToString());

            return dbContextOptionsBuilder.Options;
        }
    }
}
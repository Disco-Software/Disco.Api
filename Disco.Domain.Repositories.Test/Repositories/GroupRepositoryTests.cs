namespace Disco.Domain.Repositories.Test
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.Domain.EF;
    using Disco.Domain.Models.Models;
    using Disco.Domain.Repositories;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    [TestFixture]
    public class GroupRepositoryTests
    {
        private GroupRepository _testClass;
        private ApiDbContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new ApiDbContext(AddMockDbContextOptions());
            _testClass = new GroupRepository(_context);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GroupRepository(_context);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreateAsync()
        {
            // Arrange
            var @group = new Group
            {
                Name = "TestValue587194657",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>
                {
                    new AccountGroup
                    {
                        Account = new Account
                        {
                            User = new User
                            {
                                RoleName = "User",
                                UserName = "Vasya_Pupkin",
                                Email = "vas.pupkin@gmailcom"
                            },
                        },
                        Group = default,
                        AccountId = 1,
                    },
                    new AccountGroup
                    {
                        Account = new Account
                        {
                            User = new User
                            {
                                RoleName = "User",
                                UserName = "serhii_pupkin",
                                Email = "s.pupkin@gmailcom"
                            },
                        },
                        Group = default,
                        AccountId = 1,
                    },
                }
            };

            // Act
            await _testClass.CreateAsync(group);

            // Assert
            var result = await _context.Groups.ToListAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void CannotCallCreateAsyncWithNullGroup()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.CreateAsync(default(Group), CancellationToken.None));
        }

        [Test]
        public async Task CanCallDeleteAsync()
        {
            // Arrange
            var @group = new Group
            {
                Name = "TestValue799033721",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>()
            };
            var cancellationToken = CancellationToken.None;

            _context.Groups.Add(group);

            await _context.SaveChangesAsync();

            // Act
            await _testClass.DeleteAsync(group, cancellationToken);

            // Assert
            var result = await _context.Groups.ToListAsync();

            result.Should().NotBeNull();
            result.Count.Should().Be(0);
        }

        [Test]
        public void CannotCallDeleteAsyncWithNullGroup()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.DeleteAsync(default(Group), CancellationToken.None));
        }

        [Test]
        public async Task CanCallGetAllAsync()
        {
            // Arrange
            var id = 799590328;
            var pageNumber = 895752728;
            var pageSize = 235786818;

            var account = new Account
            {
                User = new User
                {
                    RoleName = "User",
                    UserName = "serhii_pupkin",
                    Email = "s.pupkin@gmailcom"
                },
            };


            var @group = new Group
            {
                Name = "TestValue587194657",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>
                {
                    new AccountGroup
                    {
                        Account = new Account
                        {
                            User = new User
                            {
                                RoleName = "User",
                                UserName = "Vasya_Pupkin",
                                Email = "vas.pupkin@gmailcom"
                            },
                        },
                        Group = default,
                        AccountId = 1,
                    },
                    new AccountGroup
                    {
                        Account = new Account
                        {
                            User = new User
                            {
                                RoleName = "User",
                                UserName = "serhii_pupkin",
                                Email = "s.pupkin@gmailcom"
                            },
                        },
                        Group = default,
                        AccountId = 1,
                    },
                }
            };

            await _context.Groups.AddAsync(group);

            await _context.SaveChangesAsync();

            // Act
            var result = await _testClass.GetAllAsync(id, pageNumber, pageSize);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(1);
        }

        [Test]
        public async Task CanCallUpdateAsync()
        {
            // Arrange
            var oldName = "TestValue595563147";

            var @group = new Group
            {
                Name = "TestValue595563147",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>()
            };
            var cancellationToken = CancellationToken.None;

            await _context.Groups.AddAsync(group);

            await _context.SaveChangesAsync(cancellationToken);

            var newName = Guid.NewGuid().ToString();

            group.Name = newName;

            // Act
            await _testClass.UpdateAsync(group, cancellationToken);

            // Assert
            group.Name.Should().BeEquivalentTo(newName);
            group.Name.Should().NotBeEquivalentTo(oldName);
        }

        [Test]
        public void CannotCallUpdateAsyncWithNullGroup()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.UpdateAsync(default(Group), CancellationToken.None));
        }

        [Test]
        public async Task CanCallGetAsync()
        {
            // Arrange
            var @group = new Group
            {
                Name = "TestValue595563147",
                Messages = new List<Message>(),
                AccountGroups = new List<AccountGroup>()
            };
            var cancellationToken = CancellationToken.None;

            await _context.Groups.AddAsync(group);

            await _context.SaveChangesAsync(cancellationToken);

            // Act
            var result = await _testClass.GetAsync(group.Id);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().NotBeNull();
        }

        private DbContextOptions<ApiDbContext> AddMockDbContextOptions()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();

            dbContextOptionsBuilder.UseInMemoryDatabase<ApiDbContext>("TestDb");

            return dbContextOptionsBuilder.Options;
        }
    }
}
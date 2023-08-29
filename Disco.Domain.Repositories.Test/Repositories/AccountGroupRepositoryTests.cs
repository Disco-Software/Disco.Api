namespace Disco.Test.Domain.Repositories.Test
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.Domain.EF;
    using Disco.Domain.Models.Models;
    using Disco.Domain.Repositories.Repositories;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Moq.EntityFrameworkCore;
    using NUnit.Framework;

    [TestFixture]
    public class AccountGroupRepositoryTests
    {
        private AccountGroupRepository _testClass;
        private ApiDbContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new ApiDbContext(AddMockDbContextOptions());
            _testClass = new AccountGroupRepository(_context);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new AccountGroupRepository(_context);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreateAsync()
        {
            // Arrange
            var accountGroup = new AccountGroup
            {
                AccountId = 534102324,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1989366677",
                        FollowersCount = 483813007,
                        NextStatusId = 220204162,
                        UserTarget = 1797865793,
                        AccountId = 214602602,
                        Account = default(Account)
                    },
                    Cread = "TestValue1255935663",
                    Photo = "TestValue854922445",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1136048695,
                    User = new User
                    {
                        RoleName = "TestValue1688158008",
                        RefreshToken = "TestValue1400573951",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1824552740,
                        Account = default(Account)
                    }
                },
                GroupId = 1161252808,
                Group = new Group
                {
                    Name = "TestValue25521408",
                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>()
                }
            };

            // Act
            await _testClass.CreateAsync(accountGroup);

            // Assert
            Assert.GreaterOrEqual(1, accountGroup.Id);

            var inserted = await _context.AccountGroups.FindAsync(accountGroup.Id);

            Assert.IsNotNull(inserted);
            Assert.That(inserted, Is.EqualTo(accountGroup));
        }

        [Test]
        public void CannotCallCreateAsyncWithNullAccountGroup()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.CreateAsync(default(AccountGroup)));
        }

        [Test]
        public async Task CanCallDeleteAsync()
        {
            // Arrange
            var accountGroup = new AccountGroup
            {
                AccountId = 1926970739,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue514781313",
                        FollowersCount = 116341677,
                        NextStatusId = 1949829956,
                        UserTarget = 1166175397,
                        AccountId = 725605571,
                        Account = default(Account)
                    },
                    Cread = "TestValue1759540079",
                    Photo = "TestValue1645463581",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2032721582,
                    User = new User
                    {
                        RoleName = "TestValue1802081210",
                        RefreshToken = "TestValue1864985435",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 671568980,
                        Account = default(Account)
                    }
                },
                GroupId = 1459565785,
                Group = new Group
                {
                    Name = "TestValue1274961191",
                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>()
                }
            };

            await _context.AccountGroups.AddAsync(accountGroup);

            await _context.SaveChangesAsync();

            // Act
            await _testClass.DeleteAsync(accountGroup);

            // Assert
            var item = await _testClass.GetAsync(accountGroup.Id);

            Assert.IsNull(item);
        }

        [Test]
        public void CannotCallDeleteAsyncWithNullAccountGroup()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.DeleteAsync(default(AccountGroup)));
        }

        [Test]
        public async Task CanCallGetAllAsync()
        {
            // Arrange
            var accountGroup = new AccountGroup
            {
                AccountId = 1926970739,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue514781313",
                        FollowersCount = 116341677,
                        NextStatusId = 1949829956,
                        UserTarget = 1166175397,
                        AccountId = 725605571,
                        Account = default(Account)
                    },
                    Cread = "TestValue1759540079",
                    Photo = "TestValue1645463581",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2032721582,
                    User = new User
                    {
                        RoleName = "TestValue1802081210",
                        RefreshToken = "TestValue1864985435",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 671568980,
                        Account = default(Account)
                    }
                },
                GroupId = 1459565785,
                Group = new Group
                {
                    Name = "TestValue1274961191",
                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>()
                }
            };

            await _context.AccountGroups.AddAsync(accountGroup);

            await _context.SaveChangesAsync();

            // Act
            var result = await _testClass.GetAllAsync(accountGroup.Id);

            // Assert
            result.Should().HaveCount(1).And.Subject.Single().Should().BeEquivalentTo(accountGroup);
        }

        private DbContextOptions<ApiDbContext> AddMockDbContextOptions()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();

            dbContextOptionsBuilder.UseInMemoryDatabase<ApiDbContext>(Guid.NewGuid().ToString());

             return dbContextOptionsBuilder.Options;
        }

        private List<AccountGroup> AssignAccountGroups()
        {
            return new List<AccountGroup>
            {
                new AccountGroup { Account = new Account { Id = 1, User= new User { UserName = "Vasya_Pupkin", Email = "vasya@gmail.com"} }, Group = new Group {Name = Guid.NewGuid().ToString() } }, 
                new AccountGroup { Account = new Account { Id = 2, User= new User { UserName = "Vasya_Pupkin", Email = "vasya@gmail.com"} }, Group = new Group {Name = Guid.NewGuid().ToString() } }, 
                new AccountGroup { Account = new Account { Id = 3, User= new User { UserName = "Vasya_Pupkin", Email = "vasya@gmail.com"} }, Group = new Group {Name = Guid.NewGuid().ToString() } }, 
                new AccountGroup { Account = new Account { Id = 4, User= new User { UserName = "Vasya_Pupkin", Email = "vasya@gmail.com"} }, Group = new Group {Name = Guid.NewGuid().ToString() } }, 
                new AccountGroup { Account = new Account { Id = 5, User= new User { UserName = "Vasya_Pupkin", Email = "vasya@gmail.com"} }, Group = new Group {Name = Guid.NewGuid().ToString() } }, 
                new AccountGroup { Account = new Account { Id = 6, User= new User { UserName = "Vasya_Pupkin", Email = "vasya@gmail.com"} }, Group = new Group {Name = Guid.NewGuid().ToString() } }, 
                new AccountGroup { Account = new Account { Id = 7, User= new User { UserName = "Vasya_Pupkin", Email = "vasya@gmail.com"} }, Group = new Group {Name = Guid.NewGuid().ToString() } }, 
                new AccountGroup { Account = new Account { Id = 8, User= new User { UserName = "Vasya_Pupkin", Email = "vasya@gmail.com"} }, Group = new Group {Name = Guid.NewGuid().ToString() } }, 
                new AccountGroup { Account = new Account { Id = 9, User= new User { UserName = "Vasya_Pupkin", Email = "vasya@gmail.com"} }, Group = new Group {Name = Guid.NewGuid().ToString() } }, 
                new AccountGroup { Account = new Account { Id = 10, User= new User { UserName = "Vasya_Pupkin", Email = "vasya@gmail.com"} }, Group = new Group {Name = Guid.NewGuid().ToString() } }, 
                new AccountGroup { Account = new Account { Id = 11, User= new User { UserName = "Vasya_Pupkin", Email = "vasya@gmail.com"} }, Group = new Group {Name = Guid.NewGuid().ToString() } }, 
            };
        }

    }
}
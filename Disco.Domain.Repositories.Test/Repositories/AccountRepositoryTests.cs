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
    public class AccountRepositoryTests
    {
        private AccountRepository _testClass;
        private ApiDbContext _ctx;

        [SetUp]
        public void SetUp()
        {
            _ctx = new ApiDbContext(AddMockDbContextOptions());
            _testClass = new AccountRepository(_ctx);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new AccountRepository(_ctx);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallGetAsync()
        {
            // Arrange
            var account = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue650235227",
                    FollowersCount = 905885573,
                    NextStatusId = 1126760647,
                    UserTarget = 1447029159,
                    AccountId = 739941493,
                    Account = default(Account)
                },
                Cread = "TestValue216300669",
                Photo = "TestValue1036122390",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 2104128742,
                User = new User
                {
                    RoleName = "TestValue829215444",
                    RefreshToken = "TestValue502702374",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1126296813,
                    Account = default(Account)
                }
            };

            _ctx.Accounts.Add(account);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetAsync(account.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task CanCallGetAccountAsync()
        {
            // Arrange
            var account = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue650235227",
                    FollowersCount = 905885573,
                    NextStatusId = 1126760647,
                    UserTarget = 1447029159,
                    AccountId = 739941493,
                    Account = default(Account)
                },
                Cread = "TestValue216300669",
                Photo = "TestValue1036122390",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 2104128742,
                User = new User
                {
                    RoleName = "TestValue829215444",
                    RefreshToken = "TestValue502702374",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1126296813,
                    Account = default(Account)
                }
            };

            _ctx.Accounts.Add(account);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetAccountAsync(account.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.SameAs(account));
        }

        [Test]
        public async Task CanCallUpdate()
        {
            // Arrange
            var account = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue650235227",
                    FollowersCount = 905885573,
                    NextStatusId = 1126760647,
                    UserTarget = 1447029159,
                    AccountId = 739941493,
                    Account = default(Account)
                },
                Cread = "TestValue216300669",
                Photo = "TestValue1036122390",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 2104128742,
                User = new User
                {
                    RoleName = "TestValue829215444",
                    RefreshToken = "TestValue502702374",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1126296813,
                    Account = default(Account)
                }
            };
            var newItem = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue650235227",
                    FollowersCount = 905885573,
                    NextStatusId = 1126760647,
                    UserTarget = 1447029159,
                    AccountId = 739941493,
                    Account = default(Account)
                },
                Cread = "TestValue216300669",
                Photo = "TestValue1036122390",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 2104128742,
                User = new User
                {
                    RoleName = "TestValue829215444",
                    RefreshToken = "TestValue502702374",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1126296813,
                    Account = default(Account)
                }
            };

            _ctx.Accounts.Add(account);

            _ctx.SaveChanges();

            // Act
            var result = await _testClass.Update(newItem);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.SameAs(account));
        }

        [Test]
        public void CannotCallUpdateWithNullNewItem()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Update(default(Account)));
        }

        [Test]
        public async Task CanCallRemoveAccountAsync()
        {
            //Arrange
            var account = new Account
            {
                Cread = "TestValue216300669",
                Photo = "TestValue1036122390",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 2104128742,
                User = new User
                {
                    RoleName = "TestValue829215444",
                    RefreshToken = "TestValue502702374",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    UserName = "vasya_pupkin",
                    Email = "vasya.pupkin@gmail.com",
                    AccountId = 1126296813,
                    Account = default(Account)
                }
            };

            await _ctx.Accounts.AddAsync(account);
            
            await _ctx.SaveChangesAsync();

            // Act
            await _testClass.RemoveAccountAsync(account);

            // Assert
            Assert.That(_ctx.Accounts, Is.Empty);
        }

        [Test]
        public async Task CanCallGetAllAccountConnectionsAsync()
        {
            // Arrange
            var accountId = 7;

            var list = new List<Account>()
            {
                new Account { Id = 1, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
                new Account { Id = 2, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
                new Account { Id = 3, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
                new Account { Id = 4, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
                new Account { Id = 5, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
                new Account { Id = 6, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
                new Account { Id = 7, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
                new Account { Id = 8, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
                new Account { Id = 9, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
                new Account { Id = 10, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
                new Account { Id = 11, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
            };

            await _ctx.AddRangeAsync(list);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetAllAccountConnectionsAsync(accountId);

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task CanCallFindAccountsByUserNameAsync()
        {
            // Arrange
            var search = "TestValue1078495410";

            var list = new List<Account>
            {
                new Account{ User = new User{UserName = "TestValue1078495410" } },
                new Account{ User = new User{UserName = "TestValue1078495411" } },
                new Account{ User = new User{UserName = "TestValue1078495412" } },
                new Account{ User = new User{UserName = "TestValue1078495413" } },
                new Account{ User = new User{UserName = "TestValue1078495414" } },
                new Account{ User = new User{UserName = "TestValue1078495415" } },
                new Account{ User = new User{UserName = "TestValue1078495416" } },
                new Account{ User = new User{UserName = "TestValue1078495417" } },
                new Account{ User = new User{UserName = "TestValue1078495418" } },
                new Account{ User = new User{UserName = "TestValue1078495419" } },
                new Account{ User = new User{UserName = "TestValue1078495420" } },
                new Account{ User = new User{UserName = "TestValue1078495421" } },
                new Account{ User = new User{UserName = "TestValue1078495422" } },
                new Account{ User = new User{UserName = "TestValue1078495423" } },
                new Account{ User = new User{UserName = "TestValue1078495424" } },
            };

            await _ctx.AddRangeAsync(list);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.FindAccountsByUserNameAsync(search);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.FirstOrDefault(x => x.User.UserName == search).User.UserName, Is.SameAs(search));
        }

        [Test]
        public async Task CanCallGetAllAsync()
        {
            // Arrange
            var pageNumber = 98310346;
            var pageSize = 2010732508;

            var list = new List<Account>()
            {
                new Account { Id = 1, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
                new Account { Id = 2, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
                new Account { Id = 3, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
                new Account { Id = 4, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
                new Account { Id = 5, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
                new Account { Id = 6, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
                new Account { Id = 7, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
                new Account { Id = 8, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
                new Account { Id = 9, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
                new Account { Id = 10, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
                new Account { Id = 11, User = new User{ UserName = "vasya", RoleName = "admin", Email = "pupkin@gmail.com"} },
            };

            await _ctx.Accounts.AddRangeAsync(list);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetAllAsync(pageNumber, pageSize);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(11));
        }

        private DbContextOptions<ApiDbContext> AddMockDbContextOptions()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();

            dbContextOptionsBuilder.UseInMemoryDatabase<ApiDbContext>("TestDb");

            return dbContextOptionsBuilder.Options;
        }
    }
}
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
    public class FollowerRepositoryTests
    {
        private FollowerRepository _testClass;
        private ApiDbContext _ctx;

        [SetUp]
        public void SetUp()
        {
            _ctx = new ApiDbContext(AddMockDbContextOptions());
            _testClass = new FollowerRepository(_ctx);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new FollowerRepository(_ctx);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallAddAsync()
        {
            // Arrange
            var userFollower = new UserFollower
            {
                FollowingAccountId = 1483342182,
                FollowingAccount = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1300516958",
                        FollowersCount = 1164659103,
                        NextStatusId = 201997717,
                        UserTarget = 1916648624,
                        AccountId = 1396711241,
                        Account = default(Account)
                    },
                    Cread = "TestValue286185564",
                    Photo = "TestValue56081690",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 212014225,
                    User = new User
                    {
                        RoleName = "TestValue1836671654",
                        RefreshToken = "TestValue480811581",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 120344162,
                        Account = default(Account)
                    }
                },
                FollowerAccountId = 2085581526,
                FollowerAccount = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue435733197",
                        FollowersCount = 601835174,
                        NextStatusId = 1742379262,
                        UserTarget = 519336544,
                        AccountId = 953899106,
                        Account = default(Account)
                    },
                    Cread = "TestValue1350452288",
                    Photo = "TestValue522202676",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 111758744,
                    User = new User
                    {
                        RoleName = "TestValue1393071654",
                        RefreshToken = "TestValue736006282",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1905863903,
                        Account = default(Account)
                    }
                },
                IsFollowing = true
            };

            // Act
            await _testClass.AddAsync(userFollower);

            // Assert
            var result = await _ctx.UserFollowers.ToListAsync();

            result.Count.Should().NotBe(0);
            result.Count.Should().Be(1);
        }

        [Test]
        public void CannotCallAddAsyncWithNullUserFollower()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.AddAsync(default(UserFollower)));
        }

        [Test]
        public async Task CanCallGetAsync()
        {
            // Arrange
            var userFollower = new UserFollower
            {
                FollowingAccountId = 1483342182,
                FollowingAccount = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1300516958",
                        FollowersCount = 1164659103,
                        NextStatusId = 201997717,
                        UserTarget = 1916648624,
                        AccountId = 1396711241,
                        Account = default(Account)
                    },
                    Cread = "TestValue286185564",
                    Photo = "TestValue56081690",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 212014225,
                    User = new User
                    {
                        RoleName = "TestValue1836671654",
                        RefreshToken = "TestValue480811581",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 120344162,
                        Account = default(Account)
                    }
                },
                FollowerAccountId = 2085581526,
                FollowerAccount = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue435733197",
                        FollowersCount = 601835174,
                        NextStatusId = 1742379262,
                        UserTarget = 519336544,
                        AccountId = 953899106,
                        Account = default(Account)
                    },
                    Cread = "TestValue1350452288",
                    Photo = "TestValue522202676",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 111758744,
                    User = new User
                    {
                        RoleName = "TestValue1393071654",
                        RefreshToken = "TestValue736006282",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1905863903,
                        Account = default(Account)
                    }
                },
                IsFollowing = true
            };

            await _ctx.UserFollowers.AddAsync(userFollower);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetAsync(userFollower.Id);

            // Assert
            result.Should().NotBeNull();
            result.IsFollowing.Should().BeTrue();
            result.FollowerAccount.Should().NotBeNull();
            result.FollowingAccount.Should().NotBeNull();
            result.FollowingAccountId.Should().NotBe(0);
            result.FollowerAccountId.Should().NotBe(0);
        }

        [Test]
        public async Task CanCallRemove()
        {
            // Arrange
            var userFollower = new UserFollower
            {
                FollowingAccountId = 1470459918,
                FollowingAccount = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1263958144",
                        FollowersCount = 1455196375,
                        NextStatusId = 18236696,
                        UserTarget = 1405314796,
                        AccountId = 1375793989,
                        Account = default(Account)
                    },
                    Cread = "TestValue1680633152",
                    Photo = "TestValue1286547805",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1783626516,
                    User = new User
                    {
                        RoleName = "TestValue1853566093",
                        RefreshToken = "TestValue1506592444",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2071257044,
                        Account = default(Account)
                    }
                },
                FollowerAccountId = 1549178263,
                FollowerAccount = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1242879481",
                        FollowersCount = 1825707833,
                        NextStatusId = 174076405,
                        UserTarget = 1723496185,
                        AccountId = 686588653,
                        Account = default(Account)
                    },
                    Cread = "TestValue441453477",
                    Photo = "TestValue1745471897",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 675229318,
                    User = new User
                    {
                        RoleName = "TestValue720121451",
                        RefreshToken = "TestValue183349448",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1460008441,
                        Account = default(Account)
                    }
                },
                IsFollowing = true
            };

            await _ctx.UserFollowers.AddAsync(userFollower);

            await _ctx.SaveChangesAsync();

            // Act
            await _testClass.Remove(userFollower);

            // Assert
            var result = _ctx.UserFollowers.FirstOrDefault(x => x.Id == userFollower.Id);

            result.Should().BeNull();
        }

        [Test]
        public void CannotCallRemoveWithNullUserFollower()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Remove(default(UserFollower)));
        }

        [Test]
        public async Task CanCallGetFollowingAsyncWithInt()
        {
            // Arrange
            var follower = new Account
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
            var following = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1263958144",
                    FollowersCount = 1455196375,
                    NextStatusId = 18236696,
                    UserTarget = 1405314796,
                    AccountId = 1375793989,
                    Account = default(Account)
                },
                Cread = "TestValue1680633152",
                Photo = "TestValue1286547805",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 1783626516,
                User = new User
                {
                    RoleName = "TestValue1853566093",
                    RefreshToken = "TestValue1506592444",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 2071257044,
                    Account = default(Account)
                }
            };

            var userFollower = new UserFollower
            {
                FollowingAccountId = 1470459918,
                FollowingAccount = following,
                FollowerAccountId = 1549178263,
                FollowerAccount = follower,
                IsFollowing = true
            };

            following.Followers.Add(userFollower);
            follower.Following.Add(userFollower);

            await _ctx.Accounts.AddAsync(follower);
            await _ctx.Accounts.AddAsync(following);

            await _ctx.UserFollowers.AddAsync(userFollower);
            
            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetFollowingAsync(follower.Id);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(1);
            follower.Following.Count.Should().Be(1);
            following.Followers.Count.Should().Be(1);
        }

        [Test]
        public async Task CanCallGetFollowingAsyncWithIntAndIntAndInt()
        {
            // Arrange
            var pageNumber = 1;
            var pageSize = 5;
            var follower = new Account
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
            var following = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1263958144",
                    FollowersCount = 1455196375,
                    NextStatusId = 18236696,
                    UserTarget = 1405314796,
                    AccountId = 1375793989,
                    Account = default(Account)
                },
                Cread = "TestValue1680633152",
                Photo = "TestValue1286547805",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 1783626516,
                User = new User
                {
                    RoleName = "TestValue1853566093",
                    RefreshToken = "TestValue1506592444",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 2071257044,
                    Account = default(Account)
                }
            };

            var userFollower = new UserFollower
            {
                FollowingAccountId = 1470459918,
                FollowingAccount = following,
                FollowerAccountId = 1549178263,
                FollowerAccount = follower,
                IsFollowing = true
            };

            following.Followers.Add(userFollower);
            follower.Following.Add(userFollower);

            await _ctx.Accounts.AddAsync(follower);
            await _ctx.Accounts.AddAsync(following);

            await _ctx.UserFollowers.AddAsync(userFollower);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetFollowingAsync(follower.Id, pageNumber, pageSize);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(1);
            follower.Following.Count.Should().Be(1);
            following.Followers.Count.Should().Be(1);
        }

        [Test]
        public async Task CanCallGetFollowersAsyncWithInt()
        {
            // Arrange
            var follower = new Account
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
            var following = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1263958144",
                    FollowersCount = 1455196375,
                    NextStatusId = 18236696,
                    UserTarget = 1405314796,
                    AccountId = 1375793989,
                    Account = default(Account)
                },
                Cread = "TestValue1680633152",
                Photo = "TestValue1286547805",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 1783626516,
                User = new User
                {
                    RoleName = "TestValue1853566093",
                    RefreshToken = "TestValue1506592444",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 2071257044,
                    Account = default(Account)
                }
            };

            var userFollower = new UserFollower
            {
                FollowingAccountId = 1470459918,
                FollowingAccount = following,
                FollowerAccountId = 1549178263,
                FollowerAccount = follower,
                IsFollowing = true
            };

            following.Followers.Add(userFollower);
            follower.Following.Add(userFollower);

            await _ctx.Accounts.AddAsync(follower);
            await _ctx.Accounts.AddAsync(following);

            await _ctx.UserFollowers.AddAsync(userFollower);

            await _ctx.SaveChangesAsync();


            // Act
            var result = await _testClass.GetFollowersAsync(following.Id);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(1);
            follower.Following.Count.Should().Be(1);
            following.Followers.Count.Should().Be(1);
        }

        [Test]
        public async Task CanCallGetFollowersAsyncWithIntAndIntAndInt()
        {
            // Arrange
            var pageNumber = 1;
            var pageSize = 5;
            var follower = new Account
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
            var following = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1263958144",
                    FollowersCount = 1455196375,
                    NextStatusId = 18236696,
                    UserTarget = 1405314796,
                    AccountId = 1375793989,
                    Account = default(Account)
                },
                Cread = "TestValue1680633152",
                Photo = "TestValue1286547805",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 1783626516,
                User = new User
                {
                    RoleName = "TestValue1853566093",
                    RefreshToken = "TestValue1506592444",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 2071257044,
                    Account = default(Account)
                }
            };

            var userFollower = new UserFollower
            {
                FollowingAccountId = 1470459918,
                FollowingAccount = following,
                FollowerAccountId = 1549178263,
                FollowerAccount = follower,
                IsFollowing = true
            };

            following.Followers.Add(userFollower);
            follower.Following.Add(userFollower);

            await _ctx.Accounts.AddAsync(follower);
            await _ctx.Accounts.AddAsync(following);

            await _ctx.UserFollowers.AddAsync(userFollower);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetFollowersAsync(following.Id, pageNumber, pageSize);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(1);
            follower.Following.Count.Should().Be(1);
            following.Followers.Count.Should().Be(1);
        }

        private DbContextOptions<ApiDbContext> AddMockDbContextOptions()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();

            dbContextOptionsBuilder.UseInMemoryDatabase<ApiDbContext>(Guid.NewGuid().ToString());

            return dbContextOptionsBuilder.Options;
        }
    }
}
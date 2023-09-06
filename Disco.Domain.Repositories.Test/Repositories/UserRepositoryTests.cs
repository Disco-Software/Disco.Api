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
    public class UserRepositoryTests
    {
        private UserRepository _testClass;
        private ApiDbContext _ctx;

        [SetUp]
        public void SetUp()
        {
            _ctx = new ApiDbContext(AddMockDbContextOptions());
            _testClass = new UserRepository(_ctx);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new UserRepository(_ctx);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallGetUserByRefreshTokenAsync()
        {
            // Arrange
            var refreshToken = "TestValue1356262726";
            var user = new User
            {
                RoleName = "TestValue1309478103",
                RefreshToken = "TestValue387805277",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1201594692,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue642307175",
                        FollowersCount = 1336680708,
                        NextStatusId = 94061513,
                        UserTarget = 176425444,
                        AccountId = 369265535,
                        Account = default(Account)
                    },
                    Cread = "TestValue2049430939",
                    Photo = "TestValue1120119782",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 550344057,
                    User = default(User)
                }
            };

            user.RefreshToken = "TestValue1356262726";

            await _ctx.Users.AddAsync(user);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetUserByRefreshTokenAsync(refreshToken);

            // Assert
            result.RefreshToken.Should().NotBeNull();
            result.RefreshToken.Should().NotBeEmpty();
        }

        [Test]
        public async Task GetUserByRefreshTokenAsyncPerformsMapping()
        {
            // Arrange
            var refreshToken = "TestValue1356262726";
            var user = new User
            {
                RoleName = "TestValue1309478103",
                RefreshToken = "TestValue387805277",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1201594692,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue642307175",
                        FollowersCount = 1336680708,
                        NextStatusId = 94061513,
                        UserTarget = 176425444,
                        AccountId = 369265535,
                        Account = default(Account)
                    },
                    Cread = "TestValue2049430939",
                    Photo = "TestValue1120119782",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 550344057,
                    User = default(User)
                }
            };

            user.RefreshToken = "TestValue1356262726";

            await _ctx.Users.AddAsync(user);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetUserByRefreshTokenAsync(refreshToken);

            // Assert
            Assert.That(result.RefreshToken, Is.SameAs(refreshToken));
        }

        [Test]
        public async Task CanCallGetUserAccountAsync()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue1309478103",
                RefreshToken = "TestValue387805277",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1201594692,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue642307175",
                        FollowersCount = 1336680708,
                        NextStatusId = 94061513,
                        UserTarget = 176425444,
                        AccountId = 369265535,
                        Account = default(Account)
                    },
                    Cread = "TestValue2049430939",
                    Photo = "TestValue1120119782",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 550344057,
                    User = default(User)
                }
            };

            await _ctx.Users.AddAsync(user);

            await _ctx.SaveChangesAsync();

            // Act
            await _testClass.GetUserAccountAsync(user);

            // Assert
            user.Account.Should().NotBeNull();
        }

        [Test]
        public void CannotCallGetUserAccountAsyncWithNullUser()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.GetUserAccountAsync(default(User)));
        }

        [Test]
        public async Task CanCallGetUserRole()
        {
            // Arrange
            var roleName = "TestValue2085771049";

            var user = new User
            {
                RoleName = "TestValue2085771049",
                RefreshToken = "TestValue862484046",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1880560070,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue27653646",
                        FollowersCount = 952112000,
                        NextStatusId = 1005080458,
                        UserTarget = 557163727,
                        AccountId = 1967284889,
                        Account = default(Account)
                    },
                    Cread = "TestValue76148225",
                    Photo = "TestValue1537379719",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1456065739,
                    User = default(User)
                }
            };
            var role = new Role
            {
                Name = roleName,
                NormalizedName = roleName.Normalize(),
            };

            await _ctx.Users.AddAsync(user);
            await _ctx.Roles.AddAsync(role);
            await _ctx.UserRoles.AddAsync(new Microsoft.AspNetCore.Identity.IdentityUserRole<int> { RoleId = role.Id, UserId = user.Id });

            await _ctx.SaveChangesAsync();

            // Act
            var result = _testClass.GetUserRole(user);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(roleName);
        }

        [Test]
        public void CannotCallGetUserRoleWithNullUser()
        {
            Assert.Throws<InvalidOperationException>(() => _testClass.GetUserRole(default(User)));
        }

        [Test]
        public async Task CanCallSaveRefreshTokenAsync()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue819182670",
                RefreshToken = "TestValue1409812745",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 419940009,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1817984293",
                        FollowersCount = 1437826790,
                        NextStatusId = 1090738075,
                        UserTarget = 1013681679,
                        AccountId = 2088583824,
                        Account = default(Account)
                    },
                    Cread = "TestValue521484667",
                    Photo = "TestValue642597654",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1112765174,
                    User = default(User)
                }
            };
            var refreshToken = "TestValue1861133920";

            await _ctx.Users.AddAsync(user);

            await _ctx.SaveChangesAsync();

            // Act
            await _testClass.SaveRefreshTokenAsync(user, refreshToken);

            // Assert
            user.RefreshToken.Should().Be(refreshToken);
        }

        [Test]
        public void CannotCallSaveRefreshTokenAsyncWithNullUser()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.SaveRefreshTokenAsync(default(User), "TestValue1292479566"));
        }

        [Test]
        public async Task CanCallGetAllUsers()
        {
            // Arrange
            var pageNumber = 1;
            var pageSize = 5;

            var list = new List<User>()
            {
                new User
            {
                RoleName = "TestValue1309478103",
                RefreshToken = "TestValue387805277",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1201594692,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue642307175",
                        FollowersCount = 1336680708,
                        NextStatusId = 94061513,
                        UserTarget = 176425444,
                        AccountId = 369265535,
                        Account = default(Account)
                    },
                    Cread = "TestValue2049430939",
                    Photo = "TestValue1120119782",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 550344057,
                    User = default(User)
                }
            },
                new User
            {
                RoleName = "TestValue1309478103",
                RefreshToken = "TestValue387805277",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1201594692,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue642307175",
                        FollowersCount = 1336680708,
                        NextStatusId = 94061513,
                        UserTarget = 176425444,
                        AccountId = 369265535,
                        Account = default(Account)
                    },
                    Cread = "TestValue2049430939",
                    Photo = "TestValue1120119782",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 550344057,
                    User = default(User)
                },
            },
                new User
            {
                RoleName = "TestValue1309478103",
                RefreshToken = "TestValue387805277",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1201594692,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue642307175",
                        FollowersCount = 1336680708,
                        NextStatusId = 94061513,
                        UserTarget = 176425444,
                        AccountId = 369265535,
                        Account = default(Account)
                    },
                    Cread = "TestValue2049430939",
                    Photo = "TestValue1120119782",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 550344057,
                    User = default(User)
                }
            },
                new User
            {
                RoleName = "TestValue1309478103",
                RefreshToken = "TestValue387805277",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1201594692,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue642307175",
                        FollowersCount = 1336680708,
                        NextStatusId = 94061513,
                        UserTarget = 176425444,
                        AccountId = 369265535,
                        Account = default(Account)
                    },
                    Cread = "TestValue2049430939",
                    Photo = "TestValue1120119782",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 550344057,
                    User = default(User)
                }
            },
                new User
            {
                RoleName = "TestValue1309478103",
                RefreshToken = "TestValue387805277",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1201594692,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue642307175",
                        FollowersCount = 1336680708,
                        NextStatusId = 94061513,
                        UserTarget = 176425444,
                        AccountId = 369265535,
                        Account = default(Account)
                    },
                    Cread = "TestValue2049430939",
                    Photo = "TestValue1120119782",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 550344057,
                    User = default(User)
                }
            }
            };

            await _ctx.Users.AddRangeAsync(list);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetAllUsers(pageNumber, pageSize);

            // Assert
            result.Should().NotBeEmpty();
            result.Count.Should().Be(5);
        }

        [Test]
        public async Task CanCallGetAllUsersAsyncWithNoParameters()
        {
            //Arrange
            var list = new List<User>()
            {
                new User
            {
                RoleName = "TestValue1309478103",
                RefreshToken = "TestValue387805277",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1201594692,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue642307175",
                        FollowersCount = 1336680708,
                        NextStatusId = 94061513,
                        UserTarget = 176425444,
                        AccountId = 369265535,
                        Account = default(Account)
                    },
                    Cread = "TestValue2049430939",
                    Photo = "TestValue1120119782",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 550344057,
                    User = default(User)
                }
            },
                new User
            {
                RoleName = "TestValue1309478103",
                RefreshToken = "TestValue387805277",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1201594692,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue642307175",
                        FollowersCount = 1336680708,
                        NextStatusId = 94061513,
                        UserTarget = 176425444,
                        AccountId = 369265535,
                        Account = default(Account)
                    },
                    Cread = "TestValue2049430939",
                    Photo = "TestValue1120119782",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 550344057,
                    User = default(User)
                },
            },
                new User
            {
                RoleName = "TestValue1309478103",
                RefreshToken = "TestValue387805277",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1201594692,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue642307175",
                        FollowersCount = 1336680708,
                        NextStatusId = 94061513,
                        UserTarget = 176425444,
                        AccountId = 369265535,
                        Account = default(Account)
                    },
                    Cread = "TestValue2049430939",
                    Photo = "TestValue1120119782",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 550344057,
                    User = default(User)
                }
            },
                new User
            {
                RoleName = "TestValue1309478103",
                RefreshToken = "TestValue387805277",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1201594692,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue642307175",
                        FollowersCount = 1336680708,
                        NextStatusId = 94061513,
                        UserTarget = 176425444,
                        AccountId = 369265535,
                        Account = default(Account)
                    },
                    Cread = "TestValue2049430939",
                    Photo = "TestValue1120119782",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 550344057,
                    User = default(User)
                }
            },
                new User
            {
                RoleName = "TestValue1309478103",
                RefreshToken = "TestValue387805277",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1201594692,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue642307175",
                        FollowersCount = 1336680708,
                        NextStatusId = 94061513,
                        UserTarget = 176425444,
                        AccountId = 369265535,
                        Account = default(Account)
                    },
                    Cread = "TestValue2049430939",
                    Photo = "TestValue1120119782",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 550344057,
                    User = default(User)
                }
            }
            };

            await _ctx.Users.AddRangeAsync(list);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetAllUsersAsync();

            // Assert
            result.Should().NotBeEmpty();
            result.Count.Should().Be(5);
        }

        [Test]
        public async Task CanCallGetAllUsersAsyncWithFromAndTo()
        {
            // Arrange
            var @from = DateTime.UtcNow.AddDays(-5);
            var to = DateTime.UtcNow;

            var list = new List<User>()
            {
                new User
            {
                RoleName = "TestValue1309478103",
                RefreshToken = "TestValue387805277",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow.AddDays(-1),
                AccountId = 1201594692,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue642307175",
                        FollowersCount = 1336680708,
                        NextStatusId = 94061513,
                        UserTarget = 176425444,
                        AccountId = 369265535,
                        Account = default(Account)
                    },
                    Cread = "TestValue2049430939",
                    Photo = "TestValue1120119782",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 550344057,
                    User = default(User)
                }
            },
                new User
            {
                RoleName = "TestValue1309478103",
                RefreshToken = "TestValue387805277",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow.AddDays(-1),
                AccountId = 1201594692,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue642307175",
                        FollowersCount = 1336680708,
                        NextStatusId = 94061513,
                        UserTarget = 176425444,
                        AccountId = 369265535,
                        Account = default(Account)
                    },
                    Cread = "TestValue2049430939",
                    Photo = "TestValue1120119782",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 550344057,
                    User = default(User)
                },
            },
                new User
            {
                RoleName = "TestValue1309478103",
                RefreshToken = "TestValue387805277",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow.AddDays(-3),
                AccountId = 1201594692,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue642307175",
                        FollowersCount = 1336680708,
                        NextStatusId = 94061513,
                        UserTarget = 176425444,
                        AccountId = 369265535,
                        Account = default(Account)
                    },
                    Cread = "TestValue2049430939",
                    Photo = "TestValue1120119782",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 550344057,
                    User = default(User)
                }
            },
                new User
            {
                RoleName = "TestValue1309478103",
                RefreshToken = "TestValue387805277",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow.AddDays(-3),
                AccountId = 1201594692,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue642307175",
                        FollowersCount = 1336680708,
                        NextStatusId = 94061513,
                        UserTarget = 176425444,
                        AccountId = 369265535,
                        Account = default(Account)
                    },
                    Cread = "TestValue2049430939",
                    Photo = "TestValue1120119782",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 550344057,
                    User = default(User)
                }
            },
                new User
            {
                RoleName = "TestValue1309478103",
                RefreshToken = "TestValue387805277",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow.AddDays(-1),
                AccountId = 1201594692,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue642307175",
                        FollowersCount = 1336680708,
                        NextStatusId = 94061513,
                        UserTarget = 176425444,
                        AccountId = 369265535,
                        Account = default(Account)
                    },
                    Cread = "TestValue2049430939",
                    Photo = "TestValue1120119782",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 550344057,
                    User = default(User)
                }
            }
            };

            await _ctx.Users.AddRangeAsync(list);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetAllUsersAsync(from, to);

            // Assert
            result.Should().NotBeEmpty();
            result.Count.Should().Be(5);
        }

        private DbContextOptions<ApiDbContext> AddMockDbContextOptions()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();

            dbContextOptionsBuilder.UseInMemoryDatabase<ApiDbContext>(Guid.NewGuid().ToString());

            return dbContextOptionsBuilder.Options;
        }
    }
}
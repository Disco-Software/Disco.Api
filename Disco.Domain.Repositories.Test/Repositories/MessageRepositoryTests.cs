namespace Disco.Domain.Repositories.Test
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
    using NUnit.Framework;

    [TestFixture]
    public class MessageRepositoryTests
    {
        private MessageRepository _testClass;
        private ApiDbContext _ctx;

        [SetUp]
        public void SetUp()
        {
            _ctx = new ApiDbContext(AddMockDbContextOptions());
            _testClass = new MessageRepository(_ctx);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new MessageRepository(_ctx);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreateAsync()
        {
            // Arrange
            var message = new Message
            {
                AccountId = 29298873,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1047135667",
                        FollowersCount = 1028600082,
                        NextStatusId = 1949106832,
                        UserTarget = 323384401,
                        AccountId = 1927354853,
                        Account = default(Account)
                    },
                    Cread = "TestValue496369932",
                    Photo = "TestValue415379994",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1295807762,
                    User = new User
                    {
                        RoleName = "TestValue1362480670",
                        RefreshToken = "TestValue1287048315",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2007104863,
                        Account = default(Account)
                    }
                },
                Description = "TestValue944883098",
                CreatedDate = DateTime.UtcNow,
                GroupId = 234110768,
                Group = new Group
                {
                    Name = "TestValue595260468",
                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>()
                }
            };
            var cancellationToken = CancellationToken.None;

            // Act
            await _testClass.CreateAsync(message, cancellationToken);

            // Assert
            var result = _ctx.Messages.FirstOrDefault(x => x.Id == 1);

            result.Should().NotBeNull();
        }

        [Test]
        public void CannotCallCreateAsyncWithNullMessage()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.CreateAsync(default(Message), CancellationToken.None));
        }

        [Test]
        public async Task CanCallDeleteAsync()
        {
            // Arrange
            var message = new Message
            {
                AccountId = 10389816,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1414221335",
                        FollowersCount = 551577968,
                        NextStatusId = 1262489959,
                        UserTarget = 587954343,
                        AccountId = 366997498,
                        Account = default(Account)
                    },
                    Cread = "TestValue276506600",
                    Photo = "TestValue2000875392",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2021403658,
                    User = new User
                    {
                        RoleName = "TestValue2060836671",
                        RefreshToken = "TestValue212971490",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1735497883,
                        Account = default(Account)
                    }
                },
                Description = "TestValue5176680",
                CreatedDate = DateTime.UtcNow,
                GroupId = 625313522,
                Group = new Group
                {
                    Name = "TestValue1485749133",
                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>()
                }
            };
            var cancellationToken = CancellationToken.None;

            await _ctx.Messages.AddAsync(message);

            await _ctx.SaveChangesAsync();

            // Act
            await _testClass.DeleteAsync(message, cancellationToken);

            // Assert
            var result = await _ctx.Messages.FirstOrDefaultAsync(x => x.Id == 1);

            result.Should().BeNull();
        }

        [Test]
        public void CannotCallDeleteAsyncWithNullMessage()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.DeleteAsync(default(Message), CancellationToken.None));
        }

        [Test]
        public async Task CanCallGetAllAsync()
        {
            // Arrange
            var groupId = 1;
            var pageNumber = 1;
            var pageSize = 5;

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
            var messages = new List<Message>
            {
                new Message
                {
                    CreatedDate = DateTime.Now,
                    Group = group,
                    GroupId = 1,
                    Description = "Hello",
                    Account = account,
                },
                new Message
                {
                    CreatedDate = DateTime.Now,
                    Group = group,
                    GroupId = 1,
                    Description = "Hello",
                    Account = account,
                },
                new Message
                {
                    CreatedDate = DateTime.Now,
                    Group = group,
                    GroupId = 1,
                    Description = "Hello",
                    Account = account,
                },
                new Message
                {
                    CreatedDate = DateTime.Now,
                    Group = group,
                    GroupId = 1,
                    Description = "Hello",
                    Account = account,
                },
                new Message
                {
                    CreatedDate = DateTime.Now,
                    Group = group,
                    GroupId = 1,
                    Description = "Hello",
                    Account = account,
                },
                new Message
                {
                    CreatedDate = DateTime.Now,
                    Group = group,
                    GroupId = 1,
                    Description = "Hello",
                    Account = account,
                },
                new Message
                {
                    CreatedDate = DateTime.Now,
                    Group = group,
                    GroupId = 1,
                    Description = "Hello",
                    Account = account,
                }
            };

            group.Messages = messages;

            await _ctx.Messages.AddRangeAsync(messages);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetAllAsync(groupId, pageNumber, pageSize);

            // Assert
            result.Should().NotBeEmpty();
            result.Count.Should().Be(5);
        }

        [Test]
        public async Task CanCallGetByIdAsync()
        {
            // Arrange
            var id = 1;

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
            var messages = new List<Message>
            {
                new Message
                {
                    CreatedDate = DateTime.Now,
                    Group = group,
                    GroupId = 1,
                    Description = "Hello",
                    Account = account,
                },
                new Message
                {
                    CreatedDate = DateTime.Now,
                    Group = group,
                    GroupId = 1,
                    Description = "Hello",
                    Account = account,
                },
                new Message
                {
                    CreatedDate = DateTime.Now,
                    Group = group,
                    GroupId = 1,
                    Description = "Hello",
                    Account = account,
                },
                new Message
                {
                    CreatedDate = DateTime.Now,
                    Group = group,
                    GroupId = 1,
                    Description = "Hello",
                    Account = account,
                },
                new Message
                {
                    CreatedDate = DateTime.Now,
                    Group = group,
                    GroupId = 1,
                    Description = "Hello",
                    Account = account,
                },
                new Message
                {
                    CreatedDate = DateTime.Now,
                    Group = group,
                    GroupId = 1,
                    Description = "Hello",
                    Account = account,
                },
                new Message
                {
                    CreatedDate = DateTime.Now,
                    Group = group,
                    GroupId = 1,
                    Description = "Hello",
                    Account = account,
                }
            };

            group.Messages.AddRange(messages);

            await _ctx.Accounts.AddAsync(account);
            await _ctx.Groups.AddAsync(group);
            await _ctx.Messages.AddRangeAsync(messages);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetByIdAsync(id);

            // Assert
            result.Should().NotBeNull();
        }

        [Test]
        public async Task CanCallUpdateAsync()
        {
            // Arrange
            var message = new Message
            {
                AccountId = 1364481957,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue518166635",
                        FollowersCount = 1279277394,
                        NextStatusId = 1920873502,
                        UserTarget = 52201062,
                        AccountId = 737599231,
                        Account = default(Account)
                    },
                    Cread = "TestValue1723735996",
                    Photo = "TestValue1897351751",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2020723430,
                    User = new User
                    {
                        RoleName = "TestValue429378208",
                        RefreshToken = "TestValue1840684810",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1989695865,
                        Account = default(Account)
                    }
                },
                Description = "TestValue343714352",
                CreatedDate = DateTime.UtcNow,
                GroupId = 225084649,
                Group = new Group
                {
                    Name = "TestValue469625537",
                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>()
                }
            };
            var newMessage = new Message
            {
                AccountId = 1364481957,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue518166635",
                        FollowersCount = 1279277394,
                        NextStatusId = 1920873502,
                        UserTarget = 52201062,
                        AccountId = 737599231,
                        Account = default(Account)
                    },
                    Cread = "TestValue1723735996",
                    Photo = "TestValue1897351751",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2020723430,
                    User = new User
                    {
                        RoleName = "TestValue429378208",
                        RefreshToken = "TestValue1840684810",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1989695865,
                        Account = default(Account)
                    }
                },
                Description = "Hello world",
                CreatedDate = DateTime.UtcNow,
                GroupId = 225084649,
                Group = new Group
                {
                    Name = "TestValue469625537",
                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>()
                }
            };
            var cancellationToken = CancellationToken.None;

            await _ctx.Messages.AddAsync(message);

            await _ctx.SaveChangesAsync();

            // Act
            await _testClass.UpdateAsync(newMessage, cancellationToken);

            // Assert
            var result = await _ctx.Messages.FirstOrDefaultAsync(x => x.Id == 1);

            result.Should().NotBeNull();
        }

        [Test]
        public void CannotCallUpdateAsyncWithNullMessage()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.UpdateAsync(default(Message), CancellationToken.None));
        }

        private DbContextOptions<ApiDbContext> AddMockDbContextOptions()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();

            dbContextOptionsBuilder.UseInMemoryDatabase<ApiDbContext>("TestDb");

            return dbContextOptionsBuilder.Options;
        }
    }
}
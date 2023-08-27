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
    public class PostRepositoryTests
    {
        private PostRepository _testClass;
        private ApiDbContext _ctx;

        [SetUp]
        public void SetUp()
        {
            _ctx = new ApiDbContext(AddMockDbContextOptions());
            _testClass = new PostRepository(_ctx);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new PostRepository(_ctx);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallAddAsync()
        {
            // Arrange
            var post = new Post
            {
                Description = "TestValue1510413234",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1683034790,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue386148693",
                        FollowersCount = 908481471,
                        NextStatusId = 1973523993,
                        UserTarget = 1316951236,
                        AccountId = 1651577016,
                        Account = default(Account)
                    },
                    Cread = "TestValue35370157",
                    Photo = "TestValue1611689684",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1471906360,
                    User = new User
                    {
                        RoleName = "TestValue124597323",
                        RefreshToken = "TestValue2032603341",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2089271798,
                        Account = default(Account)
                    }
                }
            };
            var user = new User
            {
                RoleName = "TestValue545742261",
                RefreshToken = "TestValue1232542744",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 2107285279,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue63181154",
                        FollowersCount = 409844600,
                        NextStatusId = 2087341380,
                        UserTarget = 210612439,
                        AccountId = 34695246,
                        Account = default(Account)
                    },
                    Cread = "TestValue1355455838",
                    Photo = "TestValue392531704",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1508052407,
                    User = default(User)
                }
            };

            await _ctx.Users.AddAsync(user);

            await _ctx.SaveChangesAsync();

            // Act
            await _testClass.AddAsync(post, user);

            // Assert
            var result = await _ctx.Posts.FirstOrDefaultAsync();

            result.Should().NotBeNull();
        }

        [Test]
        public void CannotCallAddAsyncWithNullPost()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.AddAsync(default(Post), new User
            {
                RoleName = "TestValue1083919829",
                RefreshToken = "TestValue1017529810",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1839346568,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1859709721",
                        FollowersCount = 2130848088,
                        NextStatusId = 1497009103,
                        UserTarget = 1769730385,
                        AccountId = 973961223,
                        Account = default(Account)
                    },
                    Cread = "TestValue1964613002",
                    Photo = "TestValue241155773",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 828927383,
                    User = default(User)
                }
            }));
        }

        [Test]
        public void CannotCallAddAsyncWithNullUser()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.AddAsync(new Post
            {
                Description = "TestValue955642109",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1551401426,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1049060805",
                        FollowersCount = 193493262,
                        NextStatusId = 583875841,
                        UserTarget = 127506410,
                        AccountId = 273648949,
                        Account = default(Account)
                    },
                    Cread = "TestValue1552906421",
                    Photo = "TestValue752671120",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 753998746,
                    User = new User
                    {
                        RoleName = "TestValue1755711786",
                        RefreshToken = "TestValue557588755",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2126632114,
                        Account = default(Account)
                    }
                }
            }, default(User)));
        }

        [Test]
        public async Task CanCallRemove()
        {
            // Arrange
            var id = 1;

            var post = new Post
            {
                Description = "TestValue1510413234",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1683034790,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue386148693",
                        FollowersCount = 908481471,
                        NextStatusId = 1973523993,
                        UserTarget = 1316951236,
                        AccountId = 1651577016,
                        Account = default(Account)
                    },
                    Cread = "TestValue35370157",
                    Photo = "TestValue1611689684",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1471906360,
                    User = new User
                    {
                        RoleName = "TestValue124597323",
                        RefreshToken = "TestValue2032603341",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2089271798,
                        Account = default(Account)
                    }
                }
            };

            await _ctx.Posts.AddAsync(post);

            await _ctx.SaveChangesAsync();

            // Act
            await _testClass.Remove(id);

            // Assert
            var result = await _ctx.Posts.FirstOrDefaultAsync(x => x.Id == 1);

            result.Should().BeNull();
        }

        [Test]
        public async Task CanCallGetAsync()
        {
            // Arrange
            var id = 1;

            var post = new Post
            {
                Description = "TestValue1510413234",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1683034790,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue386148693",
                        FollowersCount = 908481471,
                        NextStatusId = 1973523993,
                        UserTarget = 1316951236,
                        AccountId = 1651577016,
                        Account = default(Account)
                    },
                    Cread = "TestValue35370157",
                    Photo = "TestValue1611689684",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1471906360,
                    User = new User
                    {
                        RoleName = "TestValue124597323",
                        RefreshToken = "TestValue2032603341",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2089271798,
                        Account = default(Account)
                    }
                }
            };

            await _ctx.Posts.AddAsync(post);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetAsync(id);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(id);
            result.Description.Should().BeEquivalentTo(post.Description);
        }

        [Test]
        public async Task CanCallGetPostsByDescriptionAsync()
        {
            // Arrange
            var search = "TestValue340085663";

            var post = new Post
            {
                Description = "TestValue340085663",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1683034790,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue386148693",
                        FollowersCount = 908481471,
                        NextStatusId = 1973523993,
                        UserTarget = 1316951236,
                        AccountId = 1651577016,
                        Account = default(Account)
                    },
                    Cread = "TestValue35370157",
                    Photo = "TestValue1611689684",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1471906360,
                    User = new User
                    {
                        RoleName = "TestValue124597323",
                        RefreshToken = "TestValue2032603341",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2089271798,
                        Account = default(Account)
                    }
                }
            };

            await _ctx.Posts.AddAsync(post);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetPostsByDescriptionAsync(search);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(1);
        }

        [Test]
        public async Task CanCallGetUserPostsAsync()
        {
            // Arrange
            var accountId = 1;

            var posts = new List<Post>
            {
                new Post
            {
                Description = "TestValue1510413234",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1683034790,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue386148693",
                        FollowersCount = 908481471,
                        NextStatusId = 1973523993,
                        UserTarget = 1316951236,
                        AccountId = 1651577016,
                        Account = default(Account)
                    },
                    Cread = "TestValue35370157",
                    Photo = "TestValue1611689684",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1471906360,
                    User = new User
                    {
                        RoleName = "TestValue124597323",
                        RefreshToken = "TestValue2032603341",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2089271798,
                        Account = default(Account)
                    }
                }
            },
                new Post
            {
                Description = "TestValue1510413234",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1683034790,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue386148693",
                        FollowersCount = 908481471,
                        NextStatusId = 1973523993,
                        UserTarget = 1316951236,
                        AccountId = 1651577016,
                        Account = default(Account)
                    },
                    Cread = "TestValue35370157",
                    Photo = "TestValue1611689684",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1471906360,
                    User = new User
                    {
                        RoleName = "TestValue124597323",
                        RefreshToken = "TestValue2032603341",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2089271798,
                        Account = default(Account)
                    }
                }
            },
                new Post
            {
                Description = "TestValue1510413234",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1683034790,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue386148693",
                        FollowersCount = 908481471,
                        NextStatusId = 1973523993,
                        UserTarget = 1316951236,
                        AccountId = 1651577016,
                        Account = default(Account)
                    },
                    Cread = "TestValue35370157",
                    Photo = "TestValue1611689684",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1471906360,
                    User = new User
                    {
                        RoleName = "TestValue124597323",
                        RefreshToken = "TestValue2032603341",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2089271798,
                        Account = default(Account)
                    }
                }
            },
            };
            var post = new Post
            {
                Description = "TestValue1510413234",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1683034790,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue386148693",
                        FollowersCount = 908481471,
                        NextStatusId = 1973523993,
                        UserTarget = 1316951236,
                        AccountId = 1651577016,
                        Account = default(Account)
                    },
                    Cread = "TestValue35370157",
                    Photo = "TestValue1611689684",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1471906360,
                    User = new User
                    {
                        RoleName = "TestValue124597323",
                        RefreshToken = "TestValue2032603341",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2089271798,
                        Account = default(Account)
                    }
                }
            };
            var user = new User
            {
                RoleName = "TestValue545742261",
                RefreshToken = "TestValue1232542744",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 2107285279,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue63181154",
                        FollowersCount = 409844600,
                        NextStatusId = 2087341380,
                        UserTarget = 210612439,
                        AccountId = 34695246,
                        Account = default(Account)
                    },
                    Cread = "TestValue1355455838",
                    Photo = "TestValue392531704",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1508052407,
                    User = default(User)
                }
            };

            user.Account.Posts.AddRange(posts);

            await _ctx.Users.AddAsync(user);
            await _ctx.Posts.AddAsync(post);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetUserPostsAsync(accountId);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(3);
        }

        [Test]
        public async Task CanCallGetFollowerPostsAsync()
        {
            // Arrange
            var accountId = 1;

            var user = new User
            {
                RoleName = "TestValue545742261",
                RefreshToken = "TestValue1232542744",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 2107285279,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue63181154",
                        FollowersCount = 409844600,
                        NextStatusId = 2087341380,
                        UserTarget = 210612439,
                        AccountId = 34695246,
                        Account = default(Account)
                    },
                    Cread = "TestValue1355455838",
                    Photo = "TestValue392531704",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1508052407,
                    User = default(User)
                }
            };
            var posts = new List<Post>
            {
                new Post
            {
                Description = "TestValue1510413234",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1683034790,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue386148693",
                        FollowersCount = 908481471,
                        NextStatusId = 1973523993,
                        UserTarget = 1316951236,
                        AccountId = 1651577016,
                        Account = default(Account)
                    },
                    Cread = "TestValue35370157",
                    Photo = "TestValue1611689684",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1471906360,
                    User = new User
                    {
                        RoleName = "TestValue124597323",
                        RefreshToken = "TestValue2032603341",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2089271798,
                        Account = default(Account)
                    }
                }
            },
                new Post
            {
                Description = "TestValue1510413234",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1683034790,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue386148693",
                        FollowersCount = 908481471,
                        NextStatusId = 1973523993,
                        UserTarget = 1316951236,
                        AccountId = 1651577016,
                        Account = default(Account)
                    },
                    Cread = "TestValue35370157",
                    Photo = "TestValue1611689684",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1471906360,
                    User = new User
                    {
                        RoleName = "TestValue124597323",
                        RefreshToken = "TestValue2032603341",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2089271798,
                        Account = default(Account)
                    }
                }
            },
                new Post
            {
                Description = "TestValue1510413234",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1683034790,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue386148693",
                        FollowersCount = 908481471,
                        NextStatusId = 1973523993,
                        UserTarget = 1316951236,
                        AccountId = 1651577016,
                        Account = default(Account)
                    },
                    Cread = "TestValue35370157",
                    Photo = "TestValue1611689684",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1471906360,
                    User = new User
                    {
                        RoleName = "TestValue124597323",
                        RefreshToken = "TestValue2032603341",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2089271798,
                        Account = default(Account)
                    }
                }
            },
                new Post
            {
                Description = "TestValue1510413234",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1683034790,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue386148693",
                        FollowersCount = 908481471,
                        NextStatusId = 1973523993,
                        UserTarget = 1316951236,
                        AccountId = 1651577016,
                        Account = default(Account)
                    },
                    Cread = "TestValue35370157",
                    Photo = "TestValue1611689684",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1471906360,
                    User = new User
                    {
                        RoleName = "TestValue124597323",
                        RefreshToken = "TestValue2032603341",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2089271798,
                        Account = default(Account)
                    }
                }
            },
                new Post
            {
                Description = "TestValue1510413234",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1683034790,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue386148693",
                        FollowersCount = 908481471,
                        NextStatusId = 1973523993,
                        UserTarget = 1316951236,
                        AccountId = 1651577016,
                        Account = default(Account)
                    },
                    Cread = "TestValue35370157",
                    Photo = "TestValue1611689684",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1471906360,
                    User = new User
                    {
                        RoleName = "TestValue124597323",
                        RefreshToken = "TestValue2032603341",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2089271798,
                        Account = default(Account)
                    }
                }
            },
            };

            user.Account.Posts.AddRange(posts);

            await _ctx.Users.AddAsync(user);
            await _ctx.Posts.AddRangeAsync(posts);

            await _ctx.SaveChangesAsync();
            
            // Act
            var result = await _testClass.GetFollowerPostsAsync(accountId);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(5);
        }

        [Test]
        public async Task CanCallGetFollowingPostsAsync()
        {
            var accountId = 1;

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
            var follower = new Account
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
                    UserName = Guid.NewGuid().ToString(),
                    Email = "basya@gmail.com",
                    RefreshToken = "TestValue1506592444",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 2071257044,
                    Account = default(Account)
                }
            };
            var user = new User
            {
                RoleName = "TestValue545742261",
                RefreshToken = "TestValue1232542744",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 2107285279,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue63181154",
                        FollowersCount = 409844600,
                        NextStatusId = 2087341380,
                        UserTarget = 210612439,
                        AccountId = 34695246,
                        Account = default(Account)
                    },
                    Cread = "TestValue1355455838",
                    Photo = "TestValue392531704",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1508052407,
                    User = new User
                    {
                        UserName = "vasya",
                        Email = "vays@gmail.com",
                        RoleName = "Admin",
                    }
                }
            };
            var posts = new List<Post>
            {
                new Post
            {
                Description = "TestValue1510413234",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1683034790,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue386148693",
                        FollowersCount = 908481471,
                        NextStatusId = 1973523993,
                        UserTarget = 1316951236,
                        AccountId = 1651577016,
                        Account = default(Account)
                    },
                    Cread = "TestValue35370157",
                    Photo = "TestValue1611689684",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1471906360,
                    User = new User
                    {
                        RoleName = "TestValue124597323",
                        RefreshToken = "TestValue2032603341",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2089271798,
                        Account = default(Account)
                    }
                }
            },
                new Post
            {
                Description = "TestValue1510413234",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1683034790,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue386148693",
                        FollowersCount = 908481471,
                        NextStatusId = 1973523993,
                        UserTarget = 1316951236,
                        AccountId = 1651577016,
                        Account = default(Account)
                    },
                    Cread = "TestValue35370157",
                    Photo = "TestValue1611689684",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1471906360,
                    User = new User
                    {
                        RoleName = "TestValue124597323",
                        RefreshToken = "TestValue2032603341",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2089271798,
                        Account = default(Account)
                    }
                }
            },
                new Post
            {
                Description = "TestValue1510413234",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1683034790,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue386148693",
                        FollowersCount = 908481471,
                        NextStatusId = 1973523993,
                        UserTarget = 1316951236,
                        AccountId = 1651577016,
                        Account = default(Account)
                    },
                    Cread = "TestValue35370157",
                    Photo = "TestValue1611689684",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1471906360,
                    User = new User
                    {
                        RoleName = "TestValue124597323",
                        RefreshToken = "TestValue2032603341",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2089271798,
                        Account = default(Account)
                    }
                }
            },
                new Post
            {
                Description = "TestValue1510413234",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1683034790,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue386148693",
                        FollowersCount = 908481471,
                        NextStatusId = 1973523993,
                        UserTarget = 1316951236,
                        AccountId = 1651577016,
                        Account = default(Account)
                    },
                    Cread = "TestValue35370157",
                    Photo = "TestValue1611689684",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1471906360,
                    User = new User
                    {
                        RoleName = "TestValue124597323",
                        RefreshToken = "TestValue2032603341",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2089271798,
                        Account = default(Account)
                    }
                }
            },
                new Post
            {
                Description = "TestValue1510413234",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1683034790,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue386148693",
                        FollowersCount = 908481471,
                        NextStatusId = 1973523993,
                        UserTarget = 1316951236,
                        AccountId = 1651577016,
                        Account = default(Account)
                    },
                    Cread = "TestValue35370157",
                    Photo = "TestValue1611689684",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1471906360,
                    User = new User
                    {
                        RoleName = "TestValue124597323",
                        RefreshToken = "TestValue2032603341",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2089271798,
                        Account = default(Account)
                    }
                }
            },
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

            user.Account.Posts.AddRange(posts);

            await _ctx.Users.AddAsync(user);
            await _ctx.Posts.AddRangeAsync(posts);
            await _ctx.UserFollowers.AddAsync(userFollower);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetFollowingPostsAsync(follower.Following);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(5);
        }

        [Test]
        public void CannotCallGetFollowingPostsAsyncWithNullFollowings()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.GetFollowingPostsAsync(default(List<UserFollower>)));
        }

        [Test]
        public async Task GetFollowingPostsAsyncPerformsMapping()
        {
            // Arrange
            var followings = new List<UserFollower>();

            // Act
            var result = await _testClass.GetFollowingPostsAsync(followings);

            // Assert
            Assert.That(result.Capacity, Is.EqualTo(followings.Capacity));
            Assert.That(result.Count, Is.EqualTo(followings.Count));
        }

        [Test]
        public async Task CanCallGetAllUserPosts()
        {
            // Arrange
            var userId = 2008012014;
            var pageSize = 1982045539;
            var pageNumber = 154957396;

            // Act
            var result = await _testClass.GetAllUserPosts(userId, pageSize, pageNumber);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public async Task CanCallGetAllPostsAsync()
        {
            // Arrange
            var @from = DateTime.UtcNow;
            var to = DateTime.UtcNow;

            // Act
            var result = await _testClass.GetAllPostsAsync(from, to);

            // Assert
            Assert.Fail("Create or modify test");
        }

        private DbContextOptions<ApiDbContext> AddMockDbContextOptions()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();

            dbContextOptionsBuilder.UseInMemoryDatabase<ApiDbContext>("TestDb");

            return dbContextOptionsBuilder.Options;
        }

    }
}
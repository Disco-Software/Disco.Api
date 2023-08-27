namespace Disco.Domain.Repositories.Test
{
    using System;
    using System.Collections.Generic;
    using System.Security.Principal;
    using System.Threading.Tasks;
    using Disco.Domain.EF;
    using Disco.Domain.Models.Models;
    using Disco.Domain.Repositories.Repositories;
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    [TestFixture]
    public class LikeRepositoryTests
    {
        private LikeRepository _testClass;
        private ApiDbContext _ctx;

        [SetUp]
        public void SetUp()
        {
            _ctx = new ApiDbContext(AddMockDbContextOptions());
            _testClass = new LikeRepository(_ctx);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new LikeRepository(_ctx);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallAddAsync()
        {
            // Arrange
            var item = new Like
            {
                AccountId = 165989972,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1574734405",
                        FollowersCount = 133354599,
                        NextStatusId = 720907213,
                        UserTarget = 1961377527,
                        AccountId = 1566976783,
                        Account = default(Account)
                    },
                    Cread = "TestValue437970971",
                    Photo = "TestValue493589159",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 443574042,
                    User = new User
                    {
                        RoleName = "TestValue1982214717",
                        RefreshToken = "TestValue616920653",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1356363383,
                        Account = default(Account)
                    }
                },
                PostId = 201558152,
                Post = new Post
                {
                    Description = "TestValue2123284068",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 66463398,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue2128540705",
                            FollowersCount = 980218588,
                            NextStatusId = 2124511692,
                            UserTarget = 152147875,
                            AccountId = 1987741855,
                            Account = default(Account)
                        },
                        Cread = "TestValue945196641",
                        Photo = "TestValue1768570976",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 1839448481,
                        User = new User
                        {
                            RoleName = "TestValue716544956",
                            RefreshToken = "TestValue1043437519",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 2134296668,
                            Account = default(Account)
                        }
                    }
                }
            };

            // Act
            await _testClass.AddAsync(item);

            // Assert
            var like = await _ctx.Likes.FirstOrDefaultAsync();

            like.Should().NotBeNull();
            like.Post.Should().NotBeNull();
            like.PostId.Should().NotBe(0);
            like.Account.Should().NotBeNull();
            like.AccountId.Should().NotBe(0);
        }

        [Test]
        public void CannotCallAddAsyncWithNullItem()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.AddAsync(default(Like)));
        }

        [Test]
        public async Task CanCallRemove()
        {
            // Arrange
            var like = new Like
            {
                AccountId = 544166,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1295206457",
                        FollowersCount = 15510561,
                        NextStatusId = 2112112567,
                        UserTarget = 1977185203,
                        AccountId = 1364879236,
                        Account = default(Account)
                    },
                    Cread = "TestValue955608607",
                    Photo = "TestValue721150201",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2110204945,
                    User = new User
                    {
                        RoleName = "TestValue2043163400",
                        RefreshToken = "TestValue1139306330",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 53055157,
                        Account = default(Account)
                    }
                },
                PostId = 344551296,
                Post = new Post
                {
                    Description = "TestValue1639054898",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1455496259,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1647126143",
                            FollowersCount = 123320353,
                            NextStatusId = 985278992,
                            UserTarget = 1101358498,
                            AccountId = 1689352226,
                            Account = default(Account)
                        },
                        Cread = "TestValue2087087015",
                        Photo = "TestValue1077965128",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 420338290,
                        User = new User
                        {
                            RoleName = "TestValue833239725",
                            RefreshToken = "TestValue848164468",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1111720357,
                            Account = default(Account)
                        }
                    }
                }
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

            await _ctx.Accounts.AddAsync(account);
            await _ctx.Posts.AddAsync(post);
            await _ctx.Likes.AddAsync(like);

            await _ctx.SaveChangesAsync();

            // Act
            await _testClass.Remove(like);

            // Assert
            var result = await _testClass.GetAsync(like.Id);

            result.Should().BeNull();
        }

        [Test]
        public void CannotCallRemoveWithNullLike()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Remove(default(Like)));
        }

        [Test]
        public async Task CanCallGetAllWithInt()
        {
            // Arrange
            var likes = new List<Like>()
            {
                new Like
                {
                    AccountId = 544166,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1295206457",
                            FollowersCount = 15510561,
                            NextStatusId = 2112112567,
                            UserTarget = 1977185203,
                            AccountId = 1364879236,
                            Account = default(Account)
                        },
                    Cread = "TestValue955608607",
                    Photo = "TestValue721150201",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2110204945,
                    User = new User
                    {
                        RoleName = "TestValue2043163400",
                        RefreshToken = "TestValue1139306330",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 53055157,
                        Account = default(Account)
                    }
                },
                PostId = 344551296,
                Post = new Post
                {
                    Description = "TestValue1639054898",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1455496259,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1647126143",
                            FollowersCount = 123320353,
                            NextStatusId = 985278992,
                            UserTarget = 1101358498,
                            AccountId = 1689352226,
                            Account = default(Account)
                        },
                        Cread = "TestValue2087087015",
                        Photo = "TestValue1077965128",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 420338290,
                        User = new User
                        {
                            RoleName = "TestValue833239725",
                            RefreshToken = "TestValue848164468",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1111720357,
                            Account = default(Account)
                        }
                    }
                }
            },
                new Like
            {
                AccountId = 544166,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1295206457",
                        FollowersCount = 15510561,
                        NextStatusId = 2112112567,
                        UserTarget = 1977185203,
                        AccountId = 1364879236,
                        Account = default(Account)
                    },
                    Cread = "TestValue955608607",
                    Photo = "TestValue721150201",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2110204945,
                    User = new User
                    {
                        RoleName = "TestValue2043163400",
                        RefreshToken = "TestValue1139306330",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 53055157,
                        Account = default(Account)
                    }
                },
                PostId = 344551296,
                Post = new Post
                {
                    Description = "TestValue1639054898",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1455496259,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1647126143",
                            FollowersCount = 123320353,
                            NextStatusId = 985278992,
                            UserTarget = 1101358498,
                            AccountId = 1689352226,
                            Account = default(Account)
                        },
                        Cread = "TestValue2087087015",
                        Photo = "TestValue1077965128",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 420338290,
                        User = new User
                        {
                            RoleName = "TestValue833239725",
                            RefreshToken = "TestValue848164468",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1111720357,
                            Account = default(Account)
                        }
                    }
                }
            }
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

            post.Likes.AddRange(likes);

            await _ctx.Accounts.AddAsync(account);
            await _ctx.Posts.AddAsync(post);
            await _ctx.Likes.AddRangeAsync(likes);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetAll(post.Id);

            // Assert
            result.Count.Should().Be(2);
            result.First().PostId.Should().Be(post.Id);
        }

        [Test]
        public async Task CanCallGetAllWithPostIdAndPageNumberAndPageSize()
        {
            // Arrange
            var postId = 1;
            var pageNumber = 1;
            var pageSize = 3;

            var likes = new List<Like>()
            {
                new Like
                {
                    AccountId = 544166,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1295206457",
                            FollowersCount = 15510561,
                            NextStatusId = 2112112567,
                            UserTarget = 1977185203,
                            AccountId = 1364879236,
                            Account = default(Account)
                        },
                    Cread = "TestValue955608607",
                    Photo = "TestValue721150201",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2110204945,
                    User = new User
                    {
                        RoleName = "TestValue2043163400",
                        RefreshToken = "TestValue1139306330",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 53055157,
                        Account = default(Account)
                    }
                },
                PostId = 344551296,
                Post = new Post
                {
                    Description = "TestValue1639054898",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1455496259,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1647126143",
                            FollowersCount = 123320353,
                            NextStatusId = 985278992,
                            UserTarget = 1101358498,
                            AccountId = 1689352226,
                            Account = default(Account)
                        },
                        Cread = "TestValue2087087015",
                        Photo = "TestValue1077965128",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 420338290,
                        User = new User
                        {
                            RoleName = "TestValue833239725",
                            RefreshToken = "TestValue848164468",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1111720357,
                            Account = default(Account)
                        }
                    }
                }
            },
                new Like
            {
                AccountId = 544166,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1295206457",
                        FollowersCount = 15510561,
                        NextStatusId = 2112112567,
                        UserTarget = 1977185203,
                        AccountId = 1364879236,
                        Account = default(Account)
                    },
                    Cread = "TestValue955608607",
                    Photo = "TestValue721150201",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2110204945,
                    User = new User
                    {
                        RoleName = "TestValue2043163400",
                        RefreshToken = "TestValue1139306330",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 53055157,
                        Account = default(Account)
                    }
                },
                PostId = 344551296,
                Post = new Post
                {
                    Description = "TestValue1639054898",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1455496259,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1647126143",
                            FollowersCount = 123320353,
                            NextStatusId = 985278992,
                            UserTarget = 1101358498,
                            AccountId = 1689352226,
                            Account = default(Account)
                        },
                        Cread = "TestValue2087087015",
                        Photo = "TestValue1077965128",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 420338290,
                        User = new User
                        {
                            RoleName = "TestValue833239725",
                            RefreshToken = "TestValue848164468",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1111720357,
                            Account = default(Account)
                        }
                    }
                }
            },
                new Like
            {
                AccountId = 544166,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1295206457",
                        FollowersCount = 15510561,
                        NextStatusId = 2112112567,
                        UserTarget = 1977185203,
                        AccountId = 1364879236,
                        Account = default(Account)
                    },
                    Cread = "TestValue955608607",
                    Photo = "TestValue721150201",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2110204945,
                    User = new User
                    {
                        RoleName = "TestValue2043163400",
                        RefreshToken = "TestValue1139306330",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 53055157,
                        Account = default(Account)
                    }
                },
                PostId = 344551296,
                Post = new Post
                {
                    Description = "TestValue1639054898",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1455496259,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1647126143",
                            FollowersCount = 123320353,
                            NextStatusId = 985278992,
                            UserTarget = 1101358498,
                            AccountId = 1689352226,
                            Account = default(Account)
                        },
                        Cread = "TestValue2087087015",
                        Photo = "TestValue1077965128",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 420338290,
                        User = new User
                        {
                            RoleName = "TestValue833239725",
                            RefreshToken = "TestValue848164468",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1111720357,
                            Account = default(Account)
                        }
                    }
                }
            },
                new Like
            {
                AccountId = 544166,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1295206457",
                        FollowersCount = 15510561,
                        NextStatusId = 2112112567,
                        UserTarget = 1977185203,
                        AccountId = 1364879236,
                        Account = default(Account)
                    },
                    Cread = "TestValue955608607",
                    Photo = "TestValue721150201",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2110204945,
                    User = new User
                    {
                        RoleName = "TestValue2043163400",
                        RefreshToken = "TestValue1139306330",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 53055157,
                        Account = default(Account)
                    }
                },
                PostId = 344551296,
                Post = new Post
                {
                    Description = "TestValue1639054898",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1455496259,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1647126143",
                            FollowersCount = 123320353,
                            NextStatusId = 985278992,
                            UserTarget = 1101358498,
                            AccountId = 1689352226,
                            Account = default(Account)
                        },
                        Cread = "TestValue2087087015",
                        Photo = "TestValue1077965128",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 420338290,
                        User = new User
                        {
                            RoleName = "TestValue833239725",
                            RefreshToken = "TestValue848164468",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1111720357,
                            Account = default(Account)
                        }
                    }
                }
            },
                new Like
            {
                AccountId = 544166,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1295206457",
                        FollowersCount = 15510561,
                        NextStatusId = 2112112567,
                        UserTarget = 1977185203,
                        AccountId = 1364879236,
                        Account = default(Account)
                    },
                    Cread = "TestValue955608607",
                    Photo = "TestValue721150201",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2110204945,
                    User = new User
                    {
                        RoleName = "TestValue2043163400",
                        RefreshToken = "TestValue1139306330",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 53055157,
                        Account = default(Account)
                    }
                },
                PostId = 344551296,
                Post = new Post
                {
                    Description = "TestValue1639054898",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1455496259,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1647126143",
                            FollowersCount = 123320353,
                            NextStatusId = 985278992,
                            UserTarget = 1101358498,
                            AccountId = 1689352226,
                            Account = default(Account)
                        },
                        Cread = "TestValue2087087015",
                        Photo = "TestValue1077965128",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 420338290,
                        User = new User
                        {
                            RoleName = "TestValue833239725",
                            RefreshToken = "TestValue848164468",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1111720357,
                            Account = default(Account)
                        }
                    }
                }
            }
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

            post.Likes.AddRange(likes);

            await _ctx.Accounts.AddAsync(account);
            await _ctx.Posts.AddAsync(post);
            await _ctx.Likes.AddRangeAsync(likes);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetAll(postId, pageNumber, pageSize);

            // Assert
            result.Count.Should().Be(3);
        }

        [Test]
        public async Task CanCallGetAsync()
        {
            // Arrange
            var postId = 1;
            var likes = new List<Like>()
            {
                new Like
                {
                    AccountId = 544166,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1295206457",
                            FollowersCount = 15510561,
                            NextStatusId = 2112112567,
                            UserTarget = 1977185203,
                            AccountId = 1364879236,
                            Account = default(Account)
                        },
                    Cread = "TestValue955608607",
                    Photo = "TestValue721150201",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2110204945,
                    User = new User
                    {
                        RoleName = "TestValue2043163400",
                        RefreshToken = "TestValue1139306330",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 53055157,
                        Account = default(Account)
                    }
                },
                PostId = 344551296,
                Post = new Post
                {
                    Description = "TestValue1639054898",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1455496259,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1647126143",
                            FollowersCount = 123320353,
                            NextStatusId = 985278992,
                            UserTarget = 1101358498,
                            AccountId = 1689352226,
                            Account = default(Account)
                        },
                        Cread = "TestValue2087087015",
                        Photo = "TestValue1077965128",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 420338290,
                        User = new User
                        {
                            RoleName = "TestValue833239725",
                            RefreshToken = "TestValue848164468",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1111720357,
                            Account = default(Account)
                        }
                    }
                }
            },
                new Like
            {
                AccountId = 544166,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1295206457",
                        FollowersCount = 15510561,
                        NextStatusId = 2112112567,
                        UserTarget = 1977185203,
                        AccountId = 1364879236,
                        Account = default(Account)
                    },
                    Cread = "TestValue955608607",
                    Photo = "TestValue721150201",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2110204945,
                    User = new User
                    {
                        RoleName = "TestValue2043163400",
                        RefreshToken = "TestValue1139306330",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 53055157,
                        Account = default(Account)
                    }
                },
                PostId = 344551296,
                Post = new Post
                {
                    Description = "TestValue1639054898",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1455496259,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1647126143",
                            FollowersCount = 123320353,
                            NextStatusId = 985278992,
                            UserTarget = 1101358498,
                            AccountId = 1689352226,
                            Account = default(Account)
                        },
                        Cread = "TestValue2087087015",
                        Photo = "TestValue1077965128",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 420338290,
                        User = new User
                        {
                            RoleName = "TestValue833239725",
                            RefreshToken = "TestValue848164468",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1111720357,
                            Account = default(Account)
                        }
                    }
                }
            },
                new Like
            {
                AccountId = 544166,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1295206457",
                        FollowersCount = 15510561,
                        NextStatusId = 2112112567,
                        UserTarget = 1977185203,
                        AccountId = 1364879236,
                        Account = default(Account)
                    },
                    Cread = "TestValue955608607",
                    Photo = "TestValue721150201",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2110204945,
                    User = new User
                    {
                        RoleName = "TestValue2043163400",
                        RefreshToken = "TestValue1139306330",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 53055157,
                        Account = default(Account)
                    }
                },
                PostId = 344551296,
                Post = new Post
                {
                    Description = "TestValue1639054898",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1455496259,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1647126143",
                            FollowersCount = 123320353,
                            NextStatusId = 985278992,
                            UserTarget = 1101358498,
                            AccountId = 1689352226,
                            Account = default(Account)
                        },
                        Cread = "TestValue2087087015",
                        Photo = "TestValue1077965128",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 420338290,
                        User = new User
                        {
                            RoleName = "TestValue833239725",
                            RefreshToken = "TestValue848164468",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1111720357,
                            Account = default(Account)
                        }
                    }
                }
            },
                new Like
            {
                AccountId = 544166,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1295206457",
                        FollowersCount = 15510561,
                        NextStatusId = 2112112567,
                        UserTarget = 1977185203,
                        AccountId = 1364879236,
                        Account = default(Account)
                    },
                    Cread = "TestValue955608607",
                    Photo = "TestValue721150201",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2110204945,
                    User = new User
                    {
                        RoleName = "TestValue2043163400",
                        RefreshToken = "TestValue1139306330",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 53055157,
                        Account = default(Account)
                    }
                },
                PostId = 344551296,
                Post = new Post
                {
                    Description = "TestValue1639054898",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1455496259,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1647126143",
                            FollowersCount = 123320353,
                            NextStatusId = 985278992,
                            UserTarget = 1101358498,
                            AccountId = 1689352226,
                            Account = default(Account)
                        },
                        Cread = "TestValue2087087015",
                        Photo = "TestValue1077965128",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 420338290,
                        User = new User
                        {
                            RoleName = "TestValue833239725",
                            RefreshToken = "TestValue848164468",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1111720357,
                            Account = default(Account)
                        }
                    }
                }
            },
                new Like
            {
                AccountId = 544166,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1295206457",
                        FollowersCount = 15510561,
                        NextStatusId = 2112112567,
                        UserTarget = 1977185203,
                        AccountId = 1364879236,
                        Account = default(Account)
                    },
                    Cread = "TestValue955608607",
                    Photo = "TestValue721150201",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2110204945,
                    User = new User
                    {
                        RoleName = "TestValue2043163400",
                        RefreshToken = "TestValue1139306330",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 53055157,
                        Account = default(Account)
                    }
                },
                PostId = 344551296,
                Post = new Post
                {
                    Description = "TestValue1639054898",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1455496259,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1647126143",
                            FollowersCount = 123320353,
                            NextStatusId = 985278992,
                            UserTarget = 1101358498,
                            AccountId = 1689352226,
                            Account = default(Account)
                        },
                        Cread = "TestValue2087087015",
                        Photo = "TestValue1077965128",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 420338290,
                        User = new User
                        {
                            RoleName = "TestValue833239725",
                            RefreshToken = "TestValue848164468",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1111720357,
                            Account = default(Account)
                        }
                    }
                }
            }
            };

            await _ctx.Likes.AddRangeAsync(likes);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetAsync(postId);

            // Assert
            result.Should().NotBeNull();
        }

        [Test]
        public async Task GetAsyncPerformsMapping()
        {
            // Arrange
            var postId = 1;

            var likes = new List<Like>()
            {
                new Like
                {
                    AccountId = 544166,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1295206457",
                            FollowersCount = 15510561,
                            NextStatusId = 2112112567,
                            UserTarget = 1977185203,
                            AccountId = 1364879236,
                            Account = default(Account)
                        },
                    Cread = "TestValue955608607",
                    Photo = "TestValue721150201",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2110204945,
                    User = new User
                    {
                        RoleName = "TestValue2043163400",
                        RefreshToken = "TestValue1139306330",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 53055157,
                        Account = default(Account)
                    }
                },
                PostId = 344551296,
                Post = new Post
                {
                    Description = "TestValue1639054898",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1455496259,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1647126143",
                            FollowersCount = 123320353,
                            NextStatusId = 985278992,
                            UserTarget = 1101358498,
                            AccountId = 1689352226,
                            Account = default(Account)
                        },
                        Cread = "TestValue2087087015",
                        Photo = "TestValue1077965128",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 420338290,
                        User = new User
                        {
                            RoleName = "TestValue833239725",
                            RefreshToken = "TestValue848164468",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1111720357,
                            Account = default(Account)
                        }
                    }
                }
            },
                new Like
            {
                AccountId = 544166,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1295206457",
                        FollowersCount = 15510561,
                        NextStatusId = 2112112567,
                        UserTarget = 1977185203,
                        AccountId = 1364879236,
                        Account = default(Account)
                    },
                    Cread = "TestValue955608607",
                    Photo = "TestValue721150201",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2110204945,
                    User = new User
                    {
                        RoleName = "TestValue2043163400",
                        RefreshToken = "TestValue1139306330",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 53055157,
                        Account = default(Account)
                    }
                },
                PostId = 344551296,
                Post = new Post
                {
                    Description = "TestValue1639054898",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1455496259,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1647126143",
                            FollowersCount = 123320353,
                            NextStatusId = 985278992,
                            UserTarget = 1101358498,
                            AccountId = 1689352226,
                            Account = default(Account)
                        },
                        Cread = "TestValue2087087015",
                        Photo = "TestValue1077965128",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 420338290,
                        User = new User
                        {
                            RoleName = "TestValue833239725",
                            RefreshToken = "TestValue848164468",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1111720357,
                            Account = default(Account)
                        }
                    }
                }
            },
                new Like
            {
                AccountId = 544166,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1295206457",
                        FollowersCount = 15510561,
                        NextStatusId = 2112112567,
                        UserTarget = 1977185203,
                        AccountId = 1364879236,
                        Account = default(Account)
                    },
                    Cread = "TestValue955608607",
                    Photo = "TestValue721150201",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2110204945,
                    User = new User
                    {
                        RoleName = "TestValue2043163400",
                        RefreshToken = "TestValue1139306330",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 53055157,
                        Account = default(Account)
                    }
                },
                PostId = 344551296,
                Post = new Post
                {
                    Description = "TestValue1639054898",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1455496259,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1647126143",
                            FollowersCount = 123320353,
                            NextStatusId = 985278992,
                            UserTarget = 1101358498,
                            AccountId = 1689352226,
                            Account = default(Account)
                        },
                        Cread = "TestValue2087087015",
                        Photo = "TestValue1077965128",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 420338290,
                        User = new User
                        {
                            RoleName = "TestValue833239725",
                            RefreshToken = "TestValue848164468",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1111720357,
                            Account = default(Account)
                        }
                    }
                }
            },
                new Like
            {
                AccountId = 544166,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1295206457",
                        FollowersCount = 15510561,
                        NextStatusId = 2112112567,
                        UserTarget = 1977185203,
                        AccountId = 1364879236,
                        Account = default(Account)
                    },
                    Cread = "TestValue955608607",
                    Photo = "TestValue721150201",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2110204945,
                    User = new User
                    {
                        RoleName = "TestValue2043163400",
                        RefreshToken = "TestValue1139306330",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 53055157,
                        Account = default(Account)
                    }
                },
                PostId = 344551296,
                Post = new Post
                {
                    Description = "TestValue1639054898",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1455496259,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1647126143",
                            FollowersCount = 123320353,
                            NextStatusId = 985278992,
                            UserTarget = 1101358498,
                            AccountId = 1689352226,
                            Account = default(Account)
                        },
                        Cread = "TestValue2087087015",
                        Photo = "TestValue1077965128",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 420338290,
                        User = new User
                        {
                            RoleName = "TestValue833239725",
                            RefreshToken = "TestValue848164468",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1111720357,
                            Account = default(Account)
                        }
                    }
                }
            },
                new Like
            {
                AccountId = 544166,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1295206457",
                        FollowersCount = 15510561,
                        NextStatusId = 2112112567,
                        UserTarget = 1977185203,
                        AccountId = 1364879236,
                        Account = default(Account)
                    },
                    Cread = "TestValue955608607",
                    Photo = "TestValue721150201",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2110204945,
                    User = new User
                    {
                        RoleName = "TestValue2043163400",
                        RefreshToken = "TestValue1139306330",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 53055157,
                        Account = default(Account)
                    }
                },
                PostId = 344551296,
                Post = new Post
                {
                    Description = "TestValue1639054898",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1455496259,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1647126143",
                            FollowersCount = 123320353,
                            NextStatusId = 985278992,
                            UserTarget = 1101358498,
                            AccountId = 1689352226,
                            Account = default(Account)
                        },
                        Cread = "TestValue2087087015",
                        Photo = "TestValue1077965128",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 420338290,
                        User = new User
                        {
                            RoleName = "TestValue833239725",
                            RefreshToken = "TestValue848164468",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1111720357,
                            Account = default(Account)
                        }
                    }
                }
            }
            };

            await _ctx.Likes.AddRangeAsync(likes);

            await _ctx.SaveChangesAsync();

            // Act
            var result = await _testClass.GetAsync(postId);

            // Assert
            Assert.That(result.PostId, Is.EqualTo(postId));
        }

        private DbContextOptions<ApiDbContext> AddMockDbContextOptions()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();

            dbContextOptionsBuilder.UseInMemoryDatabase<ApiDbContext>("TestDb");

            return dbContextOptionsBuilder.Options;
        }

    }
}
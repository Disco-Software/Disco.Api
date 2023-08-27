namespace Disco.Test.Business.Like.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.Business.Services.Mappers;
    using Disco.Business.Services.Services;
    using Disco.Domain.Interfaces;
    using Disco.Domain.Models.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class LikeServiceTests
    {
        private LikeService _testClass;
        private Mock<ILikeRepository> _likeRepository;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            var mapper = new MapperConfiguration(m => m.AddProfile(new PostMapProfile())).CreateMapper();

            _likeRepository = new Mock<ILikeRepository>();
            _mapper = mapper;
            _testClass = new LikeService(_likeRepository.Object, _mapper);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new LikeService(_likeRepository.Object, _mapper);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallAddLikeAsync()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue1205884219",
                RefreshToken = "TestValue1315156872",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1935736745,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue414980864",
                        FollowersCount = 1652354316,
                        NextStatusId = 1390751822,
                        UserTarget = 1198473331,
                        AccountId = 604530090,
                        Account = default
                    },
                    Cread = "TestValue1649531484",
                    Photo = "TestValue1460112829",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1919094700,
                    User = default
                }
            };
            var post = new Post
            {
                Description = "TestValue878697040",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 492776516,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue261679507",
                        FollowersCount = 476981521,
                        NextStatusId = 578681158,
                        UserTarget = 1194807565,
                        AccountId = 2139364268,
                        Account = default
                    },
                    Cread = "TestValue1420786916",
                    Photo = "TestValue1894207982",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 307559809,
                    User = new User
                    {
                        RoleName = "TestValue1881879440",
                        RefreshToken = "TestValue1333439247",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1202435938,
                        Account = default
                    }
                }
            };

            _likeRepository.Setup(mock => mock.GetAsync(It.IsAny<int>())).ReturnsAsync(new Like
            {
                Id = 1,
                AccountId = 2088711288,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue303234276",
                        FollowersCount = 87031768,
                        NextStatusId = 1041841282,
                        UserTarget = 792608933,
                        AccountId = 1267550387,
                        Account = default
                    },
                    Cread = "TestValue1616455723",
                    Photo = "TestValue2120509859",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1613771315,
                    User = new User
                    {
                        RoleName = "TestValue657432497",
                        RefreshToken = "TestValue354965246",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 789951697,
                        Account = default
                    }
                },
                PostId = 1427444338,
                Post = new Post
                {
                    Description = "TestValue2061407146",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 440053164,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue937809761",
                            FollowersCount = 2052120757,
                            NextStatusId = 675076549,
                            UserTarget = 28823530,
                            AccountId = 381689726,
                            Account = default
                        },
                        Cread = "TestValue313999668",
                        Photo = "TestValue27437205",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 39066119,
                        User = new User
                        {
                            RoleName = "TestValue774836669",
                            RefreshToken = "TestValue924917550",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1327923888,
                            Account = default
                        }
                    }
                }
            });
            
            _likeRepository.Setup(mock => mock.AddAsync(It.IsAny<Like>())).Callback(() => post.Likes.Add(new Like()));
            _likeRepository.Setup(mock => mock.GetAsync(It.IsAny<int>())).ReturnsAsync(new Like
            {
                Id = 1,
                AccountId = 2088711288,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue303234276",
                        FollowersCount = 87031768,
                        NextStatusId = 1041841282,
                        UserTarget = 792608933,
                        AccountId = 1267550387,
                        Account = default
                    },
                    Cread = "TestValue1616455723",
                    Photo = "TestValue2120509859",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1613771315,
                    User = new User
                    {
                        RoleName = "TestValue657432497",
                        RefreshToken = "TestValue354965246",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 789951697,
                        Account = default
                    }
                },
                PostId = 1427444338,
                Post = new Post
                {
                    Description = "TestValue2061407146",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 440053164,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue937809761",
                            FollowersCount = 2052120757,
                            NextStatusId = 675076549,
                            UserTarget = 28823530,
                            AccountId = 381689726,
                            Account = default
                        },
                        Cread = "TestValue313999668",
                        Photo = "TestValue27437205",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 39066119,
                        User = new User
                        {
                            RoleName = "TestValue774836669",
                            RefreshToken = "TestValue924917550",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1327923888,
                            Account = default
                        }
                    }
                }
            });

            // Act
            var result = await _testClass.AddLikeAsync(user, post);

            // Assert
            _likeRepository.Verify(mock => mock.GetAsync(It.IsAny<int>()));
            _likeRepository.Verify(mock => mock.AddAsync(It.IsAny<Like>()));
        }

        [Test]
        public void CannotCallAddLikeAsyncWithNullUser()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.AddLikeAsync(default, new Post
            {
                Description = "TestValue2081073411",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 268994077,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue577593903",
                        FollowersCount = 1516492132,
                        NextStatusId = 433120942,
                        UserTarget = 2061274083,
                        AccountId = 264168156,
                        Account = default
                    },
                    Cread = "TestValue1459678746",
                    Photo = "TestValue116923732",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1612168692,
                    User = new User
                    {
                        RoleName = "TestValue61666168",
                        RefreshToken = "TestValue301298851",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 184773114,
                        Account = default
                    }
                }
            }));
        }

        [Test]
        public void CannotCallAddLikeAsyncWithNullPost()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.AddLikeAsync(new User
            {
                RoleName = "TestValue1198790451",
                RefreshToken = "TestValue1152561828",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1111697071,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1738962013",
                        FollowersCount = 822914248,
                        NextStatusId = 411875662,
                        UserTarget = 1127423982,
                        AccountId = 1166198708,
                        Account = default
                    },
                    Cread = "TestValue1173423717",
                    Photo = "TestValue182300033",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1914627670,
                    User = default
                }
            }, default));
        }

        [Test]
        public async Task CanCallGetAllLikesAsyncWithPostId()
        {
            // Arrange
            var postId = 2052191852;

            _likeRepository.Setup(mock => mock.GetAll(It.IsAny<int>())).ReturnsAsync(new List<Like>());

            // Act
            var result = await _testClass.GetAllLikesAsync(postId);

            // Assert
            _likeRepository.Verify(mock => mock.GetAll(It.IsAny<int>()));
        }

        [Test]
        public async Task CanCallRemoveLikeAsync()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue1632129208",
                RefreshToken = "TestValue1470003778",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 206015265,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue36237230",
                        FollowersCount = 907649694,
                        NextStatusId = 86694044,
                        UserTarget = 810449880,
                        AccountId = 1611783927,
                        Account = default
                    },
                    Cread = "TestValue697802432",
                    Photo = "TestValue1081160796",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 216982657,
                    User = default
                }
            };
            var post = new Post
            {
                Description = "TestValue2105628993",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1086214164,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue591804613",
                        FollowersCount = 737661389,
                        NextStatusId = 319581226,
                        UserTarget = 1598955954,
                        AccountId = 717399351,
                        Account = default
                    },
                    Cread = "TestValue1916685236",
                    Photo = "TestValue298539152",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2056980814,
                    User = new User
                    {
                        RoleName = "TestValue651505100",
                        RefreshToken = "TestValue823618261",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2078962956,
                        Account = default
                    }
                }
            };

            _likeRepository.Setup(mock => mock.GetAsync(It.IsAny<int>())).ReturnsAsync(new Like
            {
                AccountId = 1882802157,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue980113287",
                        FollowersCount = 47185499,
                        NextStatusId = 1501533400,
                        UserTarget = 1178193215,
                        AccountId = 1020364079,
                        Account = default
                    },
                    Cread = "TestValue1471488426",
                    Photo = "TestValue2129201272",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 733300807,
                    User = new User
                    {
                        RoleName = "TestValue481391100",
                        RefreshToken = "TestValue1383360239",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 813157919,
                        Account = default
                    }
                },
                PostId = 1829464846,
                Post = new Post
                {
                    Description = "TestValue171409148",
                    PostImages = new List<PostImage>(),
                    PostSongs = new List<PostSong>(),
                    PostVideos = new List<PostVideo>(),
                    Likes = new List<Like>(),
                    Comments = new List<Comment>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 1735741048,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue1195944673",
                            FollowersCount = 459415954,
                            NextStatusId = 761773308,
                            UserTarget = 1028091471,
                            AccountId = 200013339,
                            Account = default
                        },
                        Cread = "TestValue175682670",
                        Photo = "TestValue393908044",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 2143500761,
                        User = new User
                        {
                            RoleName = "TestValue986802440",
                            RefreshToken = "TestValue309089845",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 155245969,
                            Account = default
                        }
                    }
                }
            });
            
            _likeRepository.Setup(mock => mock.Remove(It.IsAny<Like>(), It.IsAny<int>())).Verifiable();

            // Act
            var result = await _testClass.RemoveLikeAsync(user, post);

            // Assert
            _likeRepository.Verify(mock => mock.GetAsync(It.IsAny<int>()));
            _likeRepository.Verify(mock => mock.Remove(It.IsAny<Like>(), It.IsAny<int>()));
        }

        [Test]
        public void CannotCallRemoveLikeAsyncWithNullUser()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.RemoveLikeAsync(default, new Post
            {
                Description = "TestValue706782754",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 411650409,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1301692209",
                        FollowersCount = 1714614331,
                        NextStatusId = 1876509182,
                        UserTarget = 1488894113,
                        AccountId = 984096173,
                        Account = default
                    },
                    Cread = "TestValue1207866706",
                    Photo = "TestValue1192443555",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1022947246,
                    User = new User
                    {
                        RoleName = "TestValue1535718518",
                        RefreshToken = "TestValue1484648",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1923186007,
                        Account = default
                    }
                }
            }));
        }

        [Test]
        public void CannotCallRemoveLikeAsyncWithNullPost()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.RemoveLikeAsync(new User
            {
                RoleName = "TestValue697063577",
                RefreshToken = "TestValue1721225053",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1296666195,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue2708039",
                        FollowersCount = 217680919,
                        NextStatusId = 1621090363,
                        UserTarget = 654580252,
                        AccountId = 978962016,
                        Account = default
                    },
                    Cread = "TestValue501270608",
                    Photo = "TestValue1823042791",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 436286858,
                    User = default
                }
            }, default));
        }

        [Test]
        public async Task CanCallGetAllLikesAsyncWithPostIdAndPageNumberAndPageSize()
        {
            // Arrange
            var postId = 1609835597;
            var pageNumber = 2003585091;
            var pageSize = 942435737;

            _likeRepository.Setup(mock => mock.GetAll(It.IsAny<int>())).ReturnsAsync(new List<Like>());

            // Act
            var result = await _testClass.GetAllLikesAsync(postId, pageNumber, pageSize);

            // Assert
            _likeRepository.Verify(mock => mock.GetAll(It.IsAny<int>()));
        }
    }
}
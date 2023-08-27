namespace Disco.Test.Business.Post.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.Business.Interfaces.Dtos.Posts;
    using Disco.Business.Services.Mappers;
    using Disco.Business.Services.Services;
    using Disco.Domain.Events.Events;
    using Disco.Domain.Interfaces;
    using Disco.Domain.Models.Models;
    using Disco.Integration.Interfaces.Interfaces;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class PostServiceTests
    {
        private PostService _testClass;
        private IMapper _mapper;
        
        private Mock<IEventPublisher> _eventPublisher;
        private Mock<IPostRepository> _postRepository;

        [SetUp]
        public void SetUp()
        {
            _mapper = new MapperConfiguration(x => x.AddProfile(new PostMapProfile()))
                .CreateMapper();
            
            _eventPublisher = new Mock<IEventPublisher>();
            _postRepository = new Mock<IPostRepository>();
            
            _testClass = new PostService(_mapper, _eventPublisher.Object, _postRepository.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new PostService(_mapper, _eventPublisher.Object, _postRepository.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreatePostAsync()
        {
            // Arrange
            var post = new Post
            {
                Description = "TestValue447096525",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1370648824,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue209200407",
                        FollowersCount = 1772718365,
                        NextStatusId = 1552934128,
                        UserTarget = 1313822709,
                        AccountId = 140233455,
                        Account = default
                    },
                    Cread = "TestValue842142793",
                    Photo = "TestValue1140445692",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 602275772,
                    User = new User
                    {
                        RoleName = "TestValue1557956225",
                        RefreshToken = "TestValue1661493018",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1175712199,
                        Account = default
                    }
                }
            };

            _postRepository.Setup(mock => mock.AddAsync(It.IsAny<Post>())).Verifiable();
            _eventPublisher.Setup(mock => mock.PublishAsync(It.IsAny<PostCreatedEvent>())).Verifiable();

            // Act
            await _testClass.CreatePostAsync(post);

            // Assert
            _postRepository.Verify(mock => mock.AddAsync(It.IsAny<Post>()));
            _eventPublisher.Verify(mock => mock.PublishAsync(It.IsAny<PostCreatedEvent>()));
        }

        [Test]
        public void CannotCallCreatePostAsyncWithNullPost()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.CreatePostAsync(default));
        }

        [Test]
        public async Task CanCallDeletePostAsync()
        {
            // Arrange
            var postId = 6734744;

            _postRepository.Setup(mock => mock.Remove(It.IsAny<int>())).Verifiable();

            // Act
            await _testClass.DeletePostAsync(postId);

            // Assert
            _postRepository.Verify(mock => mock.Remove(It.IsAny<int>()));
        }

        [Test]
        public async Task CanCallGetAllUserPostsWithUserAndDto()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue1451070189",
                RefreshToken = "TestValue675925445",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1490858752,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1376773968",
                        FollowersCount = 718416194,
                        NextStatusId = 599546159,
                        UserTarget = 438523294,
                        AccountId = 970899614,
                        Account = default
                    },
                    Cread = "TestValue243844557",
                    Photo = "TestValue418743580",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 567398207,
                    User = default
                }
            };
            var dto = new GetAllPostsDto
            {
                PageNumber = 1297835011,
                PageSize = 1768481243
            };

            _postRepository.Setup(mock => mock.GetUserPostsAsync(It.IsAny<int>())).ReturnsAsync(new List<Post>());

            // Act
            var result = await _testClass.GetAllUserPosts(user, dto);

            // Assert
            _postRepository.Verify(mock => mock.GetUserPostsAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
        }

        [Test]
        public void CannotCallGetAllUserPostsWithUserAndDtoWithNullUser()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.GetAllUserPosts(default, new GetAllPostsDto
            {
                PageNumber = 1789031489,
                PageSize = 842313769
            }));
        }

        [Test]
        public void CannotCallGetAllUserPostsWithUserAndDtoWithNullDto()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.GetAllUserPosts(new User
            {
                RoleName = "TestValue1341086384",
                RefreshToken = "TestValue1313845598",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 610909195,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1925503429",
                        FollowersCount = 1692733988,
                        NextStatusId = 625147378,
                        UserTarget = 621375079,
                        AccountId = 2077776269,
                        Account = default
                    },
                    Cread = "TestValue1467668140",
                    Photo = "TestValue1783801976",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 252029842,
                    User = default
                }
            }, default));
        }

        [Test]
        public async Task CanCallGetAllPostsAsyncWithUserAndPageNumberAndPageSize()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue294365658",
                RefreshToken = "TestValue1578814866",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1732441492,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1997071097",
                        FollowersCount = 205096142,
                        NextStatusId = 2053072855,
                        UserTarget = 1834401425,
                        AccountId = 1366133898,
                        Account = default
                    },
                    Cread = "TestValue1752781565",
                    Photo = "TestValue1231365216",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1638021195,
                    User = default
                }
            };
            var pageNumber = 536226075;
            var pageSize = 1473029699;

            _postRepository.Setup(mock => mock.GetUserPostsAsync(It.IsAny<int>())).ReturnsAsync(new List<Post>());

            // Act
            var result = await _testClass.GetAllPostsAsync(user, pageNumber, pageSize);

            // Assert
            _postRepository.Verify(mock => mock.GetUserPostsAsync(It.IsAny<int>()));
        }

        [Test]
        public void CannotCallGetAllPostsAsyncWithUserAndPageNumberAndPageSizeWithNullUser()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.GetAllPostsAsync(default, 710224414, 1430792874));
        }

        [Test]
        public async Task CanCallGetAllPostsAsyncWithUser()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue1623680558",
                RefreshToken = "TestValue1126804267",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1937940474,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1205320158",
                        FollowersCount = 255099117,
                        NextStatusId = 1692825113,
                        UserTarget = 498685613,
                        AccountId = 2147312671,
                        Account = default
                    },
                    Cread = "TestValue1946842955",
                    Photo = "TestValue1435913821",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 947047030,
                    User = default
                }
            };

            _postRepository.Setup(mock => mock.GetUserPostsAsync(It.IsAny<int>())).ReturnsAsync(new List<Post>());

            // Act
            var result = await _testClass.GetAllPostsAsync(user);

            // Assert
            _postRepository.Verify(mock => mock.GetUserPostsAsync(It.IsAny<int>()));
        }

        [Test]
        public void CannotCallGetAllPostsAsyncWithUserWithNullUser()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.GetAllPostsAsync(default));
        }

        [Test]
        public async Task CanCallGetPostAsync()
        {
            // Arrange
            var id = 661808999;

            _postRepository.Setup(mock => mock.GetAsync(It.IsAny<int>())).ReturnsAsync(new Post
            {
                Description = "TestValue1883473236",
                PostImages = new List<PostImage>(),
                PostSongs = new List<PostSong>(),
                PostVideos = new List<PostVideo>(),
                Likes = new List<Like>(),
                Comments = new List<Comment>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1630461858,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1529071013",
                        FollowersCount = 829695110,
                        NextStatusId = 745632823,
                        UserTarget = 23190611,
                        AccountId = 1740455639,
                        Account = default
                    },
                    Cread = "TestValue466386352",
                    Photo = "TestValue305180501",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1007192075,
                    User = new User
                    {
                        RoleName = "TestValue1385941769",
                        RefreshToken = "TestValue394257107",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 213647438,
                        Account = default
                    }
                }
            });

            // Act
            var result = await _testClass.GetPostAsync(id);

            // Assert
            _postRepository.Verify(mock => mock.GetAsync(It.IsAny<int>()));
        }

        [Test]
        public async Task CanCallGetPostsByDescriptionAsync()
        {
            // Arrange
            var search = "TestValue1610917233";

            _postRepository.Setup(mock => mock.GetPostsByDescriptionAsync(It.IsAny<string>())).ReturnsAsync(new List<Post>());

            // Act
            var result = await _testClass.GetPostsByDescriptionAsync(search);

            // Assert
            _postRepository.Verify(mock => mock.GetPostsByDescriptionAsync(It.IsAny<string>()));
        }

        [Test]
        public async Task CanCallGetAllUserPostsWithUser()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue402347345",
                RefreshToken = "TestValue36249924",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1758432200,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1850548836",
                        FollowersCount = 777619523,
                        NextStatusId = 1285363143,
                        UserTarget = 1215279015,
                        AccountId = 261941114,
                        Account = default
                    },
                    Cread = "TestValue1148950467",
                    Photo = "TestValue1642054459",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 139835795,
                    User = default
                }
            };

            _postRepository.Setup(mock => mock.GetUserPostsAsync(It.IsAny<int>())).ReturnsAsync(new List<Post>());

            // Act
            var result = await _testClass.GetAllUserPosts(user);

            // Assert
            _postRepository.Verify(mock => mock.GetUserPostsAsync(It.IsAny<int>()));
        }

        [Test]
        public void CannotCallGetAllUserPostsWithUserWithNullUser()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.GetAllUserPosts(default));
        }
    }
}
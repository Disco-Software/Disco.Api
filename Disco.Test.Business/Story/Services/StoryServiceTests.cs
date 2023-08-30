namespace Disco.Test.Business.Story.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Disco.Business.Interfaces.Dtos.Stories;
    using Disco.Business.Services.Services;
    using Disco.Domain.Interfaces;
    using Disco.Domain.Models.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class StoryServiceTests
    {
        private StoryService _testClass;
        private Mock<IStoryRepository> _storyRepository;

        [SetUp]
        public void SetUp()
        {
            _storyRepository = new Mock<IStoryRepository>();
            _testClass = new StoryService(_storyRepository.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new StoryService(_storyRepository.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreateStoryAsync()
        {
            // Arrange
            var story = new Story
            {
                StoryImages = new List<StoryImage>(),
                StoryVideos = new List<StoryVideo>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 2121240445,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue746413506",
                        FollowersCount = 107509986,
                        NextStatusId = 577623576,
                        UserTarget = 1141137415,
                        AccountId = 1740241021,
                        Account = default
                    },
                    Cread = "TestValue2030720162",
                    Photo = "TestValue2072817552",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1934305518,
                    User = new User
                    {
                        RoleName = "TestValue1804831972",
                        RefreshToken = "TestValue901322961",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 407889120,
                        Account = default
                    }
                }
            };

            _storyRepository.Setup(mock => mock.AddAsync(It.IsAny<Story>())).Verifiable();

            // Act
            await _testClass.CreateStoryAsync(story);

            // Assert
            _storyRepository.Verify(mock => mock.AddAsync(It.IsAny<Story>()));
        }

        [Test]
        public void CannotCallCreateStoryAsyncWithNullStory()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.CreateStoryAsync(default));
        }

        [Test]
        public async Task CanCallDeleteStoryAsync()
        {
            // Arrange
            var id = 1667047888;

            _storyRepository.Setup(mock => mock.RemoveAsync(It.IsAny<int>())).Verifiable();

            // Act
            await _testClass.DeleteStoryAsync(id);

            // Assert
            _storyRepository.Verify(mock => mock.RemoveAsync(It.IsAny<int>()));
        }

        [Test]
        public async Task CanCallGetStoryAsync()
        {
            // Arrange
            var id = 1992630376;

            _storyRepository.Setup(mock => mock.GetAsync(It.IsAny<int>())).ReturnsAsync(new Story
            {
                StoryImages = new List<StoryImage>(),
                StoryVideos = new List<StoryVideo>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1872640625,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1670077867",
                        FollowersCount = 961339726,
                        NextStatusId = 967651274,
                        UserTarget = 1379522539,
                        AccountId = 1894547997,
                        Account = default
                    },
                    Cread = "TestValue1649037440",
                    Photo = "TestValue919441703",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1274976437,
                    User = new User
                    {
                        RoleName = "TestValue1360928490",
                        RefreshToken = "TestValue225844661",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 169174611,
                        Account = default
                    }
                }
            });

            // Act
            var result = await _testClass.GetStoryAsync(id);

            // Assert
            _storyRepository.Verify(mock => mock.GetAsync(It.IsAny<int>()));
        }

        [Test]
        public async Task CanCallGetAllStoryAsync()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue643393582",
                RefreshToken = "TestValue1186926053",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 573393423,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1198061110",
                        FollowersCount = 816880526,
                        NextStatusId = 2076662610,
                        UserTarget = 71573295,
                        AccountId = 304282137,
                        Account = default
                    },
                    Cread = "TestValue2037295688",
                    Photo = "TestValue1168503657",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2065570150,
                    User = default
                }
            };
            var dto = new GetAllStoriesDto
            {
                PageNumber = 2000680379,
                PageSize = 1596278027
            };

            _storyRepository.Setup(mock => mock.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new List<Story>());

            // Act
            var result = await _testClass.GetAllStoryAsync(user, dto);

            // Assert
            _storyRepository.Verify(mock => mock.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
        }

        [Test]
        public void CannotCallGetAllStoryAsyncWithNullUser()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.GetAllStoryAsync(default, new GetAllStoriesDto
            {
                PageNumber = 810844884,
                PageSize = 1701707114
            }));
        }

        [Test]
        public void CannotCallGetAllStoryAsyncWithNullDto()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.GetAllStoryAsync(new User
            {
                RoleName = "TestValue1420615782",
                RefreshToken = "TestValue1496798628",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 989830573,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1157059186",
                        FollowersCount = 66962453,
                        NextStatusId = 2096503784,
                        UserTarget = 94233257,
                        AccountId = 2052093492,
                        Account = default
                    },
                    Cread = "TestValue192769639",
                    Photo = "TestValue57160860",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 993911062,
                    User = default
                }
            }, default));
        }
    }
}
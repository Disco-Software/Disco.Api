namespace Disco.ApiServices.Test.Features.Story.RequestHandlers.CreateStory
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.ApiServices.Features.Story.RequestHandlers.CreateStory;
    using Disco.Business.Interfaces.Dtos.Stories;
    using Disco.Business.Interfaces.Dtos.StoryImages;
    using Disco.Business.Interfaces.Dtos.StoryVideos;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class CreateStoryRequestHandlerTests
    {
        private CreateStoryRequestHandler _testClass;
        private IAccountService _accountService;
        private IStoryService _storyService;
        private IStoryImageService _storyImageService;
        private IStoryVideoService _storyVideoService;
        private IHttpContextAccessor _contextAccessor;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _accountService = Substitute.For<IAccountService>();
            _storyService = Substitute.For<IStoryService>();
            _storyImageService = Substitute.For<IStoryImageService>();
            _storyVideoService = Substitute.For<IStoryVideoService>();
            _contextAccessor = Substitute.For<IHttpContextAccessor>();
            _mapper = Substitute.For<IMapper>();
            _testClass = new CreateStoryRequestHandler(_accountService, _storyService, _storyImageService, _storyVideoService, _contextAccessor, _mapper);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new CreateStoryRequestHandler(_accountService, _storyService, _storyImageService, _storyVideoService, _contextAccessor, _mapper);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullAccountService()
        {
            Assert.Throws<ArgumentNullException>(() => new CreateStoryRequestHandler(default(IAccountService), _storyService, _storyImageService, _storyVideoService, _contextAccessor, _mapper));
        }

        [Test]
        public void CannotConstructWithNullStoryService()
        {
            Assert.Throws<ArgumentNullException>(() => new CreateStoryRequestHandler(_accountService, default(IStoryService), _storyImageService, _storyVideoService, _contextAccessor, _mapper));
        }

        [Test]
        public void CannotConstructWithNullStoryImageService()
        {
            Assert.Throws<ArgumentNullException>(() => new CreateStoryRequestHandler(_accountService, _storyService, default(IStoryImageService), _storyVideoService, _contextAccessor, _mapper));
        }

        [Test]
        public void CannotConstructWithNullStoryVideoService()
        {
            Assert.Throws<ArgumentNullException>(() => new CreateStoryRequestHandler(_accountService, _storyService, _storyImageService, default(IStoryVideoService), _contextAccessor, _mapper));
        }

        [Test]
        public void CannotConstructWithNullContextAccessor()
        {
            Assert.Throws<ArgumentNullException>(() => new CreateStoryRequestHandler(_accountService, _storyService, _storyImageService, _storyVideoService, default(IHttpContextAccessor), _mapper));
        }

        [Test]
        public void CannotConstructWithNullMapper()
        {
            Assert.Throws<ArgumentNullException>(() => new CreateStoryRequestHandler(_accountService, _storyService, _storyImageService, _storyVideoService, _contextAccessor, default(IMapper)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new CreateStoryRequest(new CreateStoryDto
            {
                StoryImages = new List<IFormFile>(),
                StoryVideos = new List<IFormFile>(),
                ProfileId = 409310058
            });
            var cancellationToken = CancellationToken.None;

            _accountService.GetAsync(Arg.Any<ClaimsPrincipal>()).Returns(new User
            {
                RoleName = "TestValue1843749334",
                RefreshToken = "TestValue1932953618",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1197222174,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue751901424",
                        FollowersCount = 56394259,
                        NextStatusId = 1720427472,
                        UserTarget = 1517749127,
                        AccountId = 1525829702,
                        Account = default(Account)
                    },
                    Cread = "TestValue977869523",
                    Photo = "TestValue1938402068",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1346559332,
                    User = default(User)
                }
            });
            _storyImageService.CreateStoryImageAsync(Arg.Any<CreateStoryImageDto>()).Returns(new StoryImage
            {
                Source = "TestValue504311542",
                DateOfCreation = DateTime.UtcNow,
                StoryId = 917906301,
                Story = new Story
                {
                    StoryImages = new List<StoryImage>(),
                    StoryVideos = new List<StoryVideo>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 110566335,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue999563257",
                            FollowersCount = 565851363,
                            NextStatusId = 465776315,
                            UserTarget = 1003123075,
                            AccountId = 1602273455,
                            Account = default(Account)
                        },
                        Cread = "TestValue828656024",
                        Photo = "TestValue2133606486",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 1594112489,
                        User = new User
                        {
                            RoleName = "TestValue1046162584",
                            RefreshToken = "TestValue1345972526",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1775403704,
                            Account = default(Account)
                        }
                    }
                }
            });
            _storyVideoService.CreateStoryVideoAsync(Arg.Any<CreateStoryVideoDto>()).Returns(new StoryVideo
            {
                Source = "TestValue1764077675",
                DateOfCreation = DateTime.UtcNow,
                StoryId = 201734191,
                Story = new Story
                {
                    StoryImages = new List<StoryImage>(),
                    StoryVideos = new List<StoryVideo>(),
                    DateOfCreation = DateTime.UtcNow,
                    AccountId = 801418584,
                    Account = new Account
                    {
                        AccountStatus = new AccountStatus
                        {
                            LastStatus = "TestValue718051353",
                            FollowersCount = 1535792447,
                            NextStatusId = 1616270535,
                            UserTarget = 972084325,
                            AccountId = 787173687,
                            Account = default(Account)
                        },
                        Cread = "TestValue1881584564",
                        Photo = "TestValue810868287",
                        AccountGroups = new List<AccountGroup>(),
                        Connections = new List<Connection>(),
                        Messages = new List<Message>(),
                        Posts = new List<Post>(),
                        Comments = new List<Comment>(),
                        Likes = new List<Like>(),
                        Followers = new List<UserFollower>(),
                        Following = new List<UserFollower>(),
                        Stories = new List<Story>(),
                        UserId = 1796492057,
                        User = new User
                        {
                            RoleName = "TestValue6359848",
                            RefreshToken = "TestValue1821633851",
                            RefreshTokenExpiress = DateTime.UtcNow,
                            DateOfRegister = DateTime.UtcNow,
                            AccountId = 1556269653,
                            Account = default(Account)
                        }
                    }
                }
            });
            _contextAccessor.HttpContext.Returns(new DefaultHttpContext());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountService.Received().GetAsync(Arg.Any<ClaimsPrincipal>());
            await _storyService.Received().CreateStoryAsync(Arg.Any<Story>());
            await _storyImageService.Received().CreateStoryImageAsync(Arg.Any<CreateStoryImageDto>());
            await _storyVideoService.Received().CreateStoryVideoAsync(Arg.Any<CreateStoryVideoDto>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(CreateStoryRequest), CancellationToken.None));
        }
    }
}
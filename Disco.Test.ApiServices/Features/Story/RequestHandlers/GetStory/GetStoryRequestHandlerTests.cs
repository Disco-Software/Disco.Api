namespace Disco.ApiServices.Test.Features.Story.RequestHandlers.GetStory
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Story.RequestHandlers.GetStory;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class GetStoryRequestHandlerTests
    {
        private GetStoryRequestHandler _testClass;
        private IStoryService _storyService;

        [SetUp]
        public void SetUp()
        {
            _storyService = Substitute.For<IStoryService>();
            _testClass = new GetStoryRequestHandler(_storyService);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetStoryRequestHandler(_storyService);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullStoryService()
        {
            Assert.Throws<ArgumentNullException>(() => new GetStoryRequestHandler(default(IStoryService)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new GetStoryRequest(1720508482);
            var cancellationToken = CancellationToken.None;

            _storyService.GetStoryAsync(Arg.Any<int>()).Returns(new Story
            {
                StoryImages = new List<StoryImage>(),
                StoryVideos = new List<StoryVideo>(),
                DateOfCreation = DateTime.UtcNow,
                AccountId = 1354414806,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1593840999",
                        FollowersCount = 1622659084,
                        NextStatusId = 687643717,
                        UserTarget = 561231442,
                        AccountId = 909701023,
                        Account = default(Account)
                    },
                    Cread = "TestValue155110201",
                    Photo = "TestValue697652484",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1116469422,
                    User = new User
                    {
                        RoleName = "TestValue1038100424",
                        RefreshToken = "TestValue1186177523",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 403876905,
                        Account = default(Account)
                    }
                }
            });

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _storyService.Received().GetStoryAsync(Arg.Any<int>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(GetStoryRequest), CancellationToken.None));
        }
    }
}
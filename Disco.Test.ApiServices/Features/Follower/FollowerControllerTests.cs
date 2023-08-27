namespace Disco.Test.ApiServices.Features.Follower
{
    using System;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Follower;
    using Disco.Business.Interfaces.Dtos.Friends;
    using MediatR;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class FollowerControllerTests
    {
        private FollowerController _testClass;
        private IMediator _mediator;

        [SetUp]
        public void SetUp()
        {
            _mediator = Substitute.For<IMediator>();
            _testClass = new FollowerController(_mediator);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new FollowerController(_mediator);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullMediator()
        {
            Assert.Throws<ArgumentNullException>(() => new FollowerController(default(IMediator)));
        }

        [Test]
        public async Task CanCallCreate()
        {
            // Arrange
            var dto = new CreateFollowerDto
            {
                FollowingAccountId = 554691878,
                IntalationId = "TestValue2073145093"
            };

            // Act
            var result = await _testClass.Create(dto);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallCreateWithNullDto()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Create(default(CreateFollowerDto)));
        }

        [Test]
        public async Task CanCallGetFollowerAsync()
        {
            // Arrange
            var followerId = 1046228707;

            // Act
            var result = await _testClass.GetFollowerAsync(followerId);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public async Task CanCallGetFollowersAsync()
        {
            // Arrange
            var dto = new GetFollowersDto
            {
                UserId = 1929134476,
                PageNumber = 69037848,
                PageSize = 1955495393
            };

            // Act
            var result = await _testClass.GetFollowersAsync(dto);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallGetFollowersAsyncWithNullDto()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.GetFollowersAsync(default(GetFollowersDto)));
        }

        [Test]
        public async Task CanCallGetFollowingAsync()
        {
            // Arrange
            var dto = new GetFollowersDto
            {
                UserId = 1036783219,
                PageNumber = 2083986493,
                PageSize = 44677526
            };

            // Act
            var result = await _testClass.GetFollowingAsync(dto);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallGetFollowingAsyncWithNullDto()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.GetFollowingAsync(default(GetFollowersDto)));
        }

        [Test]
        public async Task CanCallGetRecomendedAsync()
        {
            // Act
            var result = await _testClass.GetRecomendedAsync();

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public async Task CanCallDeleteFollowerAsync()
        {
            // Arrange
            var followerId = 1470960554;

            // Act
            await _testClass.DeleteFollowerAsync(followerId);

            // Assert
            Assert.Fail("Create or modify test");
        }
    }
}
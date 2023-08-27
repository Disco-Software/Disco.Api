namespace Disco.Test.ApiServices.Features.Follower.RequestHandlers.DeleteFollower
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Follower.RequestHandlers.DeleteFollower;
    using Disco.Business.Interfaces.Interfaces;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class DeleteFollowerRequestHandlerTests
    {
        private DeleteFollowerRequestHandler _testClass;
        private IFollowerService _followerService;

        [SetUp]
        public void SetUp()
        {
            _followerService = Substitute.For<IFollowerService>();
            _testClass = new DeleteFollowerRequestHandler(_followerService);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new DeleteFollowerRequestHandler(_followerService);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullFollowerService()
        {
            Assert.Throws<ArgumentNullException>(() => new DeleteFollowerRequestHandler(default(IFollowerService)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new DeleteFollowerRequest(128201275);
            var cancellationToken = CancellationToken.None;

            // Act
            await _testClass.Handle(request, cancellationToken);

            // Assert
            await _followerService.Received().DeleteAsync(Arg.Any<int>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(DeleteFollowerRequest), CancellationToken.None));
        }
    }
}
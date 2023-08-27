namespace Disco.Test.ApiServices.Features.Follower.RequestHandlers.GetFollowing
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Follower.RequestHandlers.GetFollowing;
    using Disco.Business.Interfaces.Dtos.Friends;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class GetFollowingRequestHandlerTests
    {
        private GetFollowingRequestHandler _testClass;
        private IFollowerService _followerService;

        [SetUp]
        public void SetUp()
        {
            _followerService = Substitute.For<IFollowerService>();
            _testClass = new GetFollowingRequestHandler(_followerService);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetFollowingRequestHandler(_followerService);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullFollowerService()
        {
            Assert.Throws<ArgumentNullException>(() => new GetFollowingRequestHandler(default(IFollowerService)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new GetFollowingRequest(new GetFollowersDto
            {
                UserId = 1942079112,
                PageNumber = 178517806,
                PageSize = 2142035508
            });
            var cancellationToken = CancellationToken.None;

            _followerService.GetFollowingAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(new List<UserFollower>());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _followerService.Received().GetFollowingAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(GetFollowingRequest), CancellationToken.None));
        }
    }
}
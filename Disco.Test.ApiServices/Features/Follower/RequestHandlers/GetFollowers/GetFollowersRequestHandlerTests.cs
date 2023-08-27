namespace Disco.Test.ApiServices.Features.Follower.RequestHandlers.GetFollowers
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Follower.RequestHandlers.GetFollowers;
    using Disco.Business.Interfaces.Dtos.Friends;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class GetFollowersRequestHandlerTests
    {
        private GetFollowersRequestHandler _testClass;
        private IFollowerService _followerService;

        [SetUp]
        public void SetUp()
        {
            _followerService = Substitute.For<IFollowerService>();
            _testClass = new GetFollowersRequestHandler(_followerService);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetFollowersRequestHandler(_followerService);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullFollowerService()
        {
            Assert.Throws<ArgumentNullException>(() => new GetFollowersRequestHandler(default(IFollowerService)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new GetFollowersRequest(new GetFollowersDto
            {
                UserId = 734087356,
                PageNumber = 61205615,
                PageSize = 1296889748
            });
            var cancellationToken = CancellationToken.None;

            _followerService.GetFollowersAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>()).Returns(new List<UserFollower>());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _followerService.Received().GetFollowersAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(GetFollowersRequest), CancellationToken.None));
        }
    }
}
namespace Disco.Test.ApiServices.Features.Follower.RequestHandlers.GetFollowing
{
    using System;
    using Disco.ApiServices.Features.Follower.RequestHandlers.GetFollowing;
    using Disco.Business.Interfaces.Dtos.Friends;
    using NUnit.Framework;

    [TestFixture]
    public class GetFollowingRequestTests
    {
        private GetFollowingRequest _testClass;
        private GetFollowersDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new GetFollowersDto
            {
                UserId = 1087707166,
                PageNumber = 983746541,
                PageSize = 356357371
            };
            _testClass = new GetFollowingRequest(_dto);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetFollowingRequest(_dto);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullDto()
        {
            Assert.Throws<ArgumentNullException>(() => new GetFollowingRequest(default(GetFollowersDto)));
        }

        [Test]
        public void DtoIsInitializedCorrectly()
        {
            Assert.That(_testClass.Dto, Is.SameAs(_dto));
        }
    }
}
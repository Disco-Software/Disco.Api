namespace Disco.Test.ApiServices.Features.Follower.RequestHandlers.GetFollowers
{
    using System;
    using Disco.ApiServices.Features.Follower.RequestHandlers.GetFollowers;
    using Disco.Business.Interfaces.Dtos.Friends;
    using NUnit.Framework;

    [TestFixture]
    public class GetFollowersRequestTests
    {
        private GetFollowersRequest _testClass;
        private GetFollowersDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new GetFollowersDto
            {
                UserId = 807905071,
                PageNumber = 866544577,
                PageSize = 659252277
            };
            _testClass = new GetFollowersRequest(_dto);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetFollowersRequest(_dto);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void DtoIsInitializedCorrectly()
        {
            Assert.That(_testClass.Dto, Is.SameAs(_dto));
        }
    }
}
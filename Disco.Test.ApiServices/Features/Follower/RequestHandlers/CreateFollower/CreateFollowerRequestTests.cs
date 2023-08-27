namespace Disco.Test.ApiServices.Features.Follower.RequestHandlers.CreateFollower
{
    using System;
    using Disco.ApiServices.Features.Follower.RequestHandlers.CreateFollower;
    using Disco.Business.Interfaces.Dtos.Friends;
    using NUnit.Framework;

    [TestFixture]
    public class CreateFollowerRequestTests
    {
        private CreateFollowerRequest _testClass;
        private CreateFollowerDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new CreateFollowerDto
            {
                FollowingAccountId = 30233699,
                IntalationId = "TestValue579936386"
            };
            _testClass = new CreateFollowerRequest(_dto);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new CreateFollowerRequest(_dto);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullDto()
        {
            Assert.Throws<ArgumentNullException>(() => new CreateFollowerRequest(default(CreateFollowerDto)));
        }

        [Test]
        public void DtoIsInitializedCorrectly()
        {
            Assert.That(_testClass.Dto, Is.SameAs(_dto));
        }
    }
}
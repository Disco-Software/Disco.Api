namespace Disco.Test.ApiServices.Features.Follower.RequestHandlers.GetFollower
{
    using System;
    using Disco.ApiServices.Features.Follower.RequestHandlers.GetFollower;
    using NUnit.Framework;

    [TestFixture]
    public class GetFollowerRequestTests
    {
        private GetFollowerRequest _testClass;
        private int _id;

        [SetUp]
        public void SetUp()
        {
            _id = 1286627297;
            _testClass = new GetFollowerRequest(_id);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetFollowerRequest(_id);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void IdIsInitializedCorrectly()
        {
            Assert.That(_testClass.Id, Is.EqualTo(_id));
        }
    }
}
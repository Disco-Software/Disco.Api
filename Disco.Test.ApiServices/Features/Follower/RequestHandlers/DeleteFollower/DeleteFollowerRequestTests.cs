namespace Disco.Test.ApiServices.Features.Follower.RequestHandlers.DeleteFollower
{
    using System;
    using Disco.ApiServices.Features.Follower.RequestHandlers.DeleteFollower;
    using NUnit.Framework;

    [TestFixture]
    public class DeleteFollowerRequestTests
    {
        private DeleteFollowerRequest _testClass;
        private int _id;

        [SetUp]
        public void SetUp()
        {
            _id = 121169001;
            _testClass = new DeleteFollowerRequest(_id);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new DeleteFollowerRequest(_id);

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
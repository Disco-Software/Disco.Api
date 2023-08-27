namespace Disco.ApiServices.Test.Features.Story.RequestHandlers.GetStory
{
    using System;
    using Disco.ApiServices.Features.Story.RequestHandlers.GetStory;
    using NUnit.Framework;

    [TestFixture]
    public class GetStoryRequestTests
    {
        private GetStoryRequest _testClass;
        private int _id;

        [SetUp]
        public void SetUp()
        {
            _id = 791626111;
            _testClass = new GetStoryRequest(_id);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetStoryRequest(_id);

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
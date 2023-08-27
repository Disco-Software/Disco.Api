namespace Disco.ApiServices.Test.Features.Story.RequestHandlers.DeleteStory
{
    using System;
    using Disco.ApiServices.Features.Story.RequestHandlers.DeleteStory;
    using NUnit.Framework;

    [TestFixture]
    public class DeleteStoryRequestTests
    {
        private DeleteStoryRequest _testClass;
        private int _id;

        [SetUp]
        public void SetUp()
        {
            _id = 1902508066;
            _testClass = new DeleteStoryRequest(_id);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new DeleteStoryRequest(_id);

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
namespace Disco.Test.Business.StoryImage.StoryImages
{
    using System;
    using Disco.Business.Interfaces.Dtos.StoryImages;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class CreateStoryImageDtoTests
    {
        private CreateStoryImageDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new CreateStoryImageDto();
        }

        [Test]
        public void CanSetAndGetStoryImageFile()
        {
            // Arrange
            var testValue = new Mock<IFormFile>().Object;

            // Act
            _testClass.StoryImageFile = testValue;

            // Assert
            Assert.That(_testClass.StoryImageFile, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetStoryId()
        {
            // Arrange
            var testValue = 1648624315;

            // Act
            _testClass.StoryId = testValue;

            // Assert
            Assert.That(_testClass.StoryId, Is.EqualTo(testValue));
        }
    }
}
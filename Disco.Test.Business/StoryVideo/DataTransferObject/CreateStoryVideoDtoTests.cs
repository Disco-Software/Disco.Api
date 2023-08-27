namespace Disco.Test.Business.StoryVideo.StoryVideos
{
    using System;
    using Disco.Business.Interfaces.Dtos.StoryVideos;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class CreateStoryVideoDtoTests
    {
        private CreateStoryVideoDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new CreateStoryVideoDto();
        }

        [Test]
        public void CanSetAndGetVideoFile()
        {
            // Arrange
            var testValue = new Mock<IFormFile>().Object;

            // Act
            _testClass.VideoFile = testValue;

            // Assert
            Assert.That(_testClass.VideoFile, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetStoryId()
        {
            // Arrange
            var testValue = 621147895;

            // Act
            _testClass.StoryId = testValue;

            // Assert
            Assert.That(_testClass.StoryId, Is.EqualTo(testValue));
        }
    }
}
namespace Disco.Test.Business.Video.Videos
{
    using System;
    using Disco.Business.Interfaces.Dtos.Videos;
    using Microsoft.AspNetCore.Http;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class CreateVideoDtoTests
    {
        private CreateVideoDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new CreateVideoDto();
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
        public void CanSetAndGetPostId()
        {
            // Arrange
            var testValue = 1285994607;

            // Act
            _testClass.PostId = testValue;

            // Assert
            Assert.That(_testClass.PostId, Is.EqualTo(testValue));
        }
    }
}
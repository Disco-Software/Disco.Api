namespace Disco.Test.Business.Story.Stories
{
    using System;
    using System.Collections.Generic;
    using Disco.Business.Interfaces.Dtos.Stories;
    using Microsoft.AspNetCore.Http;
    using NUnit.Framework;

    [TestFixture]
    public class CreateStoryDtoTests
    {
        private CreateStoryDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new CreateStoryDto();
        }

        [Test]
        public void CanSetAndGetStoryImages()
        {
            // Arrange
            var testValue = new List<IFormFile>();

            // Act
            _testClass.StoryImages = testValue;

            // Assert
            Assert.That(_testClass.StoryImages, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetStoryVideos()
        {
            // Arrange
            var testValue = new List<IFormFile>();

            // Act
            _testClass.StoryVideos = testValue;

            // Assert
            Assert.That(_testClass.StoryVideos, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetProfileId()
        {
            // Arrange
            var testValue = 1879280573;

            // Act
            _testClass.ProfileId = testValue;

            // Assert
            Assert.That(_testClass.ProfileId, Is.EqualTo(testValue));
        }
    }
}
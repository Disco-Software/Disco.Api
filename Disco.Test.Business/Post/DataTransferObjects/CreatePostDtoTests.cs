namespace Disco.Test.Business.Post.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using Disco.Business.Interfaces.Dtos.Posts;
    using Microsoft.AspNetCore.Http;
    using NUnit.Framework;

    [TestFixture]
    public class CreatePostDtoTests
    {
        private CreatePostDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new CreatePostDto();
        }

        [Test]
        public void CanSetAndGetDescription()
        {
            // Arrange
            var testValue = "TestValue1528702859";

            // Act
            _testClass.Description = testValue;

            // Assert
            Assert.That(_testClass.Description, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetPostImages()
        {
            // Arrange
            var testValue = new List<IFormFile>();

            // Act
            _testClass.PostImages = testValue;

            // Assert
            Assert.That(_testClass.PostImages, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetPostSongs()
        {
            // Arrange
            var testValue = new List<IFormFile>();

            // Act
            _testClass.PostSongs = testValue;

            // Assert
            Assert.That(_testClass.PostSongs, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetPostSongImages()
        {
            // Arrange
            var testValue = new List<IFormFile>();

            // Act
            _testClass.PostSongImages = testValue;

            // Assert
            Assert.That(_testClass.PostSongImages, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetPostSongNames()
        {
            // Arrange
            var testValue = new List<string>();

            // Act
            _testClass.PostSongNames = testValue;

            // Assert
            Assert.That(_testClass.PostSongNames, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetExecutorNames()
        {
            // Arrange
            var testValue = new List<string>();

            // Act
            _testClass.ExecutorNames = testValue;

            // Assert
            Assert.That(_testClass.ExecutorNames, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetPostVideos()
        {
            // Arrange
            var testValue = new List<IFormFile>();

            // Act
            _testClass.PostVideos = testValue;

            // Assert
            Assert.That(_testClass.PostVideos, Is.SameAs(testValue));
        }
    }
}
namespace Disco.Domain.Events.Test.Dto
{
    using System;
    using Disco.Domain.Events.Dto;
    using NUnit.Framework;

    [TestFixture]
    public class PostSongDtoTests
    {
        private PostSongDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new PostSongDto();
        }

        [Test]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue1299293429";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.That(_testClass.Name, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetImageUrl()
        {
            // Arrange
            var testValue = "TestValue17231175";

            // Act
            _testClass.ImageUrl = testValue;

            // Assert
            Assert.That(_testClass.ImageUrl, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetSource()
        {
            // Arrange
            var testValue = "TestValue313206571";

            // Act
            _testClass.Source = testValue;

            // Assert
            Assert.That(_testClass.Source, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetExecutorName()
        {
            // Arrange
            var testValue = "TestValue2049262837";

            // Act
            _testClass.ExecutorName = testValue;

            // Assert
            Assert.That(_testClass.ExecutorName, Is.EqualTo(testValue));
        }
    }
}
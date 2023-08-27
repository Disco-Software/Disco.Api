namespace Disco.Test.Business.PushNotification.PushNotifications
{
    using System;
    using Disco.Business.Interfaces.Dtos.PushNotifications;
    using NUnit.Framework;

    [TestFixture]
    public class LikeNotificationDtoTests
    {
        private LikeNotificationDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new LikeNotificationDto();
        }

        [Test]
        public void CanSetAndGetTitle()
        {
            // Arrange
            var testValue = "TestValue1908326277";

            // Act
            _testClass.Title = testValue;

            // Assert
            Assert.That(_testClass.Title, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetBody()
        {
            // Arrange
            var testValue = "TestValue211752780";

            // Act
            _testClass.Body = testValue;

            // Assert
            Assert.That(_testClass.Body, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = "TestValue1907181623";

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.That(_testClass.Id, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetTags()
        {
            // Arrange
            var testValue = "TestValue509500456";

            // Act
            _testClass.Tags = testValue;

            // Assert
            Assert.That(_testClass.Tags, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetNotificationType()
        {
            // Arrange
            var testValue = "TestValue1575689880";

            // Act
            _testClass.NotificationType = testValue;

            // Assert
            Assert.That(_testClass.NotificationType, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetLikesCount()
        {
            // Arrange
            var testValue = 1600343232;

            // Act
            _testClass.LikesCount = testValue;

            // Assert
            Assert.That(_testClass.LikesCount, Is.EqualTo(testValue));
        }
    }
}
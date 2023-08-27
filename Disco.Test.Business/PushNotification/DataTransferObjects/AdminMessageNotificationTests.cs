namespace Disco.Test.Business.PushNotification.PushNotifications
{
    using System;
    using Disco.Business.Interfaces.Dtos.PushNotifications;
    using NUnit.Framework;

    [TestFixture]
    public class AdminMessageNotificationDtoTests
    {
        private AdminMessageNotificationDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new AdminMessageNotificationDto();
        }

        [Test]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = "TestValue923086455";

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.That(_testClass.Id, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetTitle()
        {
            // Arrange
            var testValue = "TestValue485732393";

            // Act
            _testClass.Title = testValue;

            // Assert
            Assert.That(_testClass.Title, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetBody()
        {
            // Arrange
            var testValue = "TestValue1614830583";

            // Act
            _testClass.Body = testValue;

            // Assert
            Assert.That(_testClass.Body, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetTags()
        {
            // Arrange
            var testValue = "TestValue943254083";

            // Act
            _testClass.Tags = testValue;

            // Assert
            Assert.That(_testClass.Tags, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetNotificationType()
        {
            // Arrange
            var testValue = "TestValue1006643347";

            // Act
            _testClass.NotificationType = testValue;

            // Assert
            Assert.That(_testClass.NotificationType, Is.EqualTo(testValue));
        }
    }
}
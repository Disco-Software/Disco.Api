namespace Disco.Test.Business.PushNotification.PushNotifications
{
    using System;
    using Disco.Business.Interfaces.Dtos.PushNotifications;
    using NUnit.Framework;

    [TestFixture]
    public class NewFriendNotificationDtoTests
    {
        private NewFriendNotificationDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new NewFriendNotificationDto();
        }

        [Test]
        public void CanSetAndGetTitle()
        {
            // Arrange
            var testValue = "TestValue1272699807";

            // Act
            _testClass.Title = testValue;

            // Assert
            Assert.That(_testClass.Title, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetBody()
        {
            // Arrange
            var testValue = "TestValue235718253";

            // Act
            _testClass.Body = testValue;

            // Assert
            Assert.That(_testClass.Body, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = "TestValue1981849087";

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.That(_testClass.Id, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetTags()
        {
            // Arrange
            var testValue = "TestValue278719796";

            // Act
            _testClass.Tags = testValue;

            // Assert
            Assert.That(_testClass.Tags, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetNotificationType()
        {
            // Arrange
            var testValue = "TestValue810235102";

            // Act
            _testClass.NotificationType = testValue;

            // Assert
            Assert.That(_testClass.NotificationType, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetFriendId()
        {
            // Arrange
            var testValue = 1985823962;

            // Act
            _testClass.FriendId = testValue;

            // Assert
            Assert.That(_testClass.FriendId, Is.EqualTo(testValue));
        }
    }
}
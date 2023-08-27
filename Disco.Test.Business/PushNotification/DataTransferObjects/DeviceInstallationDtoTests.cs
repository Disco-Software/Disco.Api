namespace Disco.Test.Business.PushNotification.PushNotifications
{
    using System;
    using System.Collections.Generic;
    using Disco.Business.Interfaces.Dtos.PushNotifications;
    using Microsoft.Azure.NotificationHubs;
    using NUnit.Framework;

    [TestFixture]
    public class DeviceInstallationDtoTests
    {
        private DeviceInstallationDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new DeviceInstallationDto();
        }

        [Test]
        public void CanSetAndGetInstallationId()
        {
            // Arrange
            var testValue = "TestValue791665531";

            // Act
            _testClass.InstallationId = testValue;

            // Assert
            Assert.That(_testClass.InstallationId, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetPlatform()
        {
            // Arrange
            var testValue = new NotificationPlatform?();

            // Act
            _testClass.Platform = testValue;

            // Assert
            Assert.That(_testClass.Platform, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetPlatformDeviceId()
        {
            // Arrange
            var testValue = "TestValue1290477768";

            // Act
            _testClass.PlatformDeviceId = testValue;

            // Assert
            Assert.That(_testClass.PlatformDeviceId, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetPushChannel()
        {
            // Arrange
            var testValue = "TestValue462435689";

            // Act
            _testClass.PushChannel = testValue;

            // Assert
            Assert.That(_testClass.PushChannel, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetTags()
        {
            // Arrange
            var testValue = new[] { "TestValue388880471", "TestValue96294119", "TestValue658294298" };

            // Act
            _testClass.Tags = testValue;

            // Assert
            Assert.That(_testClass.Tags, Is.SameAs(testValue));
        }
    }
}
namespace Disco.Test.Business.PushNotification.PushNotifications
{
    using System;
    using Disco.Business.Interfaces.Dtos.PushNotifications;
    using NUnit.Framework;

    [TestFixture]
    public class PushNotificationBaseDtoTests
    {
        private PushNotificationBaseDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new PushNotificationBaseDto();
        }

        [Test]
        public void CanSetAndGetTitle()
        {
            // Arrange
            var testValue = "TestValue1190105371";

            // Act
            _testClass.Title = testValue;

            // Assert
            Assert.That(_testClass.Title, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetBody()
        {
            // Arrange
            var testValue = "TestValue1836788065";

            // Act
            _testClass.Body = testValue;

            // Assert
            Assert.That(_testClass.Body, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = "TestValue2050346625";

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.That(_testClass.Id, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetTags()
        {
            // Arrange
            var testValue = new[] { "TestValue1743848872", "TestValue1648889045", "TestValue982902470" };

            // Act
            _testClass.Tags = testValue;

            // Assert
            Assert.That(_testClass.Tags, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetSilent()
        {
            // Arrange
            var testValue = false;

            // Act
            _testClass.Silent = testValue;

            // Assert
            Assert.That(_testClass.Silent, Is.EqualTo(testValue));
        }
    }
}
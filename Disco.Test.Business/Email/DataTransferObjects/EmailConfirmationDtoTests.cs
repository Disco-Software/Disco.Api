namespace Disco.Test.Business.Email.DataTransferObjects
{
    using System;
    using Disco.Business.Interfaces.Dtos.EmailNotifications;
    using NUnit.Framework;

    [TestFixture]
    public class EmailConfirmationDtoTests
    {
        private EmailConfirmationDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new EmailConfirmationDto();
        }

        [Test]
        public void CanSetAndGetToEmail()
        {
            // Arrange
            var testValue = "TestValue1685773641";

            // Act
            _testClass.ToEmail = testValue;

            // Assert
            Assert.That(_testClass.ToEmail, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue1415747148";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.That(_testClass.Name, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetMessageHeader()
        {
            // Arrange
            var testValue = "TestValue1199257699";

            // Act
            _testClass.MessageHeader = testValue;

            // Assert
            Assert.That(_testClass.MessageHeader, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetMessageBody()
        {
            // Arrange
            var testValue = "TestValue423984086";

            // Act
            _testClass.MessageBody = testValue;

            // Assert
            Assert.That(_testClass.MessageBody, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetIsHtmlTemplate()
        {
            // Arrange
            var testValue = false;

            // Act
            _testClass.IsHtmlTemplate = testValue;

            // Assert
            Assert.That(_testClass.IsHtmlTemplate, Is.EqualTo(testValue));
        }
    }
}
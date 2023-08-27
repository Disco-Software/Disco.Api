namespace Disco.Test.Domain.Models
{
    using System;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class ConnectionTests
    {
        private Connection _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new Connection();
        }

        [Test]
        public void CanSetAndGetUserAgent()
        {
            // Arrange
            var testValue = "TestValue1307769479";

            // Act
            _testClass.UserAgent = testValue;

            // Assert
            Assert.That(_testClass.UserAgent, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetIsConnected()
        {
            // Arrange
            var testValue = false;

            // Act
            _testClass.IsConnected = testValue;

            // Assert
            Assert.That(_testClass.IsConnected, Is.EqualTo(testValue));
        }
    }
}
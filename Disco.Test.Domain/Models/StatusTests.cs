namespace Disco.Test.Domain.Models
{
    using System;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class StatusTests
    {
        private Status _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new Status();
        }

        [Test]
        public void CanSetAndGetLastStatus()
        {
            // Arrange
            var testValue = "TestValue1983891293";

            // Act
            _testClass.LastStatus = testValue;

            // Assert
            Assert.That(_testClass.LastStatus, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetFollowersCount()
        {
            // Arrange
            var testValue = 1160518806;

            // Act
            _testClass.FollowersCount = testValue;

            // Assert
            Assert.That(_testClass.FollowersCount, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetNextStatusId()
        {
            // Arrange
            var testValue = 1417704658;

            // Act
            _testClass.NextStatusId = testValue;

            // Assert
            Assert.That(_testClass.NextStatusId, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetUserTarget()
        {
            // Arrange
            var testValue = 112754422;

            // Act
            _testClass.UserTarget = testValue;

            // Assert
            Assert.That(_testClass.UserTarget, Is.EqualTo(testValue));
        }
    }
}
namespace Disco.Test.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class GroupTests
    {
        private Group _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new Group();
        }

        [Test]
        public void CanSetAndGetName()
        {
            // Arrange
            var testValue = "TestValue154643051";

            // Act
            _testClass.Name = testValue;

            // Assert
            Assert.That(_testClass.Name, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetMessages()
        {
            // Arrange
            var testValue = new List<Message>();

            // Act
            _testClass.Messages = testValue;

            // Assert
            Assert.That(_testClass.Messages, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetAccountGroups()
        {
            // Arrange
            var testValue = new List<AccountGroup>();

            // Act
            _testClass.AccountGroups = testValue;

            // Assert
            Assert.That(_testClass.AccountGroups, Is.SameAs(testValue));
        }
    }
}
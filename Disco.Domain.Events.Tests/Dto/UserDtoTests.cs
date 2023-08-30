namespace Disco.Domain.Events.Test.Dto
{
    using System;
    using Disco.Domain.Events.Dto;
    using NUnit.Framework;

    [TestFixture]
    public class UserDtoTests
    {
        private UserDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new UserDto();
        }

        [Test]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 1603500764;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.That(_testClass.Id, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetUserName()
        {
            // Arrange
            var testValue = "TestValue925926073";

            // Act
            _testClass.UserName = testValue;

            // Assert
            Assert.That(_testClass.UserName, Is.EqualTo(testValue));
        }
    }
}
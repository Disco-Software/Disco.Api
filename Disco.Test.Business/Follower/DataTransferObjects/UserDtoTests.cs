namespace Disco.Test.Business.Follower.DataTransferObjects
{
    using System;
    using Disco.Business.Interfaces.Dtos.Friends;
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
            var testValue = 681464272;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.That(_testClass.Id, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetUserName()
        {
            // Arrange
            var testValue = "TestValue727848183";

            // Act
            _testClass.UserName = testValue;

            // Assert
            Assert.That(_testClass.UserName, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue639369493";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.That(_testClass.Email, Is.EqualTo(testValue));
        }
    }
}
namespace Disco.Domain.Events.Test.Dto
{
    using System;
    using System.Collections.Generic;
    using Disco.Domain.Events.Dto;
    using NUnit.Framework;

    [TestFixture]
    public class AccountDtoTests
    {
        private AccountDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new AccountDto();
        }

        [Test]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = 1011637064;

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.That(_testClass.Id, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetPhoto()
        {
            // Arrange
            var testValue = "TestValue1429597743";

            // Act
            _testClass.Photo = testValue;

            // Assert
            Assert.That(_testClass.Photo, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetUserFollowerDtos()
        {
            // Arrange
            var testValue = new List<UserFollowerDto>();

            // Act
            _testClass.UserFollowerDtos = testValue;

            // Assert
            Assert.That(_testClass.UserFollowerDtos, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetUserFollowingDtos()
        {
            // Arrange
            var testValue = new List<UserFollowerDto>();

            // Act
            _testClass.UserFollowingDtos = testValue;

            // Assert
            Assert.That(_testClass.UserFollowingDtos, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetUserDto()
        {
            // Arrange
            var testValue = new UserDto
            {
                Id = 1143944224,
                UserName = "TestValue188475205"
            };

            // Act
            _testClass.UserDto = testValue;

            // Assert
            Assert.That(_testClass.UserDto, Is.SameAs(testValue));
        }
    }
}
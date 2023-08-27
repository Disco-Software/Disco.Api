namespace Disco.Test.Business.Analytic.DataTransferObjects
{
    using System;
    using System.Collections.Generic;
    using Disco.Business.Interfaces.Dtos.Analytic;
    using Disco.Domain.Models.Models;
    using NUnit.Framework;

    [TestFixture]
    public class AnalyticDtoTests
    {
        private AnalyticDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new AnalyticDto();
        }

        [Test]
        public void CanSetAndGetUsersCount()
        {
            // Arrange
            var testValue = 131121278;

            // Act
            _testClass.UsersCount = testValue;

            // Assert
            Assert.That(_testClass.UsersCount, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetNewUsersCount()
        {
            // Arrange
            var testValue = 1470223116;

            // Act
            _testClass.NewUsersCount = testValue;

            // Assert
            Assert.That(_testClass.NewUsersCount, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetPostsCount()
        {
            // Arrange
            var testValue = 643746156;

            // Act
            _testClass.PostsCount = testValue;

            // Assert
            Assert.That(_testClass.PostsCount, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetUsers()
        {
            // Arrange
            var testValue = new List<User>();

            // Act
            _testClass.Users = testValue;

            // Assert
            Assert.That(_testClass.Users, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetRegisteredUsers()
        {
            // Arrange
            var testValue = new List<User>();

            // Act
            _testClass.RegisteredUsers = testValue;

            // Assert
            Assert.That(_testClass.RegisteredUsers, Is.SameAs(testValue));
        }

        [Test]
        public void CanSetAndGetPosts()
        {
            // Arrange
            var testValue = new List<Post>();

            // Act
            _testClass.Posts = testValue;

            // Assert
            Assert.That(_testClass.Posts, Is.SameAs(testValue));
        }
    }
}
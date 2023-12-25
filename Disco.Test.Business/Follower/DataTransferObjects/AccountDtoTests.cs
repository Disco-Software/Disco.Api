//namespace Disco.Test.Business.Follower.DataTransferObjects
//{
//    using System;
//    using Disco.Business.Interfaces.Dtos.Friends;
//    using NUnit.Framework;

//    [TestFixture]
//    public class AccountDtoTests
//    {
//        private AccountDto _testClass;

//        [SetUp]
//        public void SetUp()
//        {
//            _testClass = new AccountDto();
//        }

//        [Test]
//        public void CanSetAndGetId()
//        {
//            // Arrange
//            var testValue = 853913968;

//            // Act
//            _testClass.Id = testValue;

//            // Assert
//            Assert.That(_testClass.Id, Is.EqualTo(testValue));
//        }

//        [Test]
//        public void CanSetAndGetStatus()
//        {
//            // Arrange
//            var testValue = "TestValue117194607";

//            // Act
//            _testClass.Status = testValue;

//            // Assert
//            Assert.That(_testClass.Status, Is.EqualTo(testValue));
//        }

//        [Test]
//        public void CanSetAndGetFriends()
//        {
//            // Arrange
//            var testValue = 606172824;

//            // Act
//            _testClass.Friends = testValue;

//            // Assert
//            Assert.That(_testClass.Friends, Is.EqualTo(testValue));
//        }

//        [Test]
//        public void CanSetAndGetPosts()
//        {
//            // Arrange
//            var testValue = 1856693354;

//            // Act
//            _testClass.Posts = testValue;

//            // Assert
//            Assert.That(_testClass.Posts, Is.EqualTo(testValue));
//        }

//        [Test]
//        public void CanSetAndGetUserId()
//        {
//            // Arrange
//            var testValue = 1256267923;

//            // Act
//            _testClass.UserId = testValue;

//            // Assert
//            Assert.That(_testClass.UserId, Is.EqualTo(testValue));
//        }

//        [Test]
//        public void CanSetAndGetUserModel()
//        {
//            // Arrange
//            var testValue = new UserDto
//            {
//                Id = 2025131172,
//                UserName = "TestValue1839981550",
//                Email = "TestValue1779993356"
//            };

//            // Act
//            _testClass.UserModel = testValue;

//            // Assert
//            Assert.That(_testClass.UserModel, Is.SameAs(testValue));
//        }
//    }
//}
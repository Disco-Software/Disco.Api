//namespace Disco.Test.Business.Follower.DataTransferObjects
//{
//    using System;
//    using Disco.Business.Interfaces.Dtos.Friends;
//    using NUnit.Framework;

//    [TestFixture]
//    public class GetFollowersDtoTests
//    {
//        private GetFollowingRequestDto _testClass;

//        [SetUp]
//        public void SetUp()
//        {
//            _testClass = new GetFollowingRequestDto();
//        }

//        [Test]
//        public void CanSetAndGetUserId()
//        {
//            // Arrange
//            var testValue = 1357862196;

//            // Act
//            _testClass.UserId = testValue;

//            // Assert
//            Assert.That(_testClass.UserId, Is.EqualTo(testValue));
//        }

//        [Test]
//        public void CanSetAndGetPageNumber()
//        {
//            // Arrange
//            var testValue = 866429099;

//            // Act
//            _testClass.PageNumber = testValue;

//            // Assert
//            Assert.That(_testClass.PageNumber, Is.EqualTo(testValue));
//        }

//        [Test]
//        public void CanSetAndGetPageSize()
//        {
//            // Arrange
//            var testValue = 2135754274;

//            // Act
//            _testClass.PageSize = testValue;

//            // Assert
//            Assert.That(_testClass.PageSize, Is.EqualTo(testValue));
//        }
//    }
//}
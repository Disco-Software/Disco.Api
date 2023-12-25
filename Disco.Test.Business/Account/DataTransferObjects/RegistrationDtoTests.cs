//namespace Disco.Test.Business.Account.DataTransferObjects
//{
//    using System;
//    using Disco.Business.Interfaces.Dtos.Account;
//    using NUnit.Framework;

//    [TestFixture]
//    public class RegistrationDtoTests
//    {
//        private RegistrationDto _testClass;

//        [SetUp]
//        public void SetUp()
//        {
//            _testClass = new RegistrationDto();
//        }

//        [Test]
//        public void CanSetAndGetUserName()
//        {
//            // Arrange
//            var testValue = "TestValue450001184";

//            // Act
//            _testClass.UserName = testValue;

//            // Assert
//            Assert.That(_testClass.UserName, Is.EqualTo(testValue));
//        }

//        //[Test]
//        public void CanSetAndGetEmail()
//        {
//            // Arrange
//            var testValue = "TestValue2122639250";

//            // Act
//            _testClass.Email = testValue;

//            // Assert
//            Assert.That(_testClass.Email, Is.EqualTo(testValue));
//        }

//        [Test]
//        public void CanSetAndGetPassword()
//        {
//            // Arrange
//            var testValue = "TestValue840306089";

//            // Act
//            _testClass.Password = testValue;

//            // Assert
//            Assert.That(_testClass.Password, Is.EqualTo(testValue));
//        }

//        [Test]
//        public void CanSetAndGetConfirmPassword()
//        {
//            // Arrange
//            var testValue = "TestValue1141760272";

//            // Act
//            _testClass.ConfirmPassword = testValue;

//            // Assert
//            Assert.That(_testClass.ConfirmPassword, Is.EqualTo(testValue));
//        }
//    }
//}
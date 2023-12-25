namespace Disco.Test.Business.Account.DataTransferObjects
{
    using System;
    using Disco.Business.Interfaces.Dtos.AccountPassword.Admin.ResetPassword;
    using NUnit.Framework;

    [TestFixture]
    public class ResetPasswordDtoTests
    {
        private ResetPasswordDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new ResetPasswordDto();
        }

        [Test]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue634007761";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.That(_testClass.Email, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetConfirmationToken()
        {
            // Arrange
            var testValue = "TestValue1843663914";

            // Act
            _testClass.ConfirmationToken = testValue;

            // Assert
            Assert.That(_testClass.ConfirmationToken, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetPassword()
        {
            // Arrange
            var testValue = "TestValue1358845985";

            // Act
            _testClass.Password = testValue;

            // Assert
            Assert.That(_testClass.Password, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetConfirmPassword()
        {
            // Arrange
            var testValue = "TestValue1509224813";

            // Act
            _testClass.ConfirmPassword = testValue;

            // Assert
            Assert.That(_testClass.ConfirmPassword, Is.EqualTo(testValue));
        }
    }
}
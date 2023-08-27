namespace Disco.Test.Business.Account.DataTransferObjects
{
    using System;
    using Disco.Business.Interfaces.Dtos.Account;
    using NUnit.Framework;

    [TestFixture]
    public class ForgotPasswordDtoTests
    {
        private ForgotPasswordDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new ForgotPasswordDto();
        }

        [Test]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var testValue = "TestValue1708285460";

            // Act
            _testClass.Email = testValue;

            // Assert
            Assert.That(_testClass.Email, Is.EqualTo(testValue));
        }
    }
}
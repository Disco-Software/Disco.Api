namespace Disco.Test.Business.Account.DataTransferObjects
{
    using System;
    using Disco.Business.Interfaces.Dtos.Account;
    using NUnit.Framework;

    [TestFixture]
    public class RefreshTokenDtoTests
    {
        private RefreshTokenDto _testClass;

        [SetUp]
        public void SetUp()
        {
            _testClass = new RefreshTokenDto();
        }

        [Test]
        public void CanSetAndGetRefreshToken()
        {
            // Arrange
            var testValue = "TestValue284150481";

            // Act
            _testClass.RefreshToken = testValue;

            // Assert
            Assert.That(_testClass.RefreshToken, Is.EqualTo(testValue));
        }

        [Test]
        public void CanSetAndGetAccessToken()
        {
            // Arrange
            var testValue = "TestValue852475019";

            // Act
            _testClass.AccessToken = testValue;

            // Assert
            Assert.That(_testClass.AccessToken, Is.EqualTo(testValue));
        }
    }
}
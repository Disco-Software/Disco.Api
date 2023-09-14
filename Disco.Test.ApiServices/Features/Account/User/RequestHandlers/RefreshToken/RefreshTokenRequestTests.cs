namespace Disco.Test.Business.Features.Account.User.RequestHandlers.RefreshToken
{
    using System;
    using Disco.ApiServices.Features.Account.User.RequestHandlers.RefreshToken;
    using Disco.Business.Interfaces.Dtos.Account;
    using NUnit.Framework;

    [TestFixture]
    public class RefreshTokenRequestTests
    {
        private RefreshTokenRequest _testClass;
        private RefreshTokenDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new RefreshTokenDto
            {
                RefreshToken = "TestValue350034320",
                AccessToken = "TestValue1987216070"
            };
            _testClass = new RefreshTokenRequest(_dto);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new RefreshTokenRequest(_dto);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void DtoIsInitializedCorrectly()
        {
            Assert.That(_testClass.Dto, Is.SameAs(_dto));
        }
    }
}
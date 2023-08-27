namespace Disco.Test.ApiServices.Features.AccountPassword.Admin.RequestHandlers.ForgotPassword
{
    using System;
    using Disco.ApiServices.Features.AccountPassword.Admin.RequestHandlers.ForgotPassword;
    using Disco.Business.Interfaces.Dtos.Account;
    using NUnit.Framework;

    [TestFixture]
    public class ForgotPasswordRequestTests
    {
        private ForgotPasswordRequest _testClass;
        private ForgotPasswordDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new ForgotPasswordDto { Email = "TestValue2142264299" };
            _testClass = new ForgotPasswordRequest(_dto);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new ForgotPasswordRequest(_dto);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullDto()
        {
            Assert.Throws<ArgumentNullException>(() => new ForgotPasswordRequest(default(ForgotPasswordDto)));
        }

        [Test]
        public void DtoIsInitializedCorrectly()
        {
            Assert.That(_testClass.Dto, Is.SameAs(_dto));
        }
    }
}
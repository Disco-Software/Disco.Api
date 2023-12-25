namespace Disco.Test.ApiServices.Features.AccountPassword.User.RequestHandlers.ForgotPassword
{
    using System;
    using Disco.ApiServices.Features.AccountPassword.User.RequestHandlers.ForgotPassword;
    using Disco.Business.Interfaces.Dtos.AccountPassword.Admin.ForgotPassword;
    using NUnit.Framework;

    [TestFixture]
    public class ForgotPasswordRequestTests
    {
        private ForgotPasswordRequest _testClass;
        private ForgotPasswordDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new ForgotPasswordDto { Email = "TestValue708807531" };
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
        public void DtoIsInitializedCorrectly()
        {
            Assert.That(_testClass.Dto, Is.SameAs(_dto));
        }
    }
}
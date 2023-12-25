namespace Disco.Test.ApiServices.Features.AccountPassword.User.RequestHandlers.ResetPassword
{
    using System;
    using Disco.ApiServices.Features.AccountPassword.User.RequestHandlers.ResetPassword;
    using Disco.Business.Interfaces.Dtos.AccountPassword.Admin.ResetPassword;
    using NUnit.Framework;

    [TestFixture]
    public class ResetPasswordRequestTests
    {
        private ResetPasswordRequest _testClass;
        private ResetPasswordDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new ResetPasswordDto
            {
                Email = "TestValue810920675",
                ConfirmationToken = "TestValue679363365",
                Password = "TestValue1766417390",
                ConfirmPassword = "TestValue1430201292"
            };
            _testClass = new ResetPasswordRequest(_dto);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new ResetPasswordRequest(_dto);

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
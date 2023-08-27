namespace Disco.Test.ApiServices.Features.AccountPassword.Admin.RequestHandlers.ResetPassword
{
    using System;
    using Disco.ApiServices.Features.AccountPassword.Admin.RequestHandlers.ResetPassword;
    using Disco.Business.Interfaces.Dtos.Account;
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
                Email = "TestValue1935859909",
                ConfirmationToken = "TestValue869278164",
                Password = "TestValue1428562483",
                ConfirmPassword = "TestValue1458450964"
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
        public void CannotConstructWithNullDto()
        {
            Assert.Throws<ArgumentNullException>(() => new ResetPasswordRequest(default(ResetPasswordDto)));
        }

        [Test]
        public void DtoIsInitializedCorrectly()
        {
            Assert.That(_testClass.Dto, Is.SameAs(_dto));
        }
    }
}
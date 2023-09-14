namespace Disco.Test.ApiServices.Features.AccountDetails.User.RequestHandlers.ChangePhoto
{
    using System;
    using Disco.ApiServices.Features.AccountDetails.User.RequestHandlers.ChangePhoto;
    using Disco.Business.Interfaces.Dtos.AccountDetails;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class ChangePhotoRequestTests
    {
        private ChangePhotoRequest _testClass;
        private UpdateAccountDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new UpdateAccountDto { Photo = Substitute.For<IFormFile>() };
            _testClass = new ChangePhotoRequest(_dto);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new ChangePhotoRequest(_dto);

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
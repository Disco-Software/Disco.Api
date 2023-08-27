namespace Disco.Test.Business.Features.Account.User.RequestHandlers.Facebook
{
    using System;
    using Disco.ApiServices.Features.Account.User.RequestHandlers.Facebook;
    using Disco.Integration.Interfaces.Dtos.Facebook;
    using NUnit.Framework;

    [TestFixture]
    public class FacebookRequestTests
    {
        private FacebookRequest _testClass;
        private FacebookRequestDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new FacebookRequestDto { AccessToken = "TestValue1383662621" };
            _testClass = new FacebookRequest(_dto);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new FacebookRequest(_dto);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullDto()
        {
            Assert.Throws<ArgumentNullException>(() => new FacebookRequest(default(FacebookRequestDto)));
        }

        [Test]
        public void DtoIsInitializedCorrectly()
        {
            Assert.That(_testClass.Dto, Is.SameAs(_dto));
        }
    }
}
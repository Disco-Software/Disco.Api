namespace Disco.Test.Business.Features.Account.User.RequestHandlers.Google
{
    using System;
    using Disco.ApiServices.Features.Account.User.RequestHandlers.Google;
    using Disco.Business.Interfaces.Dtos.Google;
    using NUnit.Framework;

    [TestFixture]
    public class GoogleRequestTests
    {
        private GoogleRequest _testClass;
        private GoogleLogInDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new GoogleLogInDto
            {
                Email = "TestValue1586794264",
                UserName = "TestValue2045234360",
                Photo = "TestValue1960302958",
                Id = "TestValue334801877",
                IdToken = "TestValue524597721",
                ServerAuthCode = "TestValue1435713408"
            };
            _testClass = new GoogleRequest(_dto);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GoogleRequest(_dto);

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
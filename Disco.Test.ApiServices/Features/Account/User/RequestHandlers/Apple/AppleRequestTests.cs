namespace Disco.Test.Business.Features.Account.User.RequestHandlers.Apple
{
    using System;
    using Disco.ApiServices.Features.Account.User.RequestHandlers.Apple;
    using Disco.Business.Interfaces.Dtos.Apple;
    using NUnit.Framework;

    [TestFixture]
    public class AppleRequestTests
    {
        private AppleRequest _testClass;
        private AppleLogInDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new AppleLogInDto
            {
                Name = "TestValue154704279",
                Email = "TestValue941852601",
                AppleId = "TestValue1560057675",
                AppleIdCode = "TestValue1556662403"
            };
            _testClass = new AppleRequest(_dto);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new AppleRequest(_dto);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullDto()
        {
            Assert.Throws<ArgumentNullException>(() => new AppleRequest(default(AppleLogInDto)));
        }

        [Test]
        public void DtoIsInitializedCorrectly()
        {
            Assert.That(_testClass.Dto, Is.SameAs(_dto));
        }
    }
}
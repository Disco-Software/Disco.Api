namespace Disco.Test.ApiServices.Features.Account.Admin.RequestHandlers.LogIn
{
    using System;
    using Disco.ApiServices.Features.Account.Admin.RequestHandlers.LogIn;
    using Disco.Business.Interfaces.Dtos.Account;
    using Disco.Business.Interfaces.Dtos.Account.Admin.LogIn;
    using NUnit.Framework;

    [TestFixture]
    public class LogInRequestTests
    {
        private LogInRequest _testClass;
        private LogInRequestDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new LogInRequestDto("TestValue465385208", "TestValue1182258186");
         
            _testClass = new LogInRequest(_dto);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new LogInRequest(_dto);

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
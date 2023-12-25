//namespace Disco.Test.ApiServices.Features.AccountDetails.Admin.RequestHandlers.CreateAccount
//{
//    using System;
//    using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.CreateAccount;
//    using Disco.Business.Interfaces.Dtos.Account;
//    using NUnit.Framework;

//    [TestFixture]
//    public class CreateAccountRequestTests
//    {
//        private CreateAccountRequest _testClass;
//        private RegistrationDto _dto;

//        [SetUp]
//        public void SetUp()
//        {
//            _dto = new RegistrationDto
//            {
//                UserName = "TestValue1213461523",
//                Email = "TestValue19208073",
//                Password = "TestValue1113518171",
//                ConfirmPassword = "TestValue268883573"
//            };
//            _testClass = new CreateAccountRequest(_dto);
//        }

//        [Test]
//        public void CanConstruct()
//        {
//            // Act
//            var instance = new CreateAccountRequest(_dto);

//            // Assert
//            Assert.That(instance, Is.Not.Null);
//        }

//        [Test]
//        public void DtoIsInitializedCorrectly()
//        {
//            Assert.That(_testClass.Dto, Is.SameAs(_dto));
//        }
//    }
//}
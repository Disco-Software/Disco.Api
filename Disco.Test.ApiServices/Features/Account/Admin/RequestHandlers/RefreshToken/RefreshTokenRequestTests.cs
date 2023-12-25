//namespace Disco.Test.ApiServices.Features.Account.Admin.RequestHandlers.RefreshToken
//{
//    using System;
//    using Disco.ApiServices.Features.Account.Admin.RequestHandlers.RefreshToken;
//    using Disco.Business.Interfaces.Dtos.Account;
//    using NUnit.Framework;

//    [TestFixture]
//    public class RefreshTokenRequestTests
//    {
//        private RefreshTokenRequest _testClass;
//        private RefreshTokenDto _dto;

//        [SetUp]
//        public void SetUp()
//        {
//            _dto = new RefreshTokenDto
//            {
//                RefreshToken = "TestValue204688091",
//                AccessToken = "TestValue1327825205"
//            };
//            _testClass = new RefreshTokenRequest(_dto);
//        }

//        [Test]
//        public void CanConstruct()
//        {
//            // Act
//            var instance = new RefreshTokenRequest(_dto);

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
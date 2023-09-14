namespace Disco.ApiServices.Test.Features.Role.RequestHandlers.GetRoles
{
    using System;
    using Disco.ApiServices.Features.Role.RequestHandlers.GetRoles;
    using Disco.Business.Interfaces.Dtos.Roles;
    using NUnit.Framework;

    [TestFixture]
    public class GetRolesRequestTests
    {
        private GetRolesRequest _testClass;
        private GetAllRolesDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new GetAllRolesDto
            {
                PageNumber = 1337818905,
                PageSize = 1328242320
            };
            _testClass = new GetRolesRequest(_dto);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetRolesRequest(_dto);

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
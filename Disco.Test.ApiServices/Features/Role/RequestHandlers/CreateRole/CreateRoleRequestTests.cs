namespace Disco.ApiServices.Test.Features.Role.RequestHandlers.CreateRole
{
    using System;
    using Disco.ApiServices.Features.Role.RequestHandlers.CreateRole;
    using Disco.Business.Interfaces.Dtos.Roles;
    using NUnit.Framework;

    [TestFixture]
    public class CreateRoleRequestTests
    {
        private CreateRoleRequest _testClass;
        private CreateRoleDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new CreateRoleDto { RoleName = "TestValue1756187834" };
            _testClass = new CreateRoleRequest(_dto);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new CreateRoleRequest(_dto);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullDto()
        {
            Assert.Throws<ArgumentNullException>(() => new CreateRoleRequest(default(CreateRoleDto)));
        }

        [Test]
        public void DtoIsInitializedCorrectly()
        {
            Assert.That(_testClass.Dto, Is.SameAs(_dto));
        }
    }
}
namespace Disco.ApiServices.Test.Features.Role
{
    using System;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Role;
    using Disco.Business.Interfaces.Dtos.Roles;
    using Disco.Business.Interfaces.Interfaces;
    using MediatR;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class RoleControllerTests
    {
        private RoleController _testClass;
        private IRoleService _roleService;
        private IMediator _mediator;

        [SetUp]
        public void SetUp()
        {
            _roleService = Substitute.For<IRoleService>();
            _mediator = Substitute.For<IMediator>();
            _testClass = new RoleController(_roleService, _mediator);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new RoleController(_roleService, _mediator);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreate()
        {
            // Arrange
            var dto = new CreateRoleDto { RoleName = "TestValue1284655856" };

            // Act
            var result = await _testClass.Create(dto);

            // Assert
            _mediator.Received(1);
        }

        [Test]
        public async Task CanCallGetAllRoles()
        {
            // Arrange
            var dto = new GetAllRolesDto
            {
                PageNumber = 1832070904,
                PageSize = 617700309
            };

            // Act
            var result = await _testClass.GetAllRoles(dto);

            // Assert
            _mediator.Received(1);
        }
    }
}
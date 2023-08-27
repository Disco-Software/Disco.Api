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
        public void CannotConstructWithNullRoleService()
        {
            Assert.Throws<ArgumentNullException>(() => new RoleController(default(IRoleService), _mediator));
        }

        [Test]
        public void CannotConstructWithNullMediator()
        {
            Assert.Throws<ArgumentNullException>(() => new RoleController(_roleService, default(IMediator)));
        }

        [Test]
        public async Task CanCallCreate()
        {
            // Arrange
            var dto = new CreateRoleDto { RoleName = "TestValue1284655856" };

            // Act
            var result = await _testClass.Create(dto);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallCreateWithNullDto()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Create(default(CreateRoleDto)));
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
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallGetAllRolesWithNullDto()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.GetAllRoles(default(GetAllRolesDto)));
        }
    }
}
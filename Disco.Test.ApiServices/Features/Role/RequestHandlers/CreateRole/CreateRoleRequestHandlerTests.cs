namespace Disco.ApiServices.Test.Features.Role.RequestHandlers.CreateRole
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Role.RequestHandlers.CreateRole;
    using Disco.Business.Interfaces.Dtos.Roles;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class CreateRoleRequestHandlerTests
    {
        private CreateRoleRequestHandler _testClass;
        private IRoleService _roleService;

        [SetUp]
        public void SetUp()
        {
            _roleService = Substitute.For<IRoleService>();
            _testClass = new CreateRoleRequestHandler(_roleService);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new CreateRoleRequestHandler(_roleService);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new CreateRoleRequest(new CreateRoleDto { RoleName = "TestValue2078469521" });
            var cancellationToken = CancellationToken.None;

            _roleService.CreateRoleAsync(Arg.Any<CreateRoleDto>()).Returns(new Role());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _roleService.Received().CreateRoleAsync(Arg.Any<CreateRoleDto>());
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(CreateRoleRequest), CancellationToken.None));
        }
    }
}
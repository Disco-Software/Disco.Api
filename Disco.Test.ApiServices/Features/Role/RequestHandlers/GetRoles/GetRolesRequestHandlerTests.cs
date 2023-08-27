namespace Disco.ApiServices.Test.Features.Role.RequestHandlers.GetRoles
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Role.RequestHandlers.GetRoles;
    using Disco.Business.Interfaces.Dtos.Roles;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class GetRolesRequestHandlerTests
    {
        private GetRolesRequestHandler _testClass;
        private IRoleService _roleService;

        [SetUp]
        public void SetUp()
        {
            _roleService = Substitute.For<IRoleService>();
            _testClass = new GetRolesRequestHandler(_roleService);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetRolesRequestHandler(_roleService);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullRoleService()
        {
            Assert.Throws<ArgumentNullException>(() => new GetRolesRequestHandler(default(IRoleService)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new GetRolesRequest(new GetAllRolesDto
            {
                PageNumber = 234784460,
                PageSize = 265297804
            });
            var cancellationToken = CancellationToken.None;

            _roleService.GetAllRoles(Arg.Any<GetAllRolesDto>()).Returns(new List<Role>());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _roleService.Received().GetAllRoles(Arg.Any<GetAllRolesDto>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(GetRolesRequest), CancellationToken.None));
        }
    }
}
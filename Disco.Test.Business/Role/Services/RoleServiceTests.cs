namespace Disco.Test.Business.Role.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Disco.Business.Interfaces.Dtos.Roles;
    using Disco.Business.Services.Mappers;
    using Disco.Business.Services.Services;
    using Disco.Domain.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class RoleServiceTests
    {
        private RoleService _testClass;
        private Mock<RoleManager<Role>> _roleManager;
        private Mock<IRoleRepository> _roleRepository;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _roleManager = GetRoleManagerMock();
            _roleRepository = new Mock<IRoleRepository>();

            _mapper = new MapperConfiguration(x => x.AddProfile(new RoleMapProfile()))
                .CreateMapper();

            _testClass = new RoleService(_roleManager.Object, _roleRepository.Object, _mapper);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new RoleService(_roleManager.Object, _roleRepository.Object, _mapper);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreateRoleAsync()
        {
            // Arrange
            var dto = new CreateRoleDto { RoleName = "TestValue424075196" };


            // Act
            var result = await _testClass.CreateRoleAsync(dto);

            // Assert
            _roleManager.Verify((x) => x.CreateAsync(It.IsAny<Role>()), Times.Once());
        }

        [Test]
        public void CannotCallCreateRoleAsyncWithNullDto()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.CreateRoleAsync(default));
        }

        [Test]
        public async Task CanCallRemoveRoleAsync()
        {
            // Arrange
            var name = "TestValue1108342121";

            // Act
            await _testClass.RemoveRoleAsync(name);

            // Assert
            _roleManager.Verify((x) => x.DeleteAsync(It.IsAny<Role>()));
        }

        [Test]
        public async Task CanCallGetAllRoles()
        {
            // Arrange
            var dto = new GetAllRolesDto
            {
                PageNumber = 1672684959,
                PageSize = 1392764442
            };

            _roleRepository.Setup(mock => mock.GetAll(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new List<Role>());

            // Act
            var result = await _testClass.GetAllRoles(dto);

            // Assert
            _roleRepository.Verify(mock => mock.GetAll(It.IsAny<int>(), It.IsAny<int>()));
        }

        [Test]
        public void CannotCallGetAllRolesWithNullDto()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.GetAllRoles(default));
        }

        private Mock<RoleManager<Role>> GetRoleManagerMock()
        {
            var roleStore = new Mock<IRoleStore<Role>>();
            var roleValidators = new List<RoleValidator<Role>>
            {
                new RoleValidator<Role>()
            };
            var lookupNomailzer = new Mock<ILookupNormalizer>();
            var identityErrorDescriptor = new Mock<IdentityErrorDescriber>();
            var logger = new Mock<ILogger<RoleManager<Role>>>();

            var roleManager = new Mock<RoleManager<Role>>(
                roleStore.Object,
                roleValidators,
                lookupNomailzer.Object,
                identityErrorDescriptor.Object,
                logger.Object);

            roleManager.Setup(x => x.CreateAsync(It.IsAny<Role>()))
                .ReturnsAsync(IdentityResult.Success);
            roleManager.Setup(x => x.DeleteAsync(It.IsAny<Role>()))
                .ReturnsAsync(IdentityResult.Success);
            roleManager.Setup(x => x.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(new Role
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });

            return roleManager;
        }
    }
}
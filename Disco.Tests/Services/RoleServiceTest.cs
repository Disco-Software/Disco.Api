using Disco.Business.Interfaces.Dtos.Roles;
using Disco.Business.Services.Services;
using Disco.Domain.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Tests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Tests.Services
{
    [TestClass]
    public class RoleServiceTest
    {
        [TestMethod]
        public async Task CreateAsync_ReturnsSuccessResponse()
        {
            var roles = new List<Role>()
            {
                new Role() { Id = 1, Name = "Admin"},
                new Role() {Id = 2, Name = "User"},
            };

            var dto = new CreateRoleDto
            {
                RoleName = "Manager"
            };

            var mockedRoleManager = MockedRoleManager.MockRoleManager<Role>(roles);
            var mapper = MockedAutoMapper.MockAutoMapper();

            var roleService = new RoleService(mockedRoleManager.Object, null, mapper);
            var response = await roleService.CreateRoleAsync(dto);

            Assert.AreEqual(roles.Count, 3);
        }

        [TestMethod]
        public async Task DeleteAsync_ReturnsSuccessResponse()
        {
            var roles = new List<Role>()
            {
                new Role() { Id = 1, Name = "Admin"},
                new Role() {Id = 2, Name = "User"},
                new Role() {Id = 3, Name = "Manager"},
            };

            var mockedRoleManager = MockedRoleManager.MockRoleManager<Role>(roles);
            mockedRoleManager.Setup(roleManager => roleManager.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(roles.LastOrDefault());
            
            var mapper = MockedAutoMapper.MockAutoMapper();

            var roleService = new RoleService(mockedRoleManager.Object, null, mapper);
            var response = roleService.RemoveRoleAsync("Manager");

            Assert.AreEqual(roles.Count, 2);

        }

        [TestMethod]
        public async Task GetAllRole_ReturnsListResponse()
        {
            var roles = new List<Role>()
            {
                new Role() { Id = 1, Name = "Admin"},
                new Role() {Id = 2, Name = "User"},
                new Role() {Id = 3, Name = "Manager"},
            };

            var dto = new GetAllRolesDto
            {
                PageNumber = 1,
                PageSize = 3,
            };

            var mockedRoleRepository = new Mock<IRoleRepository>();
            mockedRoleRepository.Setup(roleRepository => roleRepository.GetAll(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(roles);

            var roleService = new RoleService(null, mockedRoleRepository.Object, null);
            var response = await roleService.GetAllRoles(dto);

            Assert.AreEqual(response.Count, 3);

        }
    }
}

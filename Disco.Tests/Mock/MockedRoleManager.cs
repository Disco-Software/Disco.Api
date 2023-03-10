using Disco.Domain.Models.Models;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Tests.Mock
{
    public class MockedRoleManager
    {
        public static Mock<RoleManager<TRole>> MockRoleManager<TRole>(List<TRole> roles) where TRole : IdentityRole<int>
        {
            var mockedRoleStore = new Mock<IRoleStore<TRole>>();

            var mockedRoleManager = new Mock<RoleManager<TRole>>(mockedRoleStore.Object, null, null, null, null);
            mockedRoleManager.Object.RoleValidators.Add(new RoleValidator<TRole>());

            mockedRoleManager.Setup(roleManager => roleManager.CreateAsync(It.IsAny<TRole>()))
                .ReturnsAsync(IdentityResult.Success)
                .Callback<TRole>((x) => roles.Add(x));
            mockedRoleManager.Setup(roleManager => roleManager.DeleteAsync(It.IsAny<TRole>()))
                .ReturnsAsync(IdentityResult.Success)
                .Callback<TRole>((x) => roles.Remove(x));
            mockedRoleManager.Setup(roleManager => roleManager.UpdateAsync(It.IsAny<TRole>()))
                .ReturnsAsync(IdentityResult.Success);

            return mockedRoleManager;
        }
    }
}

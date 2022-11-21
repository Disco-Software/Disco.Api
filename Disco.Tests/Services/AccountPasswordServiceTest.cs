using Disco.Business.Services;
using Disco.Domain.Models;
using Disco.Tests.Mock;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Tests.Services
{
    [TestClass]
    public class AccountPasswordServiceTest
    {
        [TestMethod]
        public async Task ChangePasswordAsync_ReturnsSuccessResponse()
        {
            var list = new List<User>();

            var user = new User { Id = 1, UserName = "vasya_pupkin", Email = "vasya.pupkin@gmail.com", Account = new Account { Followers = new List<UserFollower>() } };

            var mockedUserManager = MockedUserManager.MockUserManager(list);
            mockedUserManager.Setup(u => u.ResetPasswordAsync(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(It.IsAny<IdentityResult>());
            mockedUserManager.Setup(u => u.GeneratePasswordResetTokenAsync(It.IsAny<User>()))
                .ReturnsAsync("lusha_token");

            var accountPasswordService = new AccountPasswordService(mockedUserManager.Object);
            var passwordResetToken = await mockedUserManager.Object.GeneratePasswordResetTokenAsync(user);
            var response = accountPasswordService.ChengePasswordAsync(user, passwordResetToken, "StasZeus2021!");

            Assert.IsTrue(response.IsCompletedSuccessfully);
        }
    }
}

using Disco.Business.Interfaces;
using Disco.Business.Services;
using Disco.Business.Services.Services;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
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
        public async Task ChangePasswordAsync_ReturnsTrueResponse()
        {
            var list = new List<User>();

            var user = new User { Id = 1, UserName = "vasya_pupkin", Email = "vasya.pupkin@gmail.com", Account = new Account { Followers = new List<UserFollower>() } };

            var mockedUserManager = MockedUserManager.MockUserManager(list);
            mockedUserManager.Setup(u => u.ResetPasswordAsync(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            mockedUserManager.Setup(u => u.GeneratePasswordResetTokenAsync(It.IsAny<User>()))
                .ReturnsAsync(It.IsAny<string>());

            var accountPasswordService = new AccountPasswordService(mockedUserManager.Object);
            var response = accountPasswordService.ChengePasswordAsync(user, Guid.NewGuid().ToString(), "StasZeus2021!");

            Assert.IsTrue(response.IsCompletedSuccessfully);
        }
        [TestMethod]
        public async Task ChangePasswordAsync_ReturnsFalseResponse()
        {
            var list = new List<User>();

            var user = new User { Id = 1, UserName = "vasya_pupkin", Email = "vasya.pupkin@gmail.com", Account = new Account { Followers = new List<UserFollower>() } };

            var mockedUserManager = MockedUserManager.MockUserManager(list);
            mockedUserManager.Setup(u => u.ResetPasswordAsync(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed());
            mockedUserManager.Setup(u => u.GeneratePasswordResetTokenAsync(It.IsAny<User>()))
                .ReturnsAsync(It.IsAny<string>());

            var accountPasswordService = new AccountPasswordService(mockedUserManager.Object);
            var response = accountPasswordService.ChengePasswordAsync(user, Guid.NewGuid().ToString(), "StasZeus2021!");

            Assert.IsFalse(response.IsCompletedSuccessfully);
            Assert.IsTrue(response.IsFaulted);
        }

        [TestMethod]
        public async Task VarifyPasswordAsync_ReturnsTrueResponse()
        {
            var user = new User { Id = 1, UserName = "vasya_pupkin", Email = "vasya.pupkin@gmail.com", PasswordHash= Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString())), Account = new Account { Followers = new List<UserFollower>() } };

            var mockedUserManager = MockedUserManager.MockUserManager(new List<User>() { user });
            mockedUserManager.Setup(m => m.PasswordHasher.VerifyHashedPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(PasswordVerificationResult.Success);

            var accountPasswordService = new AccountPasswordService(mockedUserManager.Object);
            var response = accountPasswordService.VerifyPasswordAsync(user, "54321");

            Assert.IsTrue(response == PasswordVerificationResult.Success);
        }
    }
}

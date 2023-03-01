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
using System.Linq;
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
        public async Task VarifyPasswordAsync_ReturnsSuccessResponse()
        {
            var list = new List<User>
            {
                new User { Id = 1, UserName = "vasya_pupkin", PasswordHash = "827ccb0eea8a706c4c34a16891f84e7b", Email = "vasya.pupkin@gmail.com", Account = new Account { Followers = new List<UserFollower>() } }
            };

            var mockedUserManager = MockedUserManager.MockUserManager(list);

            var mockedPasswordHasher = new Mock<IPasswordHasher<User>>();
            mockedPasswordHasher.Setup(passwordHasher => passwordHasher.VerifyHashedPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(PasswordVerificationResult.Success);

            mockedUserManager.Object.PasswordHasher = mockedPasswordHasher.Object;

            var accountPasswordService = new AccountPasswordService(mockedUserManager.Object);
            var response = await accountPasswordService.VerifyPasswordAsync(list.First(), "12345");

            Assert.AreEqual(response, PasswordVerificationResult.Success);
        }

        [TestMethod]
        public async Task VarifyPasswordAsync_ReturnsFaildResponse()
        {
            var list = new List<User>
            {
                new User { Id = 1, UserName = "vasya_pupkin", PasswordHash = "827ccb0eea8a706c4c34a16891f84e7b", Email = "vasya.pupkin@gmail.com", Account = new Account { Followers = new List<UserFollower>() } }
            };

            var mockedUserManager = MockedUserManager.MockUserManager(list);
            
            var mockedPasswordHasher = new Mock<IPasswordHasher<User>>();
            mockedPasswordHasher.Setup(passwordHasher => passwordHasher.VerifyHashedPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(PasswordVerificationResult.Failed);

            mockedUserManager.Object.PasswordHasher = mockedPasswordHasher.Object;

            var accountPasswordService = new AccountPasswordService(mockedUserManager.Object);
            var response = await accountPasswordService.VerifyPasswordAsync(list.First(), "54321");

            Assert.AreEqual(response, PasswordVerificationResult.Failed);

        }

        [TestMethod]
        public async Task VarifyPasswordAsync_ReturnsSuccessRehashNeededResponse()
        {
            var list = new List<User>
            {
                new User { Id = 1, UserName = "vasya_pupkin", PasswordHash = "827ccb0eea8a706c4c34a16891f84e7b", Email = "vasya.pupkin@gmail.com", Account = new Account { Followers = new List<UserFollower>() } }
            };

            var mockedUserManager = MockedUserManager.MockUserManager(list);

            var mockedPasswordHasher = new Mock<IPasswordHasher<User>>();
            mockedPasswordHasher.Setup(passwordHasher => passwordHasher.VerifyHashedPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(PasswordVerificationResult.SuccessRehashNeeded);

            mockedUserManager.Object.PasswordHasher = mockedPasswordHasher.Object;

            var accountPasswordService = new AccountPasswordService(mockedUserManager.Object);
            var response = await accountPasswordService.VerifyPasswordAsync(list.First(), "12345");

            Assert.AreEqual(response, PasswordVerificationResult.SuccessRehashNeeded);
        }
    }
}

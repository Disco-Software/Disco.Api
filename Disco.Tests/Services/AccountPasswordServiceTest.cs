using Disco.Business.Services;
using Disco.Domain.Models;
using Disco.Tests.Mock;
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
                .ReturnsAsync(new Microsoft.AspNetCore.Identity.IdentityResult());

            var accountPasswordService = new AccountPasswordService(mockedUserManager.Object);
            var response = accountPasswordService.ChengePasswordAsync(user, "kdjfkjdkfjdkjf", "StasZeus2021!");

            Assert.IsTrue(response.IsCompletedSuccessfully);
        }
    }
}

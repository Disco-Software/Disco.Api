using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disco.Tests.Mock
{
    public class MockedUserManager
    {
        public static Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> ls) where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var authOptions = new Mock<AuthenticationOptions>();

            var mockedUserManager = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mockedUserManager.Object.UserValidators.Add(new UserValidator<TUser>());
            mockedUserManager.Object.PasswordValidators.Add(new PasswordValidator<TUser>());
            
            
            var mockedPasswordHasher = new Mock<IPasswordHasher<TUser>>();
            mockedPasswordHasher.Setup(passwordHasher => passwordHasher.VerifyHashedPassword(It.IsAny<TUser>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(PasswordVerificationResult.Success);
            mockedPasswordHasher.Setup(passwordHasher => passwordHasher.VerifyHashedPassword(It.IsAny<TUser>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(PasswordVerificationResult.Failed);
            mockedPasswordHasher.Setup(passwordHasher => passwordHasher.VerifyHashedPassword(It.IsAny<TUser>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(PasswordVerificationResult.SuccessRehashNeeded);

            mockedUserManager.Object.PasswordHasher = mockedPasswordHasher.Object;

            mockedUserManager.Setup(x => x.DeleteAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
            mockedUserManager.Setup(x => x.CreateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success).Callback<TUser>((x) => ls.Add(x));
            mockedUserManager.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);

            return mockedUserManager;
        }
    }
}

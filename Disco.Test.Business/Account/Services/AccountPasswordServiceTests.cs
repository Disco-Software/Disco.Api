namespace Disco.Test.Business.Account.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Disco.Business.Exceptions;
    using Disco.Business.Services.Services;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Moq;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class AccountPasswordServiceTests
    {
        private AccountPasswordService _testClass;
        private Mock<UserManager<User>> _userManager;

        [SetUp]
        public void SetUp()
        {
            _userManager = GetUserManager<User>();
            _testClass = new AccountPasswordService(_userManager.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new AccountPasswordService(_userManager.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallChengePasswordAsync()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue2009279513",
                RefreshToken = "TestValue556655928",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1253792701,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1709719616",
                        FollowersCount = 1959713120,
                        NextStatusId = 1199490237,
                        UserTarget = 1511220862,
                        AccountId = 101691744,
                        Account = default
                    },
                    Cread = "TestValue213830444",
                    Photo = "TestValue85915845",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1881346386,
                    User = default
                }
            };
           
            var token = "TestValue1799923867";
            var newPassword = "TestValue180498334";

            _userManager.Setup(x => x.ResetPasswordAsync(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            await _testClass.ChengePasswordAsync(user, token, newPassword);

            // Assert
            _userManager.Verify(x => x.ResetPasswordAsync(user, It.IsAny<string>(), It.IsAny<string>()));
        }

        [Test]
        public void CannotCallChengePasswordAsyncWithNullUser()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.ChengePasswordAsync(default, "TestValue306304568", "TestValue57238173"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallChengePasswordAsyncWithInvalidToken(string value)
        {
            var user = new User
            {
                RoleName = "TestValue2009279513",
                RefreshToken = "TestValue556655928",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1253792701,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1709719616",
                        FollowersCount = 1959713120,
                        NextStatusId = 1199490237,
                        UserTarget = 1511220862,
                        AccountId = 101691744,
                        Account = default
                    },
                    Cread = "TestValue213830444",
                    Photo = "TestValue85915845",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1881346386,
                    User = default
                }
            };

            var token = "TestValue1799923867";
            var newPassword = "TestValue180498334";

            _userManager.Setup(x => x.ResetPasswordAsync(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed());

            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.ChengePasswordAsync(new User
            {
                RoleName = "TestValue721226928",
                RefreshToken = "TestValue1222514995",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 2118394928,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue151566993",
                        FollowersCount = 1445487063,
                        NextStatusId = 1594462860,
                        UserTarget = 1881234399,
                        AccountId = 1277326677,
                        Account = default
                    },
                    Cread = "TestValue856502120",
                    Photo = "TestValue82600594",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 221769171,
                    User = default
                }
            }, value, "TestValue1509908094"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallChengePasswordAsyncWithInvalidNewPassword(string value)
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.ChengePasswordAsync(new User
            {
                RoleName = "TestValue711264895",
                RefreshToken = "TestValue983948270",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 896289459,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1758856398",
                        FollowersCount = 552284974,
                        NextStatusId = 146927178,
                        UserTarget = 1152113226,
                        AccountId = 130589277,
                        Account = default
                    },
                    Cread = "TestValue1907262195",
                    Photo = "TestValue1920029540",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2102863982,
                    User = default
                }
            }, "TestValue1551029484", value));
        }

        [Test]
        public async Task CanCallVerifyPasswordAsync()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue1013896244",
                RefreshToken = "TestValue826358829",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1598654334,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue2078608175",
                        FollowersCount = 1383093128,
                        NextStatusId = 1523707486,
                        UserTarget = 825962247,
                        AccountId = 989608763,
                        Account = default
                    },
                    Cread = "TestValue740603166",
                    Photo = "TestValue1235824802",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1214526518,
                    User = default
                }
            };
            var password = "TestValue960258457";

            var mockPasswordHasher = new Mock<IPasswordHasher<User>>();
            mockPasswordHasher.Setup(x => x.VerifyHashedPassword(It.IsAny<User>(), It.IsAny<string>(), password))
                .Returns(PasswordVerificationResult.Success);

            _userManager.Object.PasswordHasher = mockPasswordHasher.Object;

            // Act
            var result = await _testClass.VerifyPasswordAsync(user, password);

            // Assert
            mockPasswordHasher.Verify(x => x.VerifyHashedPassword(It.IsAny<User>(), It.IsAny<string>(), password));
        }

        [Test]
        public void CannotCallVerifyPasswordAsyncWithNullUser()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.VerifyPasswordAsync(default, "TestValue125796474"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallVerifyPasswordAsyncWithPassword(string value)
        {
            //Arrange
            var user = new User
            {
                RoleName = "TestValue444235283",
                RefreshToken = "TestValue1151419946",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 921982325,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue128045114",
                        FollowersCount = 1426812898,
                        NextStatusId = 397290581,
                        UserTarget = 1627119022,
                        AccountId = 1737943949,
                        Account = default
                    },
                    Cread = "TestValue1837065790",
                    Photo = "TestValue799955967",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1265227121,
                    User = default
                }
            };

            var mockedPasswordHasher = new Mock<PasswordHasher<User>>();
            mockedPasswordHasher.Setup(x => x.VerifyHashedPassword(user, user.PasswordHash, value))
                .Returns(PasswordVerificationResult.Failed);

            //Act
            var passwordVlidationResult = _testClass.VerifyPasswordAsync(user, value);

            //Assert
            mockedPasswordHasher.Verify(x => x.VerifyHashedPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never());
        }

        [Test]
        public async Task CanCallGetPasswordConfirmationTokenAsync()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue1465024632",
                RefreshToken = "TestValue474543094",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1329061412,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1652996689",
                        FollowersCount = 1175868755,
                        NextStatusId = 175715291,
                        UserTarget = 297459625,
                        AccountId = 948681035,
                        Account = default
                    },
                    Cread = "TestValue1267134660",
                    Photo = "TestValue567365444",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1285154396,
                    User = default
                }
            };

            _userManager.Setup(x => x.GeneratePasswordResetTokenAsync(user))
                .ReturnsAsync(Guid.NewGuid().ToString());

            // Act
            var result = await _testClass.GetPasswordConfirmationTokenAsync(user);

            // Assert
            _userManager.Verify(x => x.GeneratePasswordResetTokenAsync(user), Times.Once());

            Assert.IsNotNull(result);
        }

        [Test]
        public void CanCallAddPasswod()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue619128234",
                RefreshToken = "TestValue2143292173",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1950109871,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue2041717196",
                        FollowersCount = 1480278281,
                        NextStatusId = 1404121994,
                        UserTarget = 1379644055,
                        AccountId = 769304928,
                        Account = default
                    },
                    Cread = "TestValue1622923740",
                    Photo = "TestValue1916905399",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 2083514649,
                    User = default
                }
            };
            var password = "TestValue1633059924";

            // Act
            var result = _testClass.AddPasswod(user, password);

            // Assert
            Assert.AreSame(result, user.PasswordHash);
        }

        [Test]
        public void CannotCallAddPasswodWithNullUser()
        {
            Assert.Throws<NullReferenceException>(() => _testClass.AddPasswod(default, "TestValue108049691"));
        }

        [TestCase(null)]
        [TestCase("")]
        public void CannotCallAddPasswodWithInvalidPassword(string value)
        {
            if (value == null)
                Assert.IsNull(value);
            else if (string.IsNullOrWhiteSpace(value))
                Assert.IsEmpty(value);
        }

        private Mock<UserManager<TUser>> GetUserManager<TUser>()
            where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var passwordHasher = new Mock<IPasswordHasher<TUser>>();
            passwordHasher.Setup(x => x.HashPassword(It.IsAny<TUser>(), It.IsAny<string>()))
                .Returns(Guid.NewGuid().ToString());

            IList<IUserValidator<TUser>> userValidators = new List<IUserValidator<TUser>>
            {
                new UserValidator<TUser>()
            };
            IList<IPasswordValidator<TUser>> passwordValidators = new List<IPasswordValidator<TUser>>
            {
                new PasswordValidator<TUser>()
            };
            userValidators.Add(new UserValidator<TUser>());
            passwordValidators.Add(new PasswordValidator<TUser>());

            var userManager = new Mock<UserManager<TUser>>(store.Object, null, passwordHasher.Object, userValidators, passwordValidators, null, null, null, null);

            return userManager;
        }
    }
}
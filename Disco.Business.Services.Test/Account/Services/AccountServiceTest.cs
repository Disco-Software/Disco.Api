using Disco.Business.Constants;
using Disco.Business.Exceptions;
using Disco.Business.Services.Services;
using Disco.Domain.Interfaces;
using Disco.Domain.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System.Security.Claims;

namespace Disco.Business.Services.Test.Account.Admin.Services
{
    [TestFixture]
    public class AccountServiceTest
    {
        private AccountService _service;

        private Mock<UserManager<User>> _userManagerMock;
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IAccountRepository> _accountRepositoryMock;
        private Mock<IAccountStatusRepository> _accountStatusRepositoryMock;
        private Mock<IFollowerRepository> _followerRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _userManagerMock = this.MockUserManager();
            _accountRepositoryMock = new Mock<IAccountRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _accountStatusRepositoryMock = new Mock<IAccountStatusRepository>();
            _followerRepositoryMock = new Mock<IFollowerRepository>();

            _service = new AccountService(
                _userManagerMock.Object,
                _userRepositoryMock.Object,
                _accountRepositoryMock.Object,
                _accountStatusRepositoryMock.Object,
                _followerRepositoryMock.Object); ;
        }

        [Test]
        public void Constructor_WithValidParameters_CreatesInstance()
        {
            // Arrange
            UserManager<User> userManager = MockUserManager().Object;
            IUserRepository userRepository = Mock.Of<IUserRepository>();
            IAccountRepository accountRepository = Mock.Of<IAccountRepository>();
            IAccountStatusRepository accountStatusRepository = Mock.Of<IAccountStatusRepository>();
            IFollowerRepository followerRepository = Mock.Of<IFollowerRepository>();

            // Act
            var accountService = new AccountService(userManager, userRepository, accountRepository, accountStatusRepository, followerRepository);

            // Assert
            Assert.IsNotNull(accountService);
        }

        [Test]
        public void Constructor_WithNullUserManager_ThrowsArgumentNullException()
        {
            // Arrange
            UserManager<User> userManager = null;
            IUserRepository userRepository = Mock.Of<IUserRepository>();
            IAccountRepository accountRepository = Mock.Of<IAccountRepository>();
            IAccountStatusRepository accountStatusRepository = Mock.Of<IAccountStatusRepository>();
            IFollowerRepository followerRepository = Mock.Of<IFollowerRepository>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                new AccountService(
                    userManager, 
                    userRepository, 
                    accountRepository, 
                    accountStatusRepository, 
                    followerRepository);
            });
        }

        [Test]
        public void Constructor_WithNullUserRepository_ThrowsArgumentNullException()
        {
            // Arrange
            UserManager<User> userManager = MockUserManager().Object;
            IUserRepository userRepository = null;
            IAccountRepository accountRepository = Mock.Of<IAccountRepository>();
            IAccountStatusRepository accountStatusRepository = Mock.Of<IAccountStatusRepository>();
            IFollowerRepository followerRepository = Mock.Of<IFollowerRepository>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                new AccountService(userManager, userRepository, accountRepository, accountStatusRepository, followerRepository);
            });
        }

        [Test]
        public void Constructor_WithNullAccountRepository_ThrowsArgumentNullException()
        {
            // Arrange
            UserManager<User> userManager = MockUserManager().Object;
            IUserRepository userRepository = Mock.Of<IUserRepository>();
            IAccountRepository accountRepository = null;
            IAccountStatusRepository accountStatusRepository = Mock.Of<IAccountStatusRepository>();
            IFollowerRepository followerRepository = Mock.Of<IFollowerRepository>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                new AccountService(userManager, userRepository, accountRepository, accountStatusRepository, followerRepository);
            });
        }

        [Test]
        public void Constructor_WithNullAccountStatusRepository_ThrowsArgumentNullException()
        {
            // Arrange
            UserManager<User> userManager = MockUserManager().Object;
            IUserRepository userRepository = Mock.Of<IUserRepository>();
            IAccountRepository accountRepository = Mock.Of<IAccountRepository>();
            IAccountStatusRepository accountStatusRepository = null;
            IFollowerRepository followerRepository = Mock.Of<IFollowerRepository>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                new AccountService(userManager, userRepository, accountRepository, accountStatusRepository, followerRepository);
            });
        }

        [Test]
        public void Constructor_WithNullFollowerRepository_ThrowsArgumentNullException()
        {
            // Arrange
            UserManager<User> userManager = MockUserManager().Object;
            IUserRepository userRepository = Mock.Of<IUserRepository>();
            IAccountRepository accountRepository = Mock.Of<IAccountRepository>();
            IAccountStatusRepository accountStatusRepository = Mock.Of<IAccountStatusRepository>();
            IFollowerRepository followerRepository = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                new AccountService(userManager, userRepository, accountRepository, accountStatusRepository, followerRepository);
            });
        }

        [Test]
        public async Task GetByEmailAsync_ValidEmail_ReturnsUser()
        {
            // Arrange
            var email = "test@example.com";
            var user = new User { Email = email, AccountId = 1 };

            _userManagerMock.Setup(m => m.FindByEmailAsync(email)).ReturnsAsync(user);
            _accountRepositoryMock.Setup(m => m.GetAsync(user.AccountId)).ReturnsAsync(new Domain.Models.Models.Account());
            _userRepositoryMock.Setup(m => m.GetUserRole(user)).Returns("User");
            _accountStatusRepositoryMock.Setup(m => m.GetStatusByFollowersCountAsync(It.IsAny<int>())).ReturnsAsync(new AccountStatus());

            // Act
            var resultUser = await _service.GetByEmailAsync(email);

            // Assert
            Assert.AreEqual(user, resultUser);
        }

        [Test]
        public void GetByEmailAsync_InvalidEmail_ThrowsException()
        {
            // Arrange
            var email = "nonexistent@example.com";

            _userManagerMock.Setup(m => m.FindByEmailAsync(email)).ReturnsAsync((User)null);

            // Act & Assert
            Assert.ThrowsAsync<ResourceNotFoundException>(() => _service.GetByEmailAsync(email));
        }

        [Test]
        public async Task SaveRefreshTokenAsync_ValidUserAndToken_SuccessfulSave()
        {
            // Arrange
            var user = new User { Id = 1 };
            var refreshToken = "new-refresh-token";

            _userRepositoryMock.Setup(m => m.SaveRefreshTokenAsync(user, refreshToken)).Returns(Task.CompletedTask);

            // Act
            await _service.SaveRefreshTokenAsync(user, refreshToken);

            // Assert
            _userRepositoryMock.Verify((x) => x.SaveRefreshTokenAsync((User)user, refreshToken), Times.Once());
        }

        [Test]
        public async Task GetByRefreshTokenAsync_ValidToken_ReturnsUser()
        {
            // Arrange
            var refreshToken = "valid-refresh-token";
            var expectedUser = new User { Id = 1, UserName = "testuser" };

            _userRepositoryMock.Setup(m => m.GetUserByRefreshTokenAsync(refreshToken)).ReturnsAsync(expectedUser);

            // Act
            var result = await _service.GetByRefreshTokenAsync(refreshToken);

            // Assert
            Assert.AreEqual(expectedUser, result);
        }

        [Test]
        public async Task GetAsync_ValidClaimsPrincipal_ReturnsUser()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Role, "Test"),
            };

            var claimsIdentity = new ClaimsIdentity(claims);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var expectedUser = new User()
            {
                Id = 1,
                RoleName = "Test",
                UserName = "Test",
                NormalizedEmail = "Test",
                NormalizedUserName = "Test",
                PhoneNumber = "Test",
                AccessFailedCount = 1,
                TwoFactorEnabled = true,
                Account = new Domain.Models.Models.Account(),
                AccountId = 1
            };

            _userManagerMock.Setup(m => m.GetUserAsync(claimsPrincipal)).ReturnsAsync(expectedUser);
            _accountRepositoryMock.Setup(m => m.GetAsync(expectedUser.AccountId)).ReturnsAsync(expectedUser.Account);
            _accountStatusRepositoryMock.Setup(m => m.GetStatusByFollowersCountAsync(It.IsAny<int>())).ReturnsAsync(new AccountStatus());
            _userRepositoryMock.Setup(m => m.GetUserRole(It.IsAny<User>())).Returns("Test");

            // Act
            var result = await _service.GetAsync(claimsPrincipal);

            // Assert
            Assert.AreEqual(expectedUser, result);
            Assert.IsNotNull(result.Account);
            Assert.IsNotNull(result.RoleName);
            Assert.IsNotNull(result.Account.AccountStatus);
            Assert.AreEqual(expectedUser.AccountId, result.Account.AccountStatus.AccountId);
        }

        [Test]
        public void GetAsync_InvalidClaimsPrincipal_ThrowsException()
        {
            // Arrange
            var invalidClaimsPrincipal = new ClaimsPrincipal(); // Empty ClaimsPrincipal

            // Act & Assert
            Assert.ThrowsAsync<NullReferenceException>(() => _service.GetAsync(invalidClaimsPrincipal));
        }

        [Test]
        public async Task GetByIdAsync_ValidId_ReturnsUser()
        {
            // Arrange
            var userId = 1;
            var user = new User()
            {
                Id = 1,
                RoleName = "Test",
                UserName = "Test",
                NormalizedEmail = "Test",
                NormalizedUserName = "Test",
                PhoneNumber = "Test",
                AccessFailedCount = 1,
                TwoFactorEnabled = true,
                Account = new Domain.Models.Models.Account(),
                AccountId = 1
            };

            _userManagerMock.Setup(m => m.FindByIdAsync(userId.ToString())).ReturnsAsync(user);
            _accountRepositoryMock.Setup(m => m.GetAsync(user.AccountId)).ReturnsAsync(user.Account);
            _accountStatusRepositoryMock.Setup(m => m.GetStatusByFollowersCountAsync(It.IsAny<int>())).ReturnsAsync(new AccountStatus());
            _userRepositoryMock.Setup(m => m.GetUserRole(It.IsAny<User>())).Returns("Admin");

            // Act
            var result = await _service.GetByIdAsync(userId);

            // Assert
            Assert.AreEqual(user, result);
            Assert.IsNotNull(result.Account);
            Assert.IsNotNull(result.RoleName);
            Assert.IsNotNull(result.Account.AccountStatus);
        }

        [Test]
        public void GetByIdAsync_InvalidId_ThrowsResourceNotFoundException()
        {
            // Arrange
            var invalidUserId = 999;
            _userManagerMock.Setup(m => m.FindByIdAsync(invalidUserId.ToString())).ReturnsAsync((User)null);

            // Act & Assert
            Assert.ThrowsAsync<ResourceNotFoundException>(async () => await _service.GetByIdAsync(invalidUserId));
        }

        [Test]
        public async Task CreateAsync_ValidUser_CreatesUserAndSetsProperties()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                RoleName = UserRole.USER_ROLE,
                UserName = "testuser",
                Email = "test@example.com",
                Account = new Domain.Models.Models.Account { Id = 123, Followers = new List<UserFollower>(), Following = new List<UserFollower>() },
            };

            _userManagerMock.Setup(m => m.NormalizeEmail(user.Email)).Returns(user.Email.ToUpper());
            _userManagerMock.Setup(m => m.NormalizeName(user.UserName)).Returns(user.UserName.ToUpper());
            _accountStatusRepositoryMock.Setup(m => m.GetStatusByFollowersCountAsync(It.IsAny<int>())).ReturnsAsync(new AccountStatus());
            _userManagerMock.Setup(m => m.CreateAsync(user)).ReturnsAsync(IdentityResult.Success);
            _userManagerMock.Setup(m => m.AddToRoleAsync(user, UserRole.USER_ROLE)).ReturnsAsync(IdentityResult.Success);
            _userRepositoryMock.Setup(m => m.GetUserRole(It.IsAny<User>())).Returns(UserRole.USER_ROLE);

            // Act
            await _service.CreateAsync(user);

            // Assert
            Assert.IsNotNull(user.NormalizedEmail);
            Assert.IsNotNull(user.NormalizedUserName);
            Assert.IsNotNull(user.Account.AccountStatus);
            Assert.IsNotNull(user.DateOfRegister);
            Assert.AreEqual(user.Account.Id, user.AccountId);
            Assert.AreEqual(UserRole.USER_ROLE, user.RoleName);
            
            _userManagerMock.Verify(m => m.NormalizeEmail(user.Email), Times.Once);
            _userManagerMock.Verify(m => m.NormalizeName(user.UserName), Times.Once);
            _userManagerMock.Verify(m => m.CreateAsync(user), Times.Once);
            _userManagerMock.Verify(m => m.AddToRoleAsync(user, UserRole.USER_ROLE), Times.Once);
        }

        [Test]
        public void CreateAsync_InvalidUser_ThrowsNullReferenceException()
        {
            // Arrange
            var user = new User();

            _userManagerMock.Setup(m => m.CreateAsync(user)).ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Error" }));

            // Act & Assert
            Assert.ThrowsAsync<NullReferenceException>(async () => await _service.CreateAsync(user));
        }

        [Test]
        public async Task GetByLogInProviderAsync_UserExists_ReturnsUser()
        {
            // Arrange
            var loginProvider = "someProvider";
            var providerKey = "someKey";

            var user = new User
            {
                Id = 1,
                RoleName = UserRole.USER_ROLE,
                UserName = "testuser",
                Email = "test@example.com",
                Account = new Domain.Models.Models.Account { Id = 123, Followers = new List<UserFollower>(), Following = new List<UserFollower>() },
            };

            _userManagerMock.Setup(m => m.FindByLoginAsync(loginProvider, providerKey)).ReturnsAsync(user);
            _accountRepositoryMock.Setup(m => m.GetAsync(user.AccountId)).ReturnsAsync(user.Account);
            _accountStatusRepositoryMock.Setup(m => m.GetStatusByFollowersCountAsync(It.IsAny<int>())).ReturnsAsync(new AccountStatus());
            _userRepositoryMock.Setup(m => m.GetUserRole(user)).Returns(UserRole.USER_ROLE);

            // Act
            var result = await _service.GetByLogInProviderAsync(loginProvider, providerKey);

            // Assert
            Assert.AreEqual(user, result);
            Assert.IsNotNull(result.Account);
            Assert.IsNotNull(result.RoleName);
            Assert.IsNotNull(result.Account.AccountStatus);
            Assert.AreEqual(user.AccountId, result.Account.AccountStatus.AccountId);

            _userManagerMock.Verify(m => m.FindByLoginAsync(loginProvider, providerKey), Times.Once);
            _accountRepositoryMock.Verify(m => m.GetAsync(user.AccountId), Times.Once);
            _accountStatusRepositoryMock.Verify(m => m.GetStatusByFollowersCountAsync(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void GetByLogInProviderAsync_UserNotExists_ThrowsResourceNotFoundException()
        {
            // Arrange
            var loginProvider = "nonexistentProvider";
            var providerKey = "nonexistentKey";

            _userManagerMock.Setup(m => m.FindByLoginAsync(loginProvider, providerKey)).ReturnsAsync((User)null);

            // Act & Assert
            Assert.ThrowsAsync<ResourceNotFoundException>(async () => await _service.GetByLogInProviderAsync(loginProvider, providerKey));

            _userManagerMock.Verify(m => m.FindByLoginAsync(loginProvider, providerKey), Times.Once);
            _accountRepositoryMock.Verify(m => m.GetAsync(It.IsAny<int>()), Times.Never);
            _accountStatusRepositoryMock.Verify(m => m.GetStatusByFollowersCountAsync(It.IsAny<int>()), Times.Never);
        }

        [Test]
        public async Task GetByNameAsync_UserExists_ReturnsUser()
        {
            // Arrange
            var userName = "existingUser";
            var user = new User
            {
                Id = 1,
                RoleName = UserRole.USER_ROLE,
                UserName = "testuser",
                Email = "test@example.com",
                Account = new Domain.Models.Models.Account { Id = 123, Followers = new List<UserFollower>(), Following = new List<UserFollower>() },
            };

            _userManagerMock.Setup(m => m.FindByNameAsync(userName)).ReturnsAsync(user);
            _accountRepositoryMock.Setup(m => m.GetAsync(user.AccountId)).ReturnsAsync(user.Account);
            _accountStatusRepositoryMock.Setup(m => m.GetStatusByFollowersCountAsync(It.IsAny<int>())).ReturnsAsync(new AccountStatus());
            _userRepositoryMock.Setup(m => m.GetUserRole(It.IsAny<User>())).Returns(UserRole.USER_ROLE);

            // Act
            var result = await _service.GetByNameAsync(userName);

            // Assert
            Assert.AreEqual(user, result);
            Assert.IsNotNull(result.Account);
            Assert.IsNotNull(result.RoleName);
            Assert.IsNotNull(result.Account.AccountStatus);
            Assert.AreEqual(user.AccountId, result.Account.AccountStatus.AccountId);

            _userManagerMock.Verify(m => m.FindByNameAsync(userName), Times.Once);
            _accountRepositoryMock.Verify(m => m.GetAsync(It.IsAny<int>()), Times.Once);
            _accountStatusRepositoryMock.Verify(m => m.GetStatusByFollowersCountAsync(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void GetByNameAsync_UserNotExists_ThrowsResourceNotFoundException()
        {
            // Arrange
            var userName = "nonexistentUser";

            _userManagerMock.Setup(m => m.FindByNameAsync(userName)).ReturnsAsync((User)null);

            // Act & Assert
            Assert.ThrowsAsync<ResourceNotFoundException>(async () => await _service.GetByNameAsync(userName));

            _userManagerMock.Verify(m => m.FindByNameAsync(userName), Times.Once);
            _accountRepositoryMock.Verify(m => m.GetAsync(It.IsAny<int>()), Times.Never);
            _accountStatusRepositoryMock.Verify(m => m.GetStatusByFollowersCountAsync(It.IsAny<int>()), Times.Never);
        }

        [Test]
        public async Task GetUsersByPeriotAsync_ValidPeriod_ReturnsUsers()
        {
            // Arrange
            var period = 7; // Replace with your desired period
            var expectedUsers = new List<User>
            {
                new User { Id = 1, UserName = "user1" },
                new User { Id = 2, UserName = "user2" },
            };

            _userRepositoryMock.Setup(m => m.GetUsersByPeriotIntAsync(period)).ReturnsAsync(expectedUsers);

            // Act
            var result = await _service.GetUsersByPeriotAsync(period);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<User>>(result);
            Assert.AreEqual(expectedUsers, result);

            _userRepositoryMock.Verify(m => m.GetUsersByPeriotIntAsync(period), Times.Once);
        }

        [Test]
        public async Task GetUsersByPeriotAsync_InvalidPeriod_ReturnsEmptyList()
        {
            // Arrange
            var invalidPeriod = -1; // Replace with an invalid period
            _userRepositoryMock.Setup(m => m.GetUsersByPeriotIntAsync(invalidPeriod)).ReturnsAsync(new List<User>());

            // Act
            var result = await _service.GetUsersByPeriotAsync(invalidPeriod);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<User>>(result);
            Assert.IsEmpty(result);

            _userRepositoryMock.Verify(m => m.GetUsersByPeriotIntAsync(invalidPeriod), Times.Once);
        }

        [Test]
        public async Task IsInRoleAsync_UserInRole_ReturnsTrue()
        {
            // Arrange
            var user = new User { Id = 1, UserName = "testuser" };
            var roleName = "UserRole"; // Replace with your desired role
            _userManagerMock.Setup(m => m.IsInRoleAsync(user, roleName)).ReturnsAsync(true);

            // Act
            var result = await _service.IsInRoleAsync(user, roleName);

            // Assert
            Assert.IsTrue(result);

            _userManagerMock.Verify(m => m.IsInRoleAsync(user, roleName), Times.Once);
        }

        [Test]
        public async Task IsInRoleAsync_UserNotInRole_ReturnsFalse()
        {
            // Arrange
            var user = new User { Id = 1, UserName = "testuser" };
            var roleName = "NonExistentRole"; // Replace with a role that the user is not in
            _userManagerMock.Setup(m => m.IsInRoleAsync(user, roleName)).ReturnsAsync(false);

            // Act
            var result = await _service.IsInRoleAsync(user, roleName);

            // Assert
            Assert.IsFalse(result);

            _userManagerMock.Verify(m => m.IsInRoleAsync(user, roleName), Times.Once);
        }

        [Test]
        public async Task RemoveAsync_UserExists_SuccessfullyRemoved()
        {
            // Arrange
            var user = new User { Id = 1, UserName = "testuser" };
            _userManagerMock.Setup(m => m.DeleteAsync(user)).ReturnsAsync(IdentityResult.Success);

            // Act
            await _service.RemoveAsync(user);

            // Assert
            _userManagerMock.Verify(m => m.DeleteAsync(user), Times.Once);
        }

        [Test]
        public async Task GetByAccountIdAsync_AccountExists_ReturnsAccount()
        {
            // Arrange
            int accountId = 123;
            var expectedAccount = new Domain.Models.Models.Account { Id = accountId, };
            
            _accountRepositoryMock.Setup(m => m.GetAccountAsync(accountId)).ReturnsAsync(expectedAccount);

            // Act
            var result = await _service.GetByAccountIdAsync(accountId);

            // Assert
            Assert.AreEqual(expectedAccount, result);
            _accountRepositoryMock.Verify(m => m.GetAccountAsync(accountId), Times.Once);
        }

        [Test]
        public async Task GetByAccountIdAsync_AccountDoesNotExist_ThrowsResourceNotFoundException()
        {
            // Arrange
            int accountId = 456;
            _accountRepositoryMock.Setup(m => m.GetAccountAsync(accountId)).ReturnsAsync((Domain.Models.Models.Account)null);

            // Act & Assert
            Assert.ThrowsAsync<ResourceNotFoundException>(async () => await _service.GetByAccountIdAsync(accountId));

            _accountRepositoryMock.Verify(m => m.GetAccountAsync(accountId), Times.Once);
        }

        [Test]
        public async Task UpdateAsync_CallsUserManagerUpdateAsync()
        {
            // Arrange
            var user = new User { Id = 1, UserName = "testuser" };

            // Act
            await _service.UpdateAsync(user);

            // Assert
            _userManagerMock.Verify(m => m.UpdateAsync(user), Times.Once);
        }

        private Mock<UserManager<User>> MockUserManager()
        {
            var user = new User()
            {
                Id = 1,
                RoleName = "Test",
                UserName = "Test",
                NormalizedEmail = "Test",
                NormalizedUserName = "Test",
                PhoneNumber = "Test",
                AccessFailedCount = 1,
                TwoFactorEnabled = true,
                Account = new Domain.Models.Models.Account(),
                AccountId = 1
            };

            var userManagerMock = new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(),
                Mock.Of<IOptions<IdentityOptions>>(),
                Mock.Of<IPasswordHasher<User>>(),
                new List<IUserValidator<User>>(),
                new List<IPasswordValidator<User>>(),
                Mock.Of<ILookupNormalizer>(),
                Mock.Of<IdentityErrorDescriber>(),
                Mock.Of<IServiceProvider>(),
                Mock.Of<ILogger<UserManager<User>>>()
            );

            userManagerMock.Setup(m => m.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((string email) => user);
            
            userManagerMock.Setup(m => m.GetUserAsync(It.IsAny<ClaimsPrincipal>()))
                .ReturnsAsync(() => user);

            userManagerMock.Setup(m => m.CreateAsync(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Success);

            userManagerMock.Setup(m => m.DeleteAsync(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Success);

            return userManagerMock;
        }
    }
}

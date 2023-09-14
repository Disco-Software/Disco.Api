using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Disco.Business.Constants;
using Disco.Business.Exceptions;
using Disco.Business.Services.Services;
using Disco.Domain.Interfaces;
using Disco.Domain.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace Disco.Test.Business.Account.Servicess
{
    [TestFixture]
    public class AccountServiceTests
    {
        private AccountService _accountService;
        
        private Mock<UserManager<User>> _userManager;
        private Mock<IUserRepository> _userRepository;
        private Mock<IAccountRepository> _accountRepository;
        private Mock<IAccountStatusRepository> _accountStatusRepository;
        private Mock<IFollowerRepository> _followerRepository;

        [SetUp]
        public void SetUp()
        {
            _userManager = GetUserManager<User>();

            _userManager.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>()))
                .ReturnsAsync(new User { UserName = "vasya_pupkin", Id = 0 });

            _userRepository = new Mock<IUserRepository>();
            _accountRepository = new Mock<IAccountRepository>();
            _accountStatusRepository = new Mock<IAccountStatusRepository>();
            _followerRepository = new Mock<IFollowerRepository>();
            _accountService = new AccountService(
                _userManager.Object, 
                _userRepository.Object, 
                _accountRepository.Object,
                _accountStatusRepository.Object, 
                _followerRepository.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new AccountService(_userManager.Object, _userRepository.Object, _accountRepository.Object, _accountStatusRepository.Object, _followerRepository.Object);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallGetByEmailAsync()
        {
            // Arrange
            var email = "TestValue1824513987";

            _userManager.Setup(mock => mock.FindByEmailAsync(email))
                .ReturnsAsync(new User
                {
                    UserName = Guid.NewGuid().ToString(),
                    Email = Guid.NewGuid().ToString() + "@gmail.com"
                });
            _userRepository.Setup(mock => mock.GetUserRole(It.IsAny<User>())).Returns("TestValue1060174302");
            _accountRepository.Setup(mock => mock.GetAsync(It.IsAny<int>())).ReturnsAsync(new Domain.Models.Models.Account()
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue105496015",
                    FollowersCount = 1992149780,
                    NextStatusId = 1755222771,
                    UserTarget = 2121905592,
                    AccountId = 133441750,
                    Account = default(Domain.Models.Models.Account)
                },
                Cread = "TestValue1469187632",
                Photo = "TestValue1530622572",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Domain.Models.Models.Connection>(),
                Messages = new List<Domain.Models.Models.Message>(),
                Posts = new List<Domain.Models.Models.Post>(),
                Comments = new List<Domain.Models.Models.Comment>(),
                Likes = new List<Domain.Models.Models.Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Domain.Models.Models.Story>(),
                UserId = 681797057,
                User = new User
                {
                    RoleName = "TestValue1016160451",
                    RefreshToken = "TestValue908706633",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 136942585,
                    Account = default(Domain.Models.Models.Account)
                }
            });
            _accountRepository.Setup(mock => mock.GetAllAccountConnectionsAsync(It.IsAny<int>())).ReturnsAsync(new List<Domain.Models.Models.Connection>());
            _accountStatusRepository.Setup(mock => mock.GetStatusByFollowersCountAsync(It.IsAny<int>())).ReturnsAsync(new AccountStatus
            {
                LastStatus = "TestValue2093233378",
                FollowersCount = 1940187085,
                NextStatusId = 1846443501,
                UserTarget = 1181537401,
                AccountId = 1433903832,
                Account = new Domain.Models.Models.Account
                {
                    AccountStatus = default(AccountStatus),
                    Cread = "TestValue805066400",
                    Photo = "TestValue675146314",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Domain.Models.Models.Connection>(),
                    Messages = new List<Domain.Models.Models.Message>(),
                    Posts = new List<Domain.Models.Models.Post>(),
                    Comments = new List<Domain.Models.Models.Comment>(),
                    Likes = new List<Domain.Models.Models.Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Domain.Models.Models.Story>(),
                    UserId = 1299720865,
                    User = new User
                    {
                        RoleName = "TestValue861917187",
                        RefreshToken = "TestValue876316926",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1522001549,
                        Account = default(Domain.Models.Models.Account)
                    }
                }
            });
            _followerRepository.Setup(mock => mock.GetFollowersAsync(It.IsAny<int>())).ReturnsAsync(new List<UserFollower>());
            _followerRepository.Setup(mock => mock.GetFollowingAsync(It.IsAny<int>())).ReturnsAsync(new List<UserFollower>());

            // Act
            var result = await _accountService.GetByEmailAsync(email);

            // Assert
            _userRepository.Verify(mock => mock.GetUserRole(It.IsAny<User>()));
            _accountRepository.Verify(mock => mock.GetAsync(It.IsAny<int>()));
            _accountStatusRepository.Verify(mock => mock.GetStatusByFollowersCountAsync(It.IsAny<int>()));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallGetByEmailAsyncWithInvalidEmail(string value)
        {
            Assert.ThrowsAsync<ResourceNotFoundException>(() => _accountService.GetByEmailAsync(value));
        }

        [Test]
        public async Task CanCallSaveRefreshTokenAsync()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue1838203990",
                RefreshToken = "TestValue715971703",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 200880128,
                Account = new Domain.Models.Models.Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1388885031",
                        FollowersCount = 1081962370,
                        NextStatusId = 1887530805,
                        UserTarget = 1827701181,
                        AccountId = 1312516675,
                        Account = default(Domain.Models.Models.Account)
                    },
                    Cread = "TestValue1852933159",
                    Photo = "TestValue1013331963",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Domain.Models.Models.Connection>(),
                    Messages = new List<Domain.Models.Models.Message>(),
                    Posts = new List<Domain.Models.Models.Post>(),
                    Comments = new List<Domain.Models.Models.Comment>(),
                    Likes = new List<Domain.Models.Models.Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Domain.Models.Models.Story>(),
                    UserId = 1601921586,
                    User = default(User)
                }
            };
            var refreshToken = "TestValue138550360";

            _userRepository.Setup(mock => mock.SaveRefreshTokenAsync(It.IsAny<User>(), It.IsAny<string>())).Verifiable();

            // Act
            await _accountService.SaveRefreshTokenAsync(user, refreshToken);

            // Assert
            _userRepository.Verify(mock => mock.SaveRefreshTokenAsync(It.IsAny<User>(), It.IsAny<string>()));
        }

        [Test]
        public async Task CanCallGetByRefreshTokenAsync()
        {
            // Arrange
            var refreshToken = "TestValue1405933889";

            _userRepository.Setup(mock => mock.GetUserByRefreshTokenAsync(It.IsAny<string>())).ReturnsAsync(new User
            {
                RoleName = "TestValue1223104091",
                RefreshToken = "TestValue795266545",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 999185524,
                Account = new Domain.Models.Models.Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1976882782",
                        FollowersCount = 1999045911,
                        NextStatusId = 694807326,
                        UserTarget = 895305885,
                        AccountId = 183857376,
                        Account = default(Domain.Models.Models.Account)
                    },
                    Cread = "TestValue730978114",
                    Photo = "TestValue167635793",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Domain.Models.Models.Connection>(),
                    Messages = new List<Domain.Models.Models.Message>(),
                    Posts = new List<Domain.Models.Models.Post>(),
                    Comments = new List<Domain.Models.Models.Comment>(),
                    Likes = new List<Domain.Models.Models.Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Domain.Models.Models.Story>(),
                    UserId = 2064502428,
                    User = default(User)
                }
            });

            // Act
            var result = await _accountService.GetByRefreshTokenAsync(refreshToken);

            // Assert
            _userRepository.Verify(mock => mock.GetUserByRefreshTokenAsync(It.IsAny<string>()));
        }

        [Test]
        public async Task GetByRefreshTokenAsyncPerformsMapping()
        {
            // Arrange
            var refreshToken = "TestValue2080045269";

            var user = new User
            {
                RoleName = "TestValue1838203990",
                RefreshToken = refreshToken,
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 200880128,
                Account = new Domain.Models.Models.Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1388885031",
                        FollowersCount = 1081962370,
                        NextStatusId = 1887530805,
                        UserTarget = 1827701181,
                        AccountId = 1312516675,
                        Account = default(Domain.Models.Models.Account)
                    },
                    Cread = "TestValue1852933159",
                    Photo = "TestValue1013331963",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Domain.Models.Models.Connection>(),
                    Messages = new List<Domain.Models.Models.Message>(),
                    Posts = new List<Domain.Models.Models.Post>(),
                    Comments = new List<Domain.Models.Models.Comment>(),
                    Likes = new List<Domain.Models.Models.Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Domain.Models.Models.Story>(),
                    UserId = 1601921586,
                }
            };

            _userRepository.Setup(x => x.GetUserByRefreshTokenAsync(It.IsAny<string>()))
                .ReturnsAsync(user);

            // Act
            var result = await _accountService.GetByRefreshTokenAsync(refreshToken);

            // Assert
            Assert.AreEqual(refreshToken, user.RefreshToken);
        }

        [Test]
        public async Task CanCallGetAsync()
        {
            // Arrange
            _userRepository.Setup(mock => mock.GetUserRole(It.IsAny<User>())).Returns("TestValue80302601");
            _accountRepository.Setup(mock => mock.GetAsync(It.IsAny<int>())).ReturnsAsync(new Domain.Models.Models.Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue448660202",
                    FollowersCount = 941749899,
                    NextStatusId = 1335942917,
                    UserTarget = 1743673605,
                    AccountId = 431493073,
                    Account = default(Domain.Models.Models.Account)
                },
                Cread = "TestValue1079901415",
                Photo = "TestValue338265499",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Domain.Models.Models.Connection>(),
                Messages = new List<Domain.Models.Models.Message>(),
                Posts = new List<Domain.Models.Models.Post>(),
                Comments = new List<Domain.Models.Models.Comment>(),
                Likes = new List<Domain.Models.Models.Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Domain.Models.Models.Story>(),
                UserId = 1707893141,
                User = new User
                {
                    RoleName = "TestValue1645323834",
                    RefreshToken = "TestValue1095460111",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 719543969,
                    Account = default(Domain.Models.Models.Account)
                }
            });
            _accountRepository.Setup(mock => mock.GetAllAccountConnectionsAsync(It.IsAny<int>())).ReturnsAsync(new List<Domain.Models.Models.Connection>());
            _accountStatusRepository.Setup(mock => mock.GetStatusByFollowersCountAsync(It.IsAny<int>())).ReturnsAsync(new AccountStatus
            {
                LastStatus = "TestValue1933814785",
                FollowersCount = 252605951,
                NextStatusId = 806200294,
                UserTarget = 1285136054,
                AccountId = 693578994,
                Account = new Domain.Models.Models.Account
                {
                    AccountStatus = default(AccountStatus),
                    Cread = "TestValue484353035",
                    Photo = "TestValue138052568",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Domain.Models.Models.Connection>(),
                    Messages = new List<Domain.Models.Models.Message>(),
                    Posts = new List<Domain.Models.Models.Post>(),
                    Comments = new List<Domain.Models.Models.Comment>(),
                    Likes = new List<Domain.Models.Models.Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Domain.Models.Models.Story>(),
                    UserId = 773202071,
                    User = new User
                    {
                        RoleName = "TestValue254551078",
                        RefreshToken = "TestValue165780940",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 286695825,
                        Account = default(Domain.Models.Models.Account)
                    }
                }
            });
            _followerRepository.Setup(mock => mock.GetFollowersAsync(It.IsAny<int>())).ReturnsAsync(new List<UserFollower>());
            _followerRepository.Setup(mock => mock.GetFollowingAsync(It.IsAny<int>())).ReturnsAsync(new List<UserFollower>());

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, "1707893141"),
                new Claim(ClaimTypes.Role, UserRole.User)
            };

            var claimIdentity = new ClaimsIdentity(claims);

            var claimsPrincipal = new ClaimsPrincipal(claimIdentity);

            // Act
            var result = await _accountService.GetAsync(claimsPrincipal);

            // Assert
            _userRepository.Verify(mock => mock.GetUserRole(It.IsAny<User>()));
            _accountRepository.Verify(mock => mock.GetAsync(It.IsAny<int>()));
            _accountStatusRepository.Verify(mock => mock.GetStatusByFollowersCountAsync(It.IsAny<int>()));
        }

        [Test]
        public void CannotCallGetAsyncWithNullClaimsPrincipal()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _accountService.GetAsync(default(ClaimsPrincipal)));
        }

        [Test]
        public async Task CanCallGetByIdAsync()
        {
            // Arrange
            var id = 65231126;

            _userManager.Setup(x => x.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(new User { UserName = "vasya_pupkin", Id = id, Email = "vasya_pupkin@gmail.com" });
            _userRepository.Setup(mock => mock.GetUserRole(It.IsAny<User>())).Returns(UserRole.User);
            _accountRepository.Setup(mock => mock.GetAsync(It.IsAny<int>())).ReturnsAsync(new Domain.Models.Models.Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1998302046",
                    FollowersCount = 1460954411,
                    NextStatusId = 1158125833,
                    UserTarget = 118026078,
                    AccountId = 1418064210,
                    Account = default(Domain.Models.Models.Account)
                },
                Cread = "TestValue1555055893",
                Photo = "TestValue1516061421",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Domain.Models.Models.Connection>(),
                Messages = new List<Domain.Models.Models.Message>(),
                Posts = new List<Domain.Models.Models.Post>(),
                Comments = new List<Domain.Models.Models.Comment>(),
                Likes = new List<Domain.Models.Models.Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Domain.Models.Models.Story>(),
                UserId = 421424940,
                User = new User
                {
                    RoleName = "TestValue827072189",
                    RefreshToken = "TestValue956253554",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 966812313,
                    Account = default(Domain.Models.Models.Account)
                }
            });
            _accountRepository.Setup(mock => mock.GetAllAccountConnectionsAsync(It.IsAny<int>())).ReturnsAsync(new List<Domain.Models.Models.Connection>());
            _accountStatusRepository.Setup(mock => mock.GetStatusByFollowersCountAsync(It.IsAny<int>())).ReturnsAsync(new AccountStatus
            {
                LastStatus = "TestValue1754540338",
                FollowersCount = 796914620,
                NextStatusId = 1639963285,
                UserTarget = 1743970994,
                AccountId = 1268658349,
                Account = new Domain.Models.Models.Account
                {
                    AccountStatus = default(AccountStatus),
                    Cread = "TestValue1010351864",
                    Photo = "TestValue1755547198",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Domain.Models.Models.Connection>(),
                    Messages = new List<Domain.Models.Models.Message>(),
                    Posts = new List<Domain.Models.Models.Post>(),
                    Comments = new List<Domain.Models.Models.Comment>(),
                    Likes = new List<Domain.Models.Models.Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Domain.Models.Models.Story>(),
                    UserId = 1662694597,
                    User = new User
                    {
                        RoleName = "TestValue1297426358",
                        RefreshToken = "TestValue2051209060",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1257338813,
                        Account = default(Domain.Models.Models.Account)
                    }
                }
            });

            // Act
            var result = await _accountService.GetByIdAsync(id);

            // Assert
            _userRepository.Verify(mock => mock.GetUserRole(It.IsAny<User>()));
            _accountRepository.Verify(mock => mock.GetAsync(It.IsAny<int>()));
            _accountStatusRepository.Verify(mock => mock.GetStatusByFollowersCountAsync(It.IsAny<int>()));
        }

        [Test]
        public async Task CanCallCreateAsync()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue282719194",
                RefreshToken = "TestValue1420850887",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 961875337,
                Account = new Domain.Models.Models.Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1067684936",
                        FollowersCount = 152837248,
                        NextStatusId = 129262413,
                        UserTarget = 674035171,
                        AccountId = 2039955427,
                        Account = default(Domain.Models.Models.Account)
                    },
                    Cread = "TestValue977561231",
                    Photo = "TestValue1433277285",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Domain.Models.Models.Connection>(),
                    Messages = new List<Domain.Models.Models.Message>(),
                    Posts = new List<Domain.Models.Models.Post>(),
                    Comments = new List<Domain.Models.Models.Comment>(),
                    Likes = new List<Domain.Models.Models.Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Domain.Models.Models.Story>(),
                    UserId = 1199143603,
                    User = default(User)
                }
            };

            _userRepository.Setup(mock => mock.GetUserRole(It.IsAny<User>())).Returns("TestValue442201375");
            _accountStatusRepository.Setup(mock => mock.GetStatusByFollowersCountAsync(It.IsAny<int>())).ReturnsAsync(new AccountStatus
            {
                LastStatus = "TestValue89105591",
                FollowersCount = 1046204969,
                NextStatusId = 37399120,
                UserTarget = 1830766405,
                AccountId = 1926449860,
                Account = new Domain.Models.Models.Account
                {
                    AccountStatus = default(AccountStatus),
                    Cread = "TestValue632731818",
                    Photo = "TestValue1825494191",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Domain.Models.Models.Connection>(),
                    Messages = new List<Domain.Models.Models.Message>(),
                    Posts = new List<Domain.Models.Models.Post>(),
                    Comments = new List<Domain.Models.Models.Comment>(),
                    Likes = new List<Domain.Models.Models.Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Domain.Models.Models.Story>(),
                    UserId = 2062005308,
                    User = new User
                    {
                        RoleName = "TestValue161964377",
                        RefreshToken = "TestValue53404618",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1485124518,
                        Account = default(Domain.Models.Models.Account)
                    }
                }
            });

            _userManager.Setup(x => x.CreateAsync(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            await _accountService.CreateAsync(user);

            // Assert
            _userRepository.Verify(mock => mock.GetUserRole(It.IsAny<User>()));
            _accountStatusRepository.Verify(mock => mock.GetStatusByFollowersCountAsync(It.IsAny<int>()));
        }

        [Test]
        public void CannotCallCreateAsyncWithNullUser()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _accountService.CreateAsync(null));
        }

        [Test]
        public async Task CanCallGetByLogInProviderAsync()
        {
            // Arrange
            var loginProvider = "TestValue1461251800";
            var providerKey = "TestValue1995291109";

            var account = new Domain.Models.Models.Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1201099356",
                    FollowersCount = 887865688,
                    NextStatusId = 1016877866,
                    UserTarget = 1910333854,
                    AccountId = 646487527,
                    Account = default(Domain.Models.Models.Account)
                },
                Cread = "TestValue650569990",
                Photo = "TestValue1136753114",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Domain.Models.Models.Connection>(),
                Messages = new List<Domain.Models.Models.Message>(),
                Posts = new List<Domain.Models.Models.Post>(),
                Comments = new List<Domain.Models.Models.Comment>(),
                Likes = new List<Domain.Models.Models.Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Domain.Models.Models.Story>(),
                UserId = 984619868,
                User = new User
                {
                    RoleName = "TestValue740963233",
                    RefreshToken = "TestValue1395723285",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 715924458,
                    Account = default(Domain.Models.Models.Account)
                }
            };

            _userRepository.Setup(mock => mock.GetUserRole(It.IsAny<User>())).Returns("TestValue488221434");
            _accountRepository.Setup(mock => mock.GetAsync(It.IsAny<int>())).ReturnsAsync(account);
            _accountRepository.Setup(mock => mock.GetAllAccountConnectionsAsync(It.IsAny<int>())).ReturnsAsync(new List<Domain.Models.Models.Connection>());
            _accountStatusRepository.Setup(mock => mock.GetStatusByFollowersCountAsync(It.IsAny<int>())).ReturnsAsync(new AccountStatus
            {
                LastStatus = "TestValue28920487",
                FollowersCount = 371859241,
                NextStatusId = 1517656773,
                UserTarget = 1832778663,
                AccountId = 642458727,
                Account = new Domain.Models.Models.Account
                {
                    AccountStatus = default(AccountStatus),
                    Cread = "TestValue194340371",
                    Photo = "TestValue1278243010",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Domain.Models.Models.Connection>(),
                    Messages = new List<Domain.Models.Models.Message>(),
                    Posts = new List<Domain.Models.Models.Post>(),
                    Comments = new List<Domain.Models.Models.Comment>(),
                    Likes = new List<Domain.Models.Models.Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Domain.Models.Models.Story>(),
                    UserId = 1052290652,
                    User = new User
                    {
                        RoleName = "TestValue1592575961",
                        RefreshToken = "TestValue743510002",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 154838767,
                        Account = default(Domain.Models.Models.Account)
                    }
                }
            });

            _userManager.Setup(x => x.FindByLoginAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(account.User);

            // Act
            var result = await _accountService.GetByLogInProviderAsync(loginProvider, providerKey);

            // Assert
            _userRepository.Verify(mock => mock.GetUserRole(It.IsAny<User>()));
            _accountRepository.Verify(mock => mock.GetAsync(It.IsAny<int>()));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallGetByLogInProviderAsyncWithInvalidLoginProvider(string value)
        {
            Assert.ThrowsAsync<ResourceNotFoundException>(() => _accountService.GetByLogInProviderAsync(value, "TestValue48476527"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallGetByLogInProviderAsyncWithInvalidProviderKey(string value)
        {
            Assert.ThrowsAsync<ResourceNotFoundException>(() => _accountService.GetByLogInProviderAsync("TestValue687862262", value));
        }

        [Test]
        public async Task CanCallGetByNameAsync()
        {
            // Arrange
            var name = "TestValue31576444";

            var account = new Domain.Models.Models.Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue1168163945",
                    FollowersCount = 1377173889,
                    NextStatusId = 1364867033,
                    UserTarget = 1235153542,
                    AccountId = 1156407737,
                    Account = default(Domain.Models.Models.Account)
                },
                Cread = "TestValue1037445635",
                Photo = "TestValue557983535",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Domain.Models.Models.Connection>(),
                Messages = new List<Domain.Models.Models.Message>(),
                Posts = new List<Domain.Models.Models.Post>(),
                Comments = new List<Domain.Models.Models.Comment>(),
                Likes = new List<Domain.Models.Models.Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Domain.Models.Models.Story>(),
                UserId = 983783411,
                User = new User
                {
                    RoleName = "TestValue942900717",
                    RefreshToken = "TestValue909571994",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 869881611,
                    Account = default(Domain.Models.Models.Account)
                }
            };

            _userRepository.Setup(mock => mock.GetUserRole(It.IsAny<User>())).Returns("TestValue1509857349");
            _accountRepository.Setup(mock => mock.GetAsync(It.IsAny<int>())).ReturnsAsync(account);
            _accountRepository.Setup(mock => mock.GetAllAccountConnectionsAsync(It.IsAny<int>())).ReturnsAsync(new List<Domain.Models.Models.Connection>());
            _accountStatusRepository.Setup(mock => mock.GetStatusByFollowersCountAsync(It.IsAny<int>())).ReturnsAsync(new AccountStatus
            {
                LastStatus = "TestValue1179006664",
                FollowersCount = 1411435318,
                NextStatusId = 1172694910,
                UserTarget = 1216268397,
                AccountId = 744161285,
                Account = new Domain.Models.Models.Account
                {
                    AccountStatus = default(AccountStatus),
                    Cread = "TestValue1034479556",
                    Photo = "TestValue704926429",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Domain.Models.Models.Connection>(),
                    Messages = new List<Domain.Models.Models.Message>(),
                    Posts = new List<Domain.Models.Models.Post>(),
                    Comments = new List<Domain.Models.Models.Comment>(),
                    Likes = new List<Domain.Models.Models.Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Domain.Models.Models.Story>(),
                    UserId = 932954850,
                    User = new User
                    {
                        RoleName = "TestValue695825695",
                        RefreshToken = "TestValue782664122",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 443967397,
                        Account = default(Domain.Models.Models.Account)
                    }
                }
            });

            _userManager.Setup(x => x.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(account.User);

            // Act
            var result = await _accountService.GetByNameAsync(name);

            // Assert
            _userRepository.Verify(mock => mock.GetUserRole(It.IsAny<User>()));
            _accountRepository.Verify(mock => mock.GetAsync(It.IsAny<int>()));
            _accountStatusRepository.Verify(mock => mock.GetStatusByFollowersCountAsync(It.IsAny<int>()));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallGetByNameAsyncWithInvalidName(string value)
        {
            Assert.ThrowsAsync<ResourceNotFoundException>(() => _accountService.GetByNameAsync(value));
        }

        [Test]
        public async Task CanCallGetUsersByPeriotAsync()
        {
            // Arrange
            var periot = 1845615056;

            _userRepository.Setup(mock => mock.GetUsersByPeriotIntAsync(It.IsAny<int>())).ReturnsAsync(new List<User>());

            // Act
            var result = await _accountService.GetUsersByPeriotAsync(periot);

            // Assert
            _userRepository.Verify(mock => mock.GetUsersByPeriotIntAsync(It.IsAny<int>()));
        }

        [Test]
        public async Task CanCallIsInRoleAsync()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue1846801868",
                RefreshToken = "TestValue380986633",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1754051289,
                Account = new Domain.Models.Models.Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1892195079",
                        FollowersCount = 1046260589,
                        NextStatusId = 1574097535,
                        UserTarget = 1169070404,
                        AccountId = 1861857327,
                        Account = default(Domain.Models.Models.Account)
                    },
                    Cread = "TestValue2106108912",
                    Photo = "TestValue1288196288",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Domain.Models.Models.Connection>(),
                    Messages = new List<Domain.Models.Models.Message>(),
                    Posts = new List<Domain.Models.Models.Post>(),
                    Comments = new List<Domain.Models.Models.Comment>(),
                    Likes = new List<Domain.Models.Models.Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Domain.Models.Models.Story>(),
                    UserId = 2116072816,
                    User = default(User)
                }
            };
            
            var roleName = "TestValue1846801868";

            // Act
            var result = await _accountService.IsInRoleAsync(user, roleName);

            // Assert
            Assert.AreEqual(roleName, user.RoleName);
        }

        [Test]
        public async Task CanCallRemoveAsync()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue1674725252",
                RefreshToken = "TestValue1558161129",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 426772244,
                Account = new Domain.Models.Models.Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1290364680",
                        FollowersCount = 1263005324,
                        NextStatusId = 2139520214,
                        UserTarget = 727193227,
                        AccountId = 724196548,
                        Account = default(Domain.Models.Models.Account)
                    },
                    Cread = "TestValue1345597445",
                    Photo = "TestValue1666735624",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Domain.Models.Models.Connection>(),
                    Messages = new List<Domain.Models.Models.Message>(),
                    Posts = new List<Domain.Models.Models.Post>(),
                    Comments = new List<Domain.Models.Models.Comment>(),
                    Likes = new List<Domain.Models.Models.Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Domain.Models.Models.Story>(),
                    UserId = 1535835321,
                    User = default(User)
                }
            };

            // Act
            await _accountService.RemoveAsync(user);

            // Assert
            _userManager.Verify(x => x.DeleteAsync(It.IsAny<User>()));
        }

        [Test]
        public async Task CanCallGetByAccountIdAsync()
        {
            // Arrange
            var accountId = 1368065085;

            _accountRepository.Setup(mock => mock.GetAccountAsync(It.IsAny<int>())).ReturnsAsync(new Domain.Models.Models.Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue775421104",
                    FollowersCount = 1430877993,
                    NextStatusId = 813272103,
                    UserTarget = 2085006469,
                    AccountId = 1516286829,
                    Account = default(Domain.Models.Models.Account)
                },
                Cread = "TestValue1887985237",
                Photo = "TestValue1155507931",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Domain.Models.Models.Connection>(),
                Messages = new List<Domain.Models.Models.Message>(),
                Posts = new List<Domain.Models.Models.Post>(),
                Comments = new List<Domain.Models.Models.Comment>(),
                Likes = new List<Domain.Models.Models.Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Domain.Models.Models.Story>(),
                UserId = 1220381399,
                User = new User
                {
                    RoleName = "TestValue123239030",
                    RefreshToken = "TestValue1204105741",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1608822418,
                    Account = default(Domain.Models.Models.Account)
                }
            });

            // Act
            var result = await _accountService.GetByAccountIdAsync(accountId);

            // Assert
            _accountRepository.Verify(mock => mock.GetAccountAsync(It.IsAny<int>()));
        }

        private Mock<UserManager<TUser>> GetUserManager<TUser>()
            where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var passwordHasher = new Mock<IPasswordHasher<TUser>>();
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
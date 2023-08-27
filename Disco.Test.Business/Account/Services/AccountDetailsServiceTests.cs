namespace Disco.Test.Business.Account.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Azure;
    using Azure.Storage.Blobs;
    using Azure.Storage.Blobs.Models;
    using Disco.Business.Exceptions;
    using Disco.Business.Services.Services;
    using Disco.Domain.Interfaces;
    using Disco.Domain.Models.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.IdentityModel.Tokens;
    using Moq;
    using Newtonsoft.Json;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class AccountDetailsServiceTests
    {
        private AccountDetailsService _testClass;
        private Mock<BlobClient> _blobClient;
        private Mock<BlobContainerClient> _blobContainerClient;
        private Mock<BlobServiceClient> _blobServiceClient;
        private Mock<IAccountRepository> _accountRepository;
        private Mock<IAccountStatusRepository> _accountStatusRepository;
        private Mock<IUserRepository> _userRepository;
        private Mock<IFollowerRepository> _followerRepository;

        [SetUp]
        public void SetUp()
        {
            _blobClient = new Mock<BlobClient>();
            _blobContainerClient = new Mock<BlobContainerClient>();
            _blobServiceClient = GetBlobServiceClientMock();
            _accountRepository = new Mock<IAccountRepository>();
            _accountStatusRepository = new Mock<IAccountStatusRepository>();
            _userRepository = new Mock<IUserRepository>();
            _followerRepository = new Mock<IFollowerRepository>();
            _testClass = new AccountDetailsService(_blobServiceClient.Object, _accountRepository.Object, _accountStatusRepository.Object, _userRepository.Object, _followerRepository.Object);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new AccountDetailsService(_blobServiceClient.Object, _accountRepository.Object, _accountStatusRepository.Object, _userRepository.Object, _followerRepository.Object);

            // Assert
            Assert.IsNotNull(instance);
        }

        [Test]
        public async Task CanCallChengePhotoAsync()
        {
            // Arrange
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(content);
            writer.Flush();
            stream.Position = 0;

            var file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            _blobServiceClient = GetBlobServiceClientMock();

            var user = new User
            {
                RoleName = "TestValue2043154539",
                RefreshToken = "TestValue252214469",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1872204343,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue510575976",
                        FollowersCount = 1799624147,
                        NextStatusId = 1641437183,
                        UserTarget = 196211603,
                        AccountId = 439033017,
                        Account = default
                    },
                    Cread = "TestValue1031923441",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1761833180,
                    User = default
                }
            };

            _accountRepository.Setup(mock => mock.Update(It.IsAny<Account>())).ReturnsAsync(new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue679379272",
                    FollowersCount = 113423693,
                    NextStatusId = 662389794,
                    UserTarget = 1540693077,
                    AccountId = 209413324,
                    Account = default
                },
                Cread = "TestValue1140360038",
                Photo = "TestValue2093470782",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 1005245294,
                User = new User
                {
                    RoleName = "TestValue849075083",
                    RefreshToken = "TestValue911136752",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1521188696,
                    Account = default
                }
            });

            // Act
            var result = await _testClass.ChengePhotoAsync(user, file);

            // Assert
            _accountRepository.Verify(mock => mock.Update(It.IsAny<Account>()));
        }

        [Test]
        public void CannotCallChengePhotoAsyncWithNullUser()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.ChengePhotoAsync(default, new Mock<IFormFile>().Object));
        }

        [Test]
        public async Task CanCallGetAccountsByNameAsync()
        {
            // Arrange
            var search = "TestValue1176713197";

            _accountRepository.Setup(mock => mock.FindAccountsByUserNameAsync(It.IsAny<string>())).ReturnsAsync(new List<Account>());
            _accountRepository.Setup(mock => mock.GetAccountAsync(It.IsAny<int>())).ReturnsAsync(new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue173198972",
                    FollowersCount = 435803439,
                    NextStatusId = 425218075,
                    UserTarget = 637104474,
                    AccountId = 311077626,
                    Account = default
                },
                Cread = "TestValue1681425060",
                Photo = "TestValue1831883078",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 158465633,
                User = new User
                {
                    RoleName = "TestValue208338651",
                    RefreshToken = "TestValue1462922771",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 509576289,
                    Account = default
                }
            });

            // Act
            var result = await _testClass.GetAccountsByNameAsync(search);

            // Assert
            _accountRepository.Verify(mock => mock.FindAccountsByUserNameAsync(It.IsAny<string>()));
            _accountRepository.Verify(mock => mock.GetAccountAsync(It.IsAny<int>()), Times.Never());
        }

        [TestCase(null)]
        [TestCase("")]
        public void CannotCallGetAccountsByNameAsyncWithInvalidSearch(string value)
        {
            if (value == null)
                Assert.IsNull(value);
            else if (value == "")
                Assert.IsEmpty(value);
        }

        [Test]
        public async Task CanCallRemoveAsync()
        {
            // Arrange
            var account = new Account
            {
                AccountStatus = new AccountStatus
                {
                    LastStatus = "TestValue2064513061",
                    FollowersCount = 1458472892,
                    NextStatusId = 1086435813,
                    UserTarget = 830597132,
                    AccountId = 1470853626,
                    Account = default
                },
                Cread = "TestValue109291029",
                Photo = "TestValue474921224",
                AccountGroups = new List<AccountGroup>(),
                Connections = new List<Connection>(),
                Messages = new List<Message>(),
                Posts = new List<Post>(),
                Comments = new List<Comment>(),
                Likes = new List<Like>(),
                Followers = new List<UserFollower>(),
                Following = new List<UserFollower>(),
                Stories = new List<Story>(),
                UserId = 1896098893,
                User = new User
                {
                    RoleName = "TestValue1803792917",
                    RefreshToken = "TestValue1510113166",
                    RefreshTokenExpiress = DateTime.UtcNow,
                    DateOfRegister = DateTime.UtcNow,
                    AccountId = 1065029739,
                    Account = default
                }
            };

            _accountRepository.Setup(mock => mock.RemoveAccountAsync(It.IsAny<Account>())).Verifiable();

            // Act
            await _testClass.RemoveAsync(account);

            // Assert
            _accountRepository.Verify(mock => mock.RemoveAccountAsync(It.IsAny<Account>()));
        }

        [Test]
        public void CannotCallRemoveAsyncWithNullAccount()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.RemoveAsync(default));
        }

        [Test]
        public async Task CanCallGetUserDatailsAsync()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue79015497",
                RefreshToken = "TestValue1436400904",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 85357901,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1162519673",
                        FollowersCount = 1330359557,
                        NextStatusId = 662270190,
                        UserTarget = 754633586,
                        AccountId = 873457808,
                        Account = default
                    },
                    Cread = "TestValue1124973238",
                    Photo = "TestValue298910409",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 356518556,
                    User = default
                }
            };

            _accountStatusRepository.Setup(mock => mock.GetStatusByFollowersCountAsync(It.IsAny<int>())).ReturnsAsync(new AccountStatus
            {
                LastStatus = "TestValue1394812495",
                FollowersCount = 272928546,
                NextStatusId = 490049574,
                UserTarget = 1280143374,
                AccountId = 2106771094,
                Account = new Account
                {
                    AccountStatus = default,
                    Cread = "TestValue1073818",
                    Photo = "TestValue1066417850",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 180276731,
                    User = new User
                    {
                        RoleName = "TestValue1682962936",
                        RefreshToken = "TestValue67056207",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 87857748,
                        Account = default
                    }
                }
            });

            // Act
            var result = await _testClass.GetUserDatailsAsync(user);

            // Assert
            _accountStatusRepository.Verify(mock => mock.GetStatusByFollowersCountAsync(It.IsAny<int>()));
        }

        [Test]
        public void CannotCallGetUserDatailsAsyncWithNullUser()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.GetUserDatailsAsync(default));
        }

        [Test]
        public async Task GetUserDatailsAsyncPerformsMapping()
        {
            // Arrange
            var user = new User
            {
                RoleName = "TestValue1360231698",
                RefreshToken = "TestValue1133614089",
                RefreshTokenExpiress = DateTime.UtcNow,
                DateOfRegister = DateTime.UtcNow,
                AccountId = 1765764351,
                Account = new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue94636778",
                        FollowersCount = 1261799832,
                        NextStatusId = 615457465,
                        UserTarget = 559507323,
                        AccountId = 900736239,
                        Account = default
                    },
                    Cread = "TestValue1705517243",
                    Photo = "TestValue151503874",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 810569453,
                    User = default
                }
            };

            // Act
            var result = await _testClass.GetUserDatailsAsync(user);

            // Assert
            Assert.That(result.User, Is.SameAs(user));
        }

        [Test]
        public async Task CanCallGetAllAsync()
        {
            // Arrange
            var pageNumber = 1415929691;
            var pageSize = 2065627204;

            _accountRepository.Setup(mock => mock.GetAllAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new[] {
                new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1518257347",
                        FollowersCount = 1177889227,
                        NextStatusId = 364175928,
                        UserTarget = 1968511699,
                        AccountId = 401281686,
                        Account = default
                    },
                    Cread = "TestValue1872595631",
                    Photo = "TestValue157391815",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1289404448,
                    User = new User
                    {
                        RoleName = "TestValue1282646040",
                        RefreshToken = "TestValue974097000",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 1109656990,
                        Account = default
                    }
                },
                new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1976655313",
                        FollowersCount = 1379457395,
                        NextStatusId = 1797518556,
                        UserTarget = 745239231,
                        AccountId = 308333953,
                        Account = default
                    },
                    Cread = "TestValue926415119",
                    Photo = "TestValue1960134681",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1141465307,
                    User = new User
                    {
                        RoleName = "TestValue930335109",
                        RefreshToken = "TestValue385139928",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 766119330,
                        Account = default
                    }
                },
                new Account
                {
                    AccountStatus = new AccountStatus
                    {
                        LastStatus = "TestValue1038293939",
                        FollowersCount = 1060180495,
                        NextStatusId = 1503919132,
                        UserTarget = 1661862669,
                        AccountId = 2012134316,
                        Account = default
                    },
                    Cread = "TestValue886757633",
                    Photo = "TestValue450960385",
                    AccountGroups = new List<AccountGroup>(),
                    Connections = new List<Connection>(),
                    Messages = new List<Message>(),
                    Posts = new List<Post>(),
                    Comments = new List<Comment>(),
                    Likes = new List<Like>(),
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>(),
                    Stories = new List<Story>(),
                    UserId = 1768253055,
                    User = new User
                    {
                        RoleName = "TestValue782226697",
                        RefreshToken = "TestValue509022611",
                        RefreshTokenExpiress = DateTime.UtcNow,
                        DateOfRegister = DateTime.UtcNow,
                        AccountId = 2083837521,
                        Account = default
                    }
                }
            });

            // Act
            var result = await _testClass.GetAllAsync(pageNumber, pageSize);

            // Assert
            _accountRepository.Verify(mock => mock.GetAllAsync(It.IsAny<int>(), It.IsAny<int>()));
        }

        private Mock<BlobServiceClient> GetBlobServiceClientMock()
        {
            var mock = new Mock<BlobServiceClient>();
            var mockBlobContainerClient = new Mock<BlobContainerClient>();
            var mockBlobClient = new Mock<BlobClient>();

            var uri = new Uri("https://blablabla.com");

            mockBlobContainerClient.Setup(i => i.AccountName)
                .Returns("Test account name");
            mock.Setup(x => x.GetBlobContainerClient(It.IsAny<string>()))
                .Returns(mockBlobContainerClient.Object);
            mockBlobContainerClient.Setup(x => x.GetBlobClient(It.IsAny<string>()))
                .Returns(mockBlobClient.Object);
            mockBlobClient.Setup(x => x.Uri)
                .Returns(uri);

            return mock;
        }
    }
}
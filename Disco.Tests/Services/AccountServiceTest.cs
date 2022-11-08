using Disco.Business.Services;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Disco.Domain.Repositories;
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
    public class AccountServiceTest
    {
        [TestMethod]
        public async Task GetByEmailAsync_ReturnsUserResponse()
        {
            var list = new List<User>()
            {
                new User {UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {UserName = "stacy_design", Email = "nastya.n.gavrish@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {UserName = "petya_pupkin", Email = "p.pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {UserName = "dmitry_chumak", Email = "chumak@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {UserName = "s.korchevskyi", Email = "skorchevskyi@zeushq.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
            };

            var mockedUserManager = Mock.MockedUserManager.MockUserManager<User>(list);
            mockedUserManager.Setup(u => u.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(new User
                {
                    UserName = "vasya_pupkin",
                    Email = "vasya_pupkin@gmail.com",
                    DateOfRegister = DateTime.Now,
                    Account = new Account() { Followers = new List<UserFollower>() }
                });


            var mockedUserRepository = new Mock<IUserRepository>();
            mockedUserRepository.Setup(x => x.GetUserInfosAsync(It.IsAny<User>()))
                .Returns(Task.FromResult(mockedUserRepository.Object));

            var mockedUserStatausRepository = new Mock<IAccountStatusRepository>();
            mockedUserStatausRepository.Setup(s => s.GetStatusByFollowersCountAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(It.IsAny<AccountStatus>()));

            var accountService = new AccountService(mockedUserManager.Object, mockedUserRepository.Object, mockedUserStatausRepository.Object);
            var response = await accountService.GetByEmailAsync("vasya_pupkin@gmail.com");

            Assert.AreEqual(response.Email, "vasya_pupkin@gmail.com");
            Assert.AreEqual(response.UserName, "vasya_pupkin");
        }
        
        [TestMethod]
        public async Task GetByEmailAsync_ReturnsNullResponse()
        {
            var list = new List<User>()
            {
                new User {UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {UserName = "stacy_design", Email = "nastya.n.gavrish@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {UserName = "petya_pupkin", Email = "p.pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {UserName = "dmitry_chumak", Email = "chumak@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {UserName = "s.korchevskyi", Email = "skorchevskyi@zeushq.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
            };

            var mockedUserManager = Mock.MockedUserManager.MockUserManager<User>(list);

            var mockedUserRepository = new Mock<IUserRepository>();
            mockedUserRepository.Setup(x => x.GetUserInfosAsync(It.IsAny<User>()))
                .Returns(Task.FromResult(mockedUserRepository.Object));

            var mockedUserStatausRepository = new Mock<IAccountStatusRepository>();
            mockedUserStatausRepository.Setup(s => s.GetStatusByFollowersCountAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(It.IsAny<AccountStatus>()));

            var accountService = new AccountService(mockedUserManager.Object, mockedUserRepository.Object, mockedUserStatausRepository.Object);
            var response = await accountService.GetByEmailAsync("lusha@gmail.com");

            Assert.IsNull(response);
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnsUserResponse()
        {
            var list = new List<User>()
            {
                new User {Id = 1, UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 2, UserName = "stacy_design", Email = "nastya.n.gavrish@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 3, UserName = "petya_pupkin", Email = "p.pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 4, UserName = "dmitry_chumak", Email = "chumak@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 5, UserName = "s.korchevskyi", Email = "skorchevskyi@zeushq.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
            };

            var mockedUserManager = Mock.MockedUserManager.MockUserManager<User>(list);
            mockedUserManager.Setup(s => s.FindByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(new User { Id = 1, UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>() } });

            var mockedUserRepository = new Mock<IUserRepository>();
            mockedUserRepository.Setup(x => x.GetUserInfosAsync(It.IsAny<User>()))
                .Returns(Task.FromResult(mockedUserRepository.Object));

            var mockedUserStatausRepository = new Mock<IAccountStatusRepository>();
            mockedUserStatausRepository.Setup(s => s.GetStatusByFollowersCountAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(It.IsAny<AccountStatus>()));

            var accountService = new AccountService(mockedUserManager.Object, mockedUserRepository.Object, mockedUserStatausRepository.Object);
            var response = await accountService.GetByIdAsync(1);

            Assert.IsNotNull(response);
            Assert.AreEqual(response, response);
            Assert.IsNotNull(response.Account);
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnsNullResponse()
        {
            var list = new List<User>()
            {
                new User {Id = 1, UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 2, UserName = "stacy_design", Email = "nastya.n.gavrish@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 3, UserName = "petya_pupkin", Email = "p.pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 4, UserName = "dmitry_chumak", Email = "chumak@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 5, UserName = "s.korchevskyi", Email = "skorchevskyi@zeushq.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
            };

            var mockedUserManager = Mock.MockedUserManager.MockUserManager<User>(list);
            mockedUserManager.Setup(s => s.FindByIdAsync(It.IsAny<int>().ToString()))
                .ReturnsAsync(new User { Id = 1, UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>() } });

            var mockedUserRepository = new Mock<IUserRepository>();
            mockedUserRepository.Setup(x => x.GetUserInfosAsync(It.IsAny<User>()))
                .Returns(Task.FromResult(mockedUserRepository.Object));

            var mockedUserStatausRepository = new Mock<IAccountStatusRepository>();
            mockedUserStatausRepository.Setup(s => s.GetStatusByFollowersCountAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(It.IsAny<AccountStatus>()));

            var accountService = new AccountService(mockedUserManager.Object, mockedUserRepository.Object, mockedUserStatausRepository.Object);
            var response = await accountService.GetByIdAsync(20);

            Assert.IsNull(response);
        }

        [TestMethod]
        public async Task GetByNameAsync_ReturnsUserResponse()
        {
            var list = new List<User>()
            {
                new User {Id = 1, UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 2, UserName = "stacy_design", Email = "nastya.n.gavrish@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 3, UserName = "petya_pupkin", Email = "p.pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 4, UserName = "dmitry_chumak", Email = "chumak@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 5, UserName = "s.korchevskyi", Email = "skorchevskyi@zeushq.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
            };

            var mockedUserManager = Mock.MockedUserManager.MockUserManager<User>(list);
            mockedUserManager.Setup(s => s.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(new User { Id = 1, UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>() } });

            var mockedUserRepository = new Mock<IUserRepository>();
            mockedUserRepository.Setup(x => x.GetUserInfosAsync(It.IsAny<User>()))
                .Returns(Task.FromResult(mockedUserRepository.Object));

            var mockedUserStatausRepository = new Mock<IAccountStatusRepository>();
            mockedUserStatausRepository.Setup(s => s.GetStatusByFollowersCountAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(It.IsAny<AccountStatus>()));

            var accountService = new AccountService(mockedUserManager.Object, mockedUserRepository.Object, mockedUserStatausRepository.Object);
            var response = await accountService.GetByNameAsync("vasya_pupkin");

            Assert.IsNotNull(response);
            Assert.AreEqual(response, response);
            Assert.IsNotNull(response.Account);
        }

        [TestMethod]
        public async Task GetByNameAsync_ReturnsNullResponse()
        {
            var list = new List<User>()
            {
                new User {Id = 1, UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 2, UserName = "stacy_design", Email = "nastya.n.gavrish@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 3, UserName = "petya_pupkin", Email = "p.pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 4, UserName = "dmitry_chumak", Email = "chumak@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 5, UserName = "s.korchevskyi", Email = "skorchevskyi@zeushq.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
            };

            var mockedUserManager = Mock.MockedUserManager.MockUserManager<User>(list);
            mockedUserManager.Setup(s => s.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(It.IsAny<User>());

            var mockedUserRepository = new Mock<IUserRepository>();
            mockedUserRepository.Setup(x => x.GetUserInfosAsync(It.IsAny<User>()))
                .Returns(Task.FromResult(mockedUserRepository.Object));

            var mockedUserStatausRepository = new Mock<IAccountStatusRepository>();
            mockedUserStatausRepository.Setup(s => s.GetStatusByFollowersCountAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(It.IsAny<AccountStatus>()));

            var accountService = new AccountService(mockedUserManager.Object, mockedUserRepository.Object, mockedUserStatausRepository.Object);
            var response = await accountService.GetByNameAsync("Lusha");

            Assert.IsNull(response);
        }

        [TestMethod]
        public async Task GetByLoginProviderAsync_ReturnsUserResponse()
        {
            var list = new List<User>()
            {
                new User {Id = 1, UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 2, UserName = "stacy_design", Email = "nastya.n.gavrish@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 3, UserName = "petya_pupkin", Email = "p.pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 4, UserName = "dmitry_chumak", Email = "chumak@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 5, UserName = "s.korchevskyi", Email = "skorchevskyi@zeushq.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
            };

            var mockedUserManager = Mock.MockedUserManager.MockUserManager<User>(list);
            mockedUserManager.Setup(s => s.FindByLoginAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new User { Id = 1, UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>() } });

            var mockedUserRepository = new Mock<IUserRepository>();
            mockedUserRepository.Setup(x => x.GetUserInfosAsync(It.IsAny<User>()))
                .Returns(Task.FromResult(mockedUserRepository.Object));

            var mockedUserStatausRepository = new Mock<IAccountStatusRepository>();
            mockedUserStatausRepository.Setup(s => s.GetStatusByFollowersCountAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(It.IsAny<AccountStatus>()));

            var accountService = new AccountService(mockedUserManager.Object, mockedUserRepository.Object, mockedUserStatausRepository.Object);
            var response = await accountService.GetByLogInProviderAsync("Google", Guid.NewGuid().ToString());

            Assert.IsNotNull(response);
            Assert.AreEqual(response, response);
            Assert.IsNotNull(response.Account);
        }

        [TestMethod]
        public async Task GetByLoginProviderAsync_ReturnsNullResponse()
        {
            var list = new List<User>()
            {
                new User {Id = 1, UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 2, UserName = "stacy_design", Email = "nastya.n.gavrish@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 3, UserName = "petya_pupkin", Email = "p.pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 4, UserName = "dmitry_chumak", Email = "chumak@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 5, UserName = "s.korchevskyi", Email = "skorchevskyi@zeushq.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
            };

            var mockedUserManager = Mock.MockedUserManager.MockUserManager<User>(list);
            mockedUserManager.Setup(s => s.FindByLoginAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(It.IsAny<User>());

            var mockedUserRepository = new Mock<IUserRepository>();
            mockedUserRepository.Setup(x => x.GetUserInfosAsync(It.IsAny<User>()))
                .Returns(Task.FromResult(mockedUserRepository.Object));

            var mockedUserStatausRepository = new Mock<IAccountStatusRepository>();
            mockedUserStatausRepository.Setup(s => s.GetStatusByFollowersCountAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(It.IsAny<AccountStatus>()));

            var accountService = new AccountService(mockedUserManager.Object, mockedUserRepository.Object, mockedUserStatausRepository.Object);
            var response = await accountService.GetByLogInProviderAsync("Google", Guid.NewGuid().ToString());

            Assert.IsNull(response);
        }

        [TestMethod]
        public async Task CreateAsync_ReturnsUserResponse()
        {
            var user = new User
            {
                UserName = "Lusha",
                Email = "lusha@gmail.com",
                Account = new Account
                {
                    Followers = new List<UserFollower>()
                }
            };

            var list = new List<User>()
            {
                new User {Id = 1, UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 2, UserName = "stacy_design", Email = "nastya.n.gavrish@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 3, UserName = "petya_pupkin", Email = "p.pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 4, UserName = "dmitry_chumak", Email = "chumak@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 5, UserName = "s.korchevskyi", Email = "skorchevskyi@zeushq.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
            };

            var mockedUserManager = MockedUserManager.MockUserManager<User>(list);
            mockedUserManager.Setup(u => u.NormalizeName(It.IsAny<string>()))
                .Returns("LULU_DOG");
            mockedUserManager.Setup(u => u.NormalizeEmail(It.IsAny<string>()))
                .Returns("LULU_DOG@GMAIL.COM");

            var mockedUserRepository = new Mock<IUserRepository>();
            mockedUserRepository.Setup(x => x.GetUserInfosAsync(It.IsAny<User>()))
                .Returns(Task.FromResult(mockedUserRepository.Object));
            
            var mockedUserStatausRepository = new Mock<IAccountStatusRepository>();
            mockedUserStatausRepository.Setup(s => s.GetStatusByFollowersCountAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(It.IsAny<AccountStatus>()));

            var service = new AccountService(mockedUserManager.Object, mockedUserRepository.Object, mockedUserStatausRepository.Object);
            var response = service.CreateAsync(user);

            Assert.AreEqual(response.IsCompletedSuccessfully, true);
        }

        [TestMethod]
        public void CreateAsync_re()
        {
            var user = new User
            {
                UserName = "Lusha",
                Email = "lusha@gmail.com",
                Account = new Account
                {
                    Followers = new List<UserFollower>()
                }
            };

            var list = new List<User>()
            {
                new User {Id = 1, UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 2, UserName = "stacy_design", Email = "vasya_pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 3, UserName = "petya_pupkin", Email = "p.pupkin@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 4, UserName = "dmitry_chumak", Email = "chumak@gmail.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
                new User {Id = 5, UserName = "s.korchevskyi", Email = "skorchevskyi@zeushq.com", DateOfRegister = DateTime.Now, Account = new Account() { Followers = new List<UserFollower>()} },
            };

            var mockedUserManager = MockedUserManager.MockUserManager<User>(list);
            mockedUserManager.Setup(u => u.NormalizeName(It.IsAny<string>()))
                .Returns("LULU_DOG");
            mockedUserManager.Setup(u => u.NormalizeEmail(It.IsAny<string>()))
                .Returns("LULU_DOG@GMAIL.COM");

            var mockedUserRepository = new Mock<IUserRepository>();
            mockedUserRepository.Setup(x => x.GetUserInfosAsync(It.IsAny<User>()))
                .Returns(Task.FromResult(mockedUserRepository.Object));

            var mockedUserStatausRepository = new Mock<IAccountStatusRepository>();
            mockedUserStatausRepository.Setup(s => s.GetStatusByFollowersCountAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(It.IsAny<AccountStatus>()));

            var service = new AccountService(mockedUserManager.Object, mockedUserRepository.Object, mockedUserStatausRepository.Object);
            var response = service.CreateAsync(user);

            Assert.ThrowsException<Exception>(() => response.Exception);
        }
    }
}

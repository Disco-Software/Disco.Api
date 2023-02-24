using AutoMapper;
using Disco.Business.Mapper;
using Disco.Business.Services;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.Tests.Services
{
    [TestClass]
    public class GroupServiceTest
    {
        [TestMethod]
        public async Task CreateAsync_ReturnsSuccessResponse()
        {
            var accounts = new List<Account>
            {
                new Account
                {
                    User = new User
                    {
                        UserName = "vasya",
                        Email = "pupkin@gmail.com"
                    },

                   AccountGroups = new List<AccountGroup>
                   {
                   }
                },
                new Account
                {
                    AccountGroups = new List<AccountGroup>(),
                    User = new User
                    {
                        UserName = "stas",
                        Email = "stats@gmail.com",
                    }
                }
            };

            var accountGroups = new List<AccountGroup>
            {
                new AccountGroup {Account = accounts.First(), AccountId = accounts.First().Id},
                new AccountGroup {Account = accounts.Last(), AccountId = accounts.Last().Id},
            };

            var group = new Group
            {
                AccountGroups = accountGroups,
                Messages = new List<Message>(),
                Id = 1,
                Name = Guid.NewGuid().ToString(),
            };

            var mockedRepository = new Mock<IGroupRepository>();
            mockedRepository.Setup(r => r.CreateAsync(It.IsAny<Group>(), CancellationToken.None))
                .Returns(Task.FromResult(group));

            var mockedAccountRepository = new Mock<IAccountRepository>();
            mockedAccountRepository.Setup(accountRepository => accountRepository.GetAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(It.IsAny<Account>()));

            var mockedAccountGroupRepository = new Mock<IAccountGroupRepository>();
            mockedAccountGroupRepository.Setup(m => m.CreateAsync(It.IsAny<AccountGroup>()))
                .Returns(Task.CompletedTask);

            var mapper = new MapperConfiguration(options =>
            {
                options.AddProfile(new GroupMapProfile());
            }).CreateMapper();

            var groupService = new GroupService(mockedRepository.Object, mockedAccountGroupRepository.Object, mockedAccountRepository.Object, mapper);
            var response = await groupService.CreateAsync();

            Assert.IsNotNull(response);
        }
    }
}

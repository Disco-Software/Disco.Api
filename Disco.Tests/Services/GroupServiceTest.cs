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

            var group = new Group
            {
                AccountGroups = new List<AccountGroup>(),
                Accounts = new List<Account>(),
                Messages = new List<Message>(),
                Id = 1,
                Name = Guid.NewGuid().ToString(),
            };

            var mockedRepository = new Mock<IGroupRepository>();
            mockedRepository.Setup(r => r.CreateAsync(It.IsAny<Group>(), CancellationToken.None))
                .Returns(Task.FromResult(group));

            var mockedAccountGroupRepository = new Mock<IAccountGroupRepository>();
            mockedAccountGroupRepository.Setup(m => m.CreateAsync(It.IsAny<AccountGroup>()))
                .Returns(Task.CompletedTask);

            var mapper = new MapperConfiguration(options =>
            {
                options.AddProfile(new GroupMapProfile());
            }).CreateMapper();

            var groupService = new GroupService(mockedRepository.Object, mockedAccountGroupRepository.Object, mapper);
            var response = await groupService.CreateAsync(accounts.First(), accounts.Last());

            Assert.IsNotNull(response);
        }
    }
}

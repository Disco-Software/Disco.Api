using AutoMapper;
using Disco.Business.Services.Mappers;
using Disco.Business.Services.Services;
using Disco.Domain.Interfaces;
using Disco.Domain.Migrations;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Disco.Tests.Services
{
    [TestClass]
    public class MessageServiceTest
    {
        [TestMethod]
        public async Task CreateAsync_ReturnsSuccessResponse()
        {
            var account = new Account
            {
                Id = 1,
                User = new User
                {
                    UserName = "vasyaPupkin"
                }
            };

            var group = new Group
            {
                Name = Guid.NewGuid().ToString(),
                Messages = new List<Message>(),
                Id = 1,
            };

            var mockedRepository = new Mock<IMessageRepository>();
            mockedRepository.Setup(x => x.CreateAsync(It.IsAny<Message>(), CancellationToken.None))
                .Returns(Task.FromResult(new Message()));

            var mapperConfig = new MapperConfiguration(options =>
            options.AddProfile(new MessageMapProfile()));

            var mapper = mapperConfig.CreateMapper();

            var messageService = new MessageService(mockedRepository.Object, mapper);
            var result = await messageService.CreateAsync("post is so cool", account, group);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Description, "post is so cool");
        }

        [TestMethod]
        public async Task DeleteAsync_ReturnsSuccessResponse()
        {
            var account = new Account
            {
                Messages = new List<Message>(),
                Id = 1,
                User = new User
                {
                    UserName = "vasyaPupkin"
                }
            };

            var group = new Group
            {
                Name = Guid.NewGuid().ToString(),
                Messages = new List<Message>(),
                Id = 1,
            };

            var message = new Message
            {
                Account = account,
                AccountId = account.Id,
                CreatedDate = DateTime.Now.AddDays(-3),
                Description = "This is post is cool"
            };

            group.Messages.Add(message);

            var mockedRepository = new Mock<IMessageRepository>();
            mockedRepository.Setup(m => m.DeleteAsync(It.IsAny<Message>(), CancellationToken.None))
                .Returns(Task.FromResult(true));

            var service = new MessageService(mockedRepository.Object, null);
            var result = service.DeleteAsync(message);

            Assert.IsTrue(result.IsCompleted);
        }

        [TestMethod]
        public async Task GetAllAsync_ReturnsListResponse()
        {
            var accounts = new List<Account>()
            {
                new Account()
                {
                    User = new User
                    {
                        UserName = "Vasya",
                        Email = "vasya@gmail.com",
                        Id = 1
                    },

                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>(),
                },
                new Account()
                {
                    User = new User
                    {
                        UserName = "Vasiliya",
                        Email = "vasiliya@gmail.com",
                        Id = 2
                    },

                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>(),
                }
            };

            var group = new Group
            {
                Name = Guid.NewGuid().ToString(),
                Id = 1,
            };

            var accountGroups = new List<AccountGroup>()
            {
                new AccountGroup{Account = accounts.Last(), AccountId = accounts.Last().Id, Group = group, GroupId = group.Id},
                new AccountGroup{Account = accounts.First(), AccountId = accounts.First().Id, Group = group, GroupId = group.Id},
            };


            var list = new List<Message>()
            {
                new Message() {Group = group, Account = accounts.First(), AccountId = accounts.First().Id, Description = "vasya pupkin!", CreatedDate = DateTime.Now.AddDays(-3), GroupId = group.Id, Id = 1},
                new Message() {Group = group, Account = accounts.First(), AccountId = accounts.First().Id, Description = "vasya pupkin!", CreatedDate = DateTime.Now.AddDays(-3), GroupId = group.Id, Id = 1},
                new Message() {Group = group, Account = accounts.First(), AccountId = accounts.First().Id, Description = "vasya pupkin!", CreatedDate = DateTime.Now.AddDays(-3), GroupId = group.Id, Id = 1},
            };

            var mockedRepository = new Mock<IMessageRepository>();
            mockedRepository.Setup(x => x.GetAllAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(Task.FromResult(list));

            var messageService = new MessageService(mockedRepository.Object, null);
            var messages = await messageService.GetAllAsync(1, 1, 3);

            Assert.AreNotEqual(0, messages.Count);
            Assert.AreEqual(messages.Count, 3);
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnsSuccessResponse()
        {
            var accounts = new List<Account>()
            {
                new Account()
                {
                    User = new User
                    {
                        UserName = "Vasya",
                        Email = "vasya@gmail.com",
                        Id = 1
                    },

                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>(),
                },
                new Account()
                {
                    User = new User
                    {
                        UserName = "Vasiliya",
                        Email = "vasiliya@gmail.com",
                        Id = 2
                    },

                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>(),
                }
            };

            var group = new Group
            {
                Name = Guid.NewGuid().ToString(),
                Id = 1,
            };

            var accountGroups = new List<AccountGroup>()
            {
                new AccountGroup{Account = accounts.Last(), AccountId = accounts.Last().Id, Group = group, GroupId = group.Id},
                new AccountGroup{Account = accounts.First(), AccountId = accounts.First().Id, Group = group, GroupId = group.Id},
            };


            var list = new List<Message>()
            {
                new Message() {Group = group, Account = accounts.First(), AccountId = accounts.First().Id, Description = "vasya pupkin!", CreatedDate = DateTime.Now.AddDays(-3), GroupId = group.Id, Id = 1},
                new Message() {Group = group, Account = accounts.First(), AccountId = accounts.First().Id, Description = "vasya pupkin!", CreatedDate = DateTime.Now.AddDays(-3), GroupId = group.Id, Id = 1},
                new Message() {Group = group, Account = accounts.First(), AccountId = accounts.First().Id, Description = "vasya pupkin!", CreatedDate = DateTime.Now.AddDays(-3), GroupId = group.Id, Id = 1},
            };

            var mockedRepository = new Mock<IMessageRepository>();
            mockedRepository.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(list.FirstOrDefault()));

            var messageService = new MessageService(mockedRepository.Object, null);
            var response = await messageService.GetByIdAsync(1);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task UpdateAsync_ReturnsSuccessResponse()
        {
            var accounts = new List<Account>()
            {
                new Account()
                {
                    User = new User
                    {
                        UserName = "Vasya",
                        Email = "vasya@gmail.com",
                        Id = 1
                    },

                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>(),
                },
                new Account()
                {
                    User = new User
                    {
                        UserName = "Vasiliya",
                        Email = "vasiliya@gmail.com",
                        Id = 2
                    },

                    Messages = new List<Message>(),
                    AccountGroups = new List<AccountGroup>(),
                }
            };

            var group = new Group
            {
                Name = Guid.NewGuid().ToString(),
                Id = 1,
            };

            var accountGroups = new List<AccountGroup>()
            {
                new AccountGroup{Account = accounts.Last(), AccountId = accounts.Last().Id, Group = group, GroupId = group.Id},
                new AccountGroup{Account = accounts.First(), AccountId = accounts.First().Id, Group = group, GroupId = group.Id},
            };


            var list = new List<Message>()
            {
                new Message() {Group = group, Account = accounts.First(), AccountId = accounts.First().Id, Description = "vasya pupkin!", CreatedDate = DateTime.Now.AddDays(-3), GroupId = group.Id, Id = 1},
                new Message() {Group = group, Account = accounts.First(), AccountId = accounts.First().Id, Description = "vasya pupkin!", CreatedDate = DateTime.Now.AddDays(-3), GroupId = group.Id, Id = 1},
                new Message() {Group = group, Account = accounts.First(), AccountId = accounts.First().Id, Description = "vasya pupkin!", CreatedDate = DateTime.Now.AddDays(-3), GroupId = group.Id, Id = 1},
            };

            var message = new Message
            {
                Account = accounts.First(),
                AccountId = accounts.First().Id,
                CreatedDate = DateTime.Now,
                Description = "vasya_pupkin1",
                Group = group,
                GroupId = group.Id,
                Id = 4
            };

            var mockedRepository = new Mock<IMessageRepository>();
            mockedRepository.Setup(m => m.UpdateAsync(It.IsAny<Message>(), CancellationToken.None))
                .Returns(Task.FromResult(list.FirstOrDefault()));

            var messageService = new MessageService(mockedRepository.Object, null);
            var response = messageService.UpdateAsync(message);

            Assert.IsTrue(response.IsCompletedSuccessfully);
        }
    }
}
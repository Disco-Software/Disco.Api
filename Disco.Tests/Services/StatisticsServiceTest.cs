using Disco.Business.Services.Services;
using Disco.Domain.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Domain.Repositories.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Tests.Services
{
    [TestClass]
    public class StatisticsServiceTest
    {
        [TestMethod]
        public async Task GetRegisteredUsersDayAsync_ReturnsSuccssResponse()
        {
            var users = new List<User>
            {
                new User{UserName = "vasya", Email="vasya.p@gmail.com", DateOfRegister = DateTime.Now.AddDays(-30)},
                new User{UserName = "stasya", Email="nastya.n.gavrish@gmail.com", DateOfRegister= DateTime.Now.AddDays(-10)},
                new User{UserName = "dima", Email="dmitry.korchevskyi@gmail.com", DateOfRegister= DateTime.Now.AddDays(-29)},
                new User{UserName = "eva", Email="eva.korchevska@gmail.com", DateOfRegister= DateTime.Now.AddDays(-40)},
            };

            var mockedUserRepository = new Mock<IUserRepository>();
            mockedUserRepository.Setup(userRepository => userRepository.GetUsersByPeriotIntAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(users.OrderByDescending(user => user.DateOfRegister).Where(user => user.DateOfRegister > DateTime.UtcNow.AddDays(-30)).ToList()));

            var statisticsService = new StatisticsService(mockedUserRepository.Object);
            var response = await statisticsService.GetRegistredUsersDayAsync(-30);

            Assert.IsNotNull(response);
            Assert.AreEqual(3, response.Count);
        }

        [TestMethod]
        public async Task GetRegistredUsersAsync_ReturnsSuccessResponse()
        {
            var users = new List<User>
            {
                new User{UserName = "vasya", Email="vasya.p@gmail.com", DateOfRegister = DateTime.Now.AddDays(-30)},
                new User{UserName = "stasya", Email="nastya.n.gavrish@gmail.com", DateOfRegister= DateTime.Now.AddDays(-10)},
                new User{UserName = "dima", Email="dmitry.korchevskyi@gmail.com", DateOfRegister= DateTime.Now.AddDays(-29)},
                new User{UserName = "eva", Email="eva.korchevska@gmail.com", DateOfRegister= DateTime.Now.AddDays(-40)},
            };

            var mockedUserRepository = new Mock<IUserRepository>();
            mockedUserRepository.Setup(userRepository => userRepository.GetUsersByPeriotAsync(It.IsAny<DateTime>()))
                .Returns(Task.FromResult(users.OrderByDescending(user => user.DateOfRegister).Where(user => user.DateOfRegister > DateTime.UtcNow.AddDays(-30)).ToList()));

            var statisticsService = new StatisticsService(mockedUserRepository.Object);
            var response = await statisticsService.GetRegistredUsersAsync(DateTime.Now.AddDays(-30).Date);

            Assert.IsNotNull(response);
            Assert.AreEqual(3, response.Count);
        }
    }
}

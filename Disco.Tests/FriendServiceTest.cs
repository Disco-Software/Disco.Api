using System;
using Disco.Business.Services;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using Disco.Business.Dtos.Friends;

namespace Disco.Tests
{
    [TestClass]
    public class FriendServiceTest
    {
        [TestMethod]
        public async Task Test_CreateVideoAsync()
        {
            var mockedFriendRepo = new Mock<IFriendRepository>();
            _ = mockedFriendRepo
                .Setup(obj => obj.AddAsync(It.IsAny<Friend>()))
                .Returns(Task.FromResult(150));

            var service = new FriendService(null, mockedFriendRepo.Object);

            var user = new User
            {
                Id = 1,
                Profile = new Profile
                {
                    Id = 1
                },

            };

            var friend = new User
            {
                Id = 2,
                Profile = new Profile
                {
                    Id = 2
                },
            };

            var dto = new CreateFriendDto
            {
                FriendId = 2
            };

            var response = await service.CreateFriendAsync(user, friend, dto);
            Console.WriteLine(response);
        }
    }
}

using System;
using System.Collections.Generic;
using Disco.Business.Services;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using Disco.Business.Dtos.Friends;
using AutoMapper;
using Disco.Business.Mapper;

namespace Disco.Tests.Services
{
    [TestClass]
    public class FollowerServiceTest
    {
        [TestMethod]
        public async Task CreateAsync_ReturnsSuccessResponse()
        {
            var mapperConfig = new MapperConfiguration(ms => ms.AddProfile(new MapProfile()));

            IMapper mapper = mapperConfig.CreateMapper();

            var mockedFriendRepo = new Mock<IFollowerRepository>();

            _ = mockedFriendRepo
                .Setup(obj => obj.AddAsync(It.IsAny<UserFollower>()))
                .Returns(Task.FromResult(150));

            var service = new FollowerService(mapper, mockedFriendRepo.Object);

            var user = new User
            {
                Id = 1,
                Account = new Account
                {
                    Id = 1,
                    Followers = new List<UserFollower>(),
                    Following = new List<UserFollower>()
                },
            };

            var follower = new User
            {
                Id = 2,
                Account = new Account
                {
                    Id = 2,
                    Followers = new List<UserFollower>()
                },
            };

            var dto = new CreateFollowerDto
            {
                FollowerAccountId = follower.AccountId,
                IntalationId = "fjkldjasdf;fjdaskljf;"
            };

            var response = await service.CreateAsync(user, follower, dto);
            response.FollowerAccountId = follower.Account.Id;


            Assert.AreEqual(follower.Id, response.FollowerAccountId);
            Assert.AreNotEqual(user.Id, follower.Id);
        }
        
        [TestMethod]
        public void DeleteAsync_ReturnsSuccessResponse()
        {
            var mapperConfig = new MapperConfiguration(ms => ms.AddProfile(new MapProfile()));

            IMapper mapper = mapperConfig.CreateMapper();

            var mockedFollowerRepository = new Mock<IFollowerRepository>();
            
            mockedFollowerRepository.Setup(f => f.Remove(2))
                .Returns(Task.CompletedTask);

            var service = new FollowerService(mapper, mockedFollowerRepository.Object);

            var response = service.DeleteAsync(2);

            Assert.IsNotNull(response);
        }
    }
}

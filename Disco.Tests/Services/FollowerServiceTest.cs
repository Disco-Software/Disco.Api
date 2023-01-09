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
            var mapperConfig = new MapperConfiguration(ms =>
            {
                ms.AddProfile(new AccountMapProfile());
                ms.AddProfile(new FollowerMapProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            var mockedFollowerRepo = new Mock<IFollowerRepository>();

            _ = mockedFollowerRepo
                .Setup(obj => obj.AddAsync(It.IsAny<UserFollower>()))
                .Returns(Task.FromResult(150));

            var service = new FollowerService(mapper, mockedFollowerRepo.Object);

            var following = new User
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

            var response = await service.CreateAsync(follower, following, dto);


            Assert.AreEqual(following.Account.Id, response.FollowingAccount.Id);
            Assert.AreEqual(follower.Account.Id, response.FollowerAccount.Id);
            Assert.AreNotEqual(following.Account.Id, follower.Account.Id);
        }
        
        [TestMethod]
        public void DeleteAsync_ReturnsSuccessResponse()
        {
            var mapperConfig = new MapperConfiguration(ms => ms.AddProfile(new FollowerMapProfile()));

            IMapper mapper = mapperConfig.CreateMapper();

            var userFollower = new UserFollower
            {
                FollowerAccount = new Account
                {
                    Followers = new List<UserFollower>
                    {
                        new UserFollower
                        {
                            FollowerAccount = new Account
                            {
                                User = new User
                                {
                                    Email = "vasya_pupkin@gmail.com",
                                    UserName = "vasya_pupkin"
                                }
                            },
                            FollowingAccount = new Account
                            {
                                User = new User
                                {
                                    Email = "vasya_pupkin1@gmail.com",
                                    UserName = "vasya_pupkin1"
                                }
                            }
                        }
                    },
                    User = new User
                    {
                        UserName = "vasya_pupkin",
                        Email = "vasya_pupkin@gmail.com",
                    }
                }
            };

            var mockedFollowerRepository = new Mock<IFollowerRepository>();
            
            mockedFollowerRepository.Setup(f => f.Remove(It.IsAny<UserFollower>()))
                .Returns(It.IsAny<Task>());

            var service = new FollowerService(mapper, mockedFollowerRepository.Object);

            var response = service.DeleteAsync(2);

            Assert.IsNotNull(response);
        }
    }
}

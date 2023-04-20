using System;
using System.Collections.Generic;
using Disco.Business.Services;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using Disco.Business.Interfaces.Dtos.Friends;
using AutoMapper;
using Disco.Business.Services.Mappers;
using Disco.Business.Services.Services;
using Disco.Domain.Models.Models;

namespace Disco.Tests.Services
{
    [TestClass]
    public class FollowerServiceTest
    {
        [TestMethod]
        public async Task CreateAsync_ReturnsSuccessResponse()
        {
            var mapperConfig = new MapperConfiguration(options =>
            {
                options.AddProfile(new AccountMapProfile());
                options.AddProfile(new GlobalSearchMapProfile());
                options.AddProfile(new PostMapProfile());
                options.AddProfile(new StoryMapProfile());
                options.AddProfile(new RoleMapProfile());
                options.AddProfile(new FollowerMapProfile());
                options.AddProfile(new MessageMapProfile());
                options.AddProfile(new CommentMapProfile());
                options.AddProfile(new GroupMapProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            var following = new User
            {
                Id = 1,
                UserName = "Stas",
                Email = "s.d.korchevskyi@gmail.com",
                Account = new Account
                {
                    Id = 1,
                    Following = new List<UserFollower>()
                },
            };

            var follower = new User
            {
                Id = 2,
                UserName = "vasya_pupkin",
                Email = "vasya_pupkin@gmail.com",
                Account = new Account
                {
                    Id = 2,
                    Followers = new List<UserFollower>()
                },
            };

            var dto = new CreateFollowerDto
            {
                FollowingAccountId = follower.AccountId,
                IntalationId = "fjkldjasdf;fjdaskljf;"
            };

            var mockedFollowerRepo = new Mock<IFollowerRepository>();
            mockedFollowerRepo
                .Setup(obj => obj.AddAsync(It.IsAny<UserFollower>()))
                .Returns(Task.FromResult(150));

            var service = new FollowerService(mapper, mockedFollowerRepo.Object, null);

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


            var service = new FollowerService(mapper, mockedFollowerRepository.Object, null);

            var response = service.DeleteAsync(2);

            Assert.IsNotNull(response);
        }
    }
}

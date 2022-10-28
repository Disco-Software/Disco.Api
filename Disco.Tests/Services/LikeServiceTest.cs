using AutoMapper;
using Disco.Business.Interfaces;
using Disco.Business.Mapper;
using Disco.Business.Services;
using Disco.Domain.Interfaces;
using Disco.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Tests.Services
{
    [TestClass]
    public class LikeServiceTest
    {
        [TestMethod]
        public async Task AddLike_ReturnsSuccessResponse()
        {
            var post = new Post
            {
                AccountId = It.IsAny<int>(),
                DateOfCreation = It.IsAny<DateTime>(),
                Description = It.IsAny<string>(),
                Likes = new List<Like>(),
                Id = It.IsAny<int>(),
            };

            var account = new Account
            {
                User = new User
                {
                    UserName = "v.pupkin",
                    Email = "vasya.pupkin@gmail.com",
                    DateOfRegister = DateTime.Now.AddDays(-20),
                    AccountId = 2,
                } as User,
                Following = new List<UserFollower>(),
                Followers = new List<UserFollower>(),
            };

            var mockedLikeService = new Mock<ILikeRepository>();
           
            mockedLikeService
                .Setup(like => like.AddAsync(It.IsAny<Like>()))
                .Returns(Task.CompletedTask);

            var mapperConfig = new MapperConfiguration(ms => ms.AddProfile(new MapProfile()));

            IMapper mapper = mapperConfig.CreateMapper();

            var likeService = new LikeService(mockedLikeService.Object, mapper);
            var response = await likeService.AddLikeAsync(account.User, post);

            Assert.AreEqual(post.Likes.Count, response.Count);
        }
    }
}

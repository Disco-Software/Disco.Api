using Disco.Business.Interfaces;
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
            var user = new User
            {
                UserName = "s.korchevskyi",
                Email = "stas_1999_nr@ukr.net",
                RoleName = "Admin",
                Profile = new Profile
                {
                    Posts = new List<Post>()
                }
            };

            var post = new Post
            {
                Id = 6,
                Profile = user.Profile,
                DateOfCreation = DateTime.Now,
                Description = "Bla bla bla",
                Likes = new List<Like>(),
                ProfileId = user.Profile.Id
            };

            var mockedPostRepository = new Mock<IPostRepository>();

            mockedPostRepository
                .Setup(postRepository => postRepository.AddAsync(post, user))
                .Returns(Task.CompletedTask);

            var mockedLikeService = new Mock<ILikeRepository>();
           
            mockedLikeService
                .Setup(like => like.AddAsync(new Like { Id = 1, Post = post, PostId = post.Id, UserName = user.UserName }, post.Id))
                .Returns(Task.CompletedTask);

            var likeService = new LikeService(mockedPostRepository.Object, mockedLikeService.Object);
            var response = await likeService.AddLikeAsync(user, post.Id);

            Assert.AreEqual(post.Likes.Count, response.Count + 1);
        }
    }
}

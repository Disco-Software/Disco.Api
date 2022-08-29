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
        public async Task ToggleLike_ReturnsSuccessResponse()
        {
            var post = new Post
            {
                Id = 22,
                Description = "Vasya pupkin",
                Likes = new List<Like>()
            };

            var user = new User
            {
                UserName = "s.korchevskyi",
                Email = "stas_1999_nr@ukr.net",
                RoleName = "User",
                Profile = new Profile
                {
                    Posts = new List<Post> { post }
                }
            };

            var mockedPostRepository = new Mock<IPostRepository>();
            
            mockedPostRepository
                .Setup(postRepository => postRepository.AddAsync(post, user))
                .Returns(Task.FromResult(post));

            var mockedLikeService = new Mock<ILikeRepository>();
           
            mockedLikeService
                .Setup(like => like.AddAsync(new Like { Id = It.IsAny<int>(), Post = post, PostId = post.Id, UserName = "s.korchevskyi" }, post.Id))
                .Returns(Task.CompletedTask);

            var likeService = new LikeService(mockedPostRepository.Object, mockedLikeService.Object);
            var response = await likeService.AddLikeAsync(user, post.Id);

            Assert.IsNotNull(response);
            Assert.AreEqual<int>(response.Count, 1);
        }
    }
}

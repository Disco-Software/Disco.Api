using Disco.Business.Services.Services;
using Disco.Domain.Interfaces;
using Disco.Domain.Models.Models;
using Disco.Tests.Mock;
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
    public class PostServiceTest
    {
        [TestMethod]
        public async Task CreatePostAsync_ReturnsSuccessResponse()
        {
            var list = new List<Post>
            {
                new Post {Description = "Hello", Id = 1, Account = new Account {User = new User{ UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com" } }},
                new Post {Description = "Hello", Id = 2, Account = new Account {User = new User{ UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com" } }},
                new Post {Description = "Hello", Id = 3, Account = new Account {User = new User{ UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com" } }},
                new Post {Description = "Hello", Id = 4, Account = new Account {User = new User{ UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com" } }},
                new Post {Description = "Hello", Id = 5, Account = new Account {User = new User{ UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com" } }},
                new Post {Description = "Hello", Id = 6, Account = new Account {User = new User{ UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com" } }},
                new Post {Description = "Hello", Id = 7, Account = new Account {User = new User{ UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com" } }},
            };

            var post = new Post { Description = "I'm php developer", Id = 8, Account = new Account { User = new User { UserName = "Taras_M", Email = "taras.m@gmail.com" } } };

            var mapper = MockedAutoMapper.MockAutoMapper();

            var mockedPostRepository = new Mock<IPostRepository>();
            mockedPostRepository.Setup(x => x.AddAsync(It.IsAny<Post>()))
                .Returns(Task.CompletedTask)
                .Callback<Post>((x) => list.Add(x));

            var postService = new PostService(mapper, null,mockedPostRepository.Object);
            var response = postService.CreatePostAsync(post);
            
            Assert.IsNotNull(response);
            Assert.AreEqual(list.Count, 8);
        }

        [TestMethod]
        public async Task RemovePostAsync_ReturnsSuccessResponse()
        {
            var list = new List<Post>
            {
                new Post {Description = "Hello", Id = 1, Account = new Account {User = new User{ UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com" } }},
                new Post {Description = "Hello", Id = 2, Account = new Account {User = new User{ UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com" } }},
                new Post {Description = "Hello", Id = 3, Account = new Account {User = new User{ UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com" } }},
                new Post {Description = "Hello", Id = 4, Account = new Account {User = new User{ UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com" } }},
                new Post {Description = "Hello", Id = 5, Account = new Account {User = new User{ UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com" } }},
                new Post {Description = "Hello", Id = 6, Account = new Account {User = new User{ UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com" } }},
                new Post {Description = "Hello", Id = 7, Account = new Account {User = new User{ UserName = "vasya_pupkin", Email = "vasya_pupkin@gmail.com" } }},
            };

            var post = new Post { Description = "I'm php developer", Id = 8, Account = new Account { User = new User { UserName = "Taras_M", Email = "taras.m@gmail.com" } } };

            var mapper = MockedAutoMapper.MockAutoMapper();

            var mockedPostRepository = new Mock<IPostRepository>();
            mockedPostRepository.Setup(x => x.Remove(It.IsAny<int>()))
                .Returns(Task.CompletedTask)
                .Callback<int>((x) => list.Remove(list.FirstOrDefault(l => l.Id == x)));

            var postService = new PostService(mapper, null, mockedPostRepository.Object);
            var response = postService.DeletePostAsync(8);

            Assert.IsNotNull(response);
            Assert.AreEqual(list.Count, 7);

        }
    }
}

namespace Disco.ApiServices.Test.Features.Post
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Post;
    using Disco.Business.Interfaces.Dtos.Posts;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class PostControllerTests
    {
        private PostController _testClass;
        private IMediator _mediator;

        [SetUp]
        public void SetUp()
        {
            _mediator = Substitute.For<IMediator>();
            _testClass = new PostController(_mediator);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new PostController(_mediator);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreatePostAsync()
        {
            // Arrange
            var dto = new CreatePostDto
            {
                Description = "TestValue1729753739",
                PostImages = new List<IFormFile>(),
                PostSongs = new List<IFormFile>(),
                PostSongImages = new List<IFormFile>(),
                PostSongNames = new List<string>(),
                ExecutorNames = new List<string>(),
                PostVideos = new List<IFormFile>()
            };

            // Act
            var result = await _testClass.CreatePostAsync(dto);

            // Assert
            _mediator.Received(1);
        }

        [Test]
        public async Task CanCallDeletePostAsync()
        {
            // Arrange
            var postId = 1661499752;

            // Act
            await _testClass.DeletePostAsync(postId);

            // Assert
            _mediator.Received(1);
        }

        [Test]
        public async Task CanCallGetAllUserPosts()
        {
            // Arrange
            var dto = new GetAllPostsDto
            {
                PageNumber = 463048894,
                PageSize = 635623843
            };

            // Act
            var result = await _testClass.GetAllUserPosts(dto);

            // Assert
            _mediator.Received(1);
        }

        [Test]
        public async Task CanCallGetPostsAsync()
        {
            // Arrange
            var dto = new GetAllPostsDto
            {
                PageNumber = 1951130715,
                PageSize = 1927735248
            };

            // Act
            var result = await _testClass.GetPostsAsync(dto);

            // Assert
            _mediator.Received(1);
        }
    }
}
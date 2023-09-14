namespace Disco.ApiServices.Test.Features.Post.RequestHandlers.CreatePost
{
    using System;
    using System.Collections.Generic;
    using Disco.ApiServices.Features.Post.RequestHandlers.CreatePost;
    using Disco.Business.Interfaces.Dtos.Posts;
    using Microsoft.AspNetCore.Http;
    using NUnit.Framework;

    [TestFixture]
    public class CreatePostRequestTests
    {
        private CreatePostRequest _testClass;
        private CreatePostDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new CreatePostDto
            {
                Description = "TestValue277883230",
                PostImages = new List<IFormFile>(),
                PostSongs = new List<IFormFile>(),
                PostSongImages = new List<IFormFile>(),
                PostSongNames = new List<string>(),
                ExecutorNames = new List<string>(),
                PostVideos = new List<IFormFile>()
            };
            _testClass = new CreatePostRequest(_dto);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new CreatePostRequest(_dto);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }


        [Test]
        public void DtoIsInitializedCorrectly()
        {
            Assert.That(_testClass.Dto, Is.SameAs(_dto));
        }
    }
}
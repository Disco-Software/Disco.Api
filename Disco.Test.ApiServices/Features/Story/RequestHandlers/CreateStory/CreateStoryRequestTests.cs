namespace Disco.ApiServices.Test.Features.Story.RequestHandlers.CreateStory
{
    using System;
    using System.Collections.Generic;
    using Disco.ApiServices.Features.Story.RequestHandlers.CreateStory;
    using Disco.Business.Interfaces.Dtos.Stories;
    using Microsoft.AspNetCore.Http;
    using NUnit.Framework;

    [TestFixture]
    public class CreateStoryRequestTests
    {
        private CreateStoryRequest _testClass;
        private CreateStoryDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new CreateStoryDto
            {
                StoryImages = new List<IFormFile>(),
                StoryVideos = new List<IFormFile>(),
                ProfileId = 434041638
            };
            _testClass = new CreateStoryRequest(_dto);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new CreateStoryRequest(_dto);

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
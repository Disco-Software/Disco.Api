namespace Disco.ApiServices.Test.Features.Story
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Story;
    using Disco.Business.Interfaces.Dtos.Stories;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class StoryControllerTests
    {
        private StoryController _testClass;
        private IMediator _mediator;

        [SetUp]
        public void SetUp()
        {
            _mediator = Substitute.For<IMediator>();
            _testClass = new StoryController(_mediator);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new StoryController(_mediator);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallCreateAsync()
        {
            // Arrange
            var dto = new CreateStoryDto
            {
                StoryImages = new List<IFormFile>(),
                StoryVideos = new List<IFormFile>(),
                ProfileId = 2007949586
            };

            // Act
            var result = await _testClass.CreateAsync(dto);

            // Assert
            _mediator.Received(1);
        }

        [Test]
        public async Task CanCallDeleteAsync()
        {
            // Arrange
            var id = 1191041166;

            // Act
            var result = await _testClass.DeleteAsync(id);

            // Assert
            _mediator.Received(1);
        }

        [Test]
        public async Task CanCallGetAsync()
        {
            // Arrange
            var id = 872699363;

            // Act
            var result = await _testClass.GetAsync(id);

            // Assert
            _mediator.Received(1);
        }

        [Test]
        public async Task CanCallGetStoriesAsync()
        {
            // Arrange
            var dto = new GetAllStoriesDto
            {
                PageNumber = 815002307,
                PageSize = 332763576
            };

            // Act
            var result = await _testClass.GetStoriesAsync(dto);

            // Assert
            _mediator.Received(1);
        }
    }
}
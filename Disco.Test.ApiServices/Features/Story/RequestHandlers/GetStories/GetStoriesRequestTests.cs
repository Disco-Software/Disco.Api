namespace Disco.ApiServices.Test.Features.Story.RequestHandlers.GetStories
{
    using System;
    using Disco.ApiServices.Features.Story.RequestHandlers.GetStories;
    using Disco.Business.Interfaces.Dtos.Stories;
    using NUnit.Framework;

    [TestFixture]
    public class GetStoriesRequestTests
    {
        private GetStoriesRequest _testClass;
        private GetAllStoriesDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new GetAllStoriesDto
            {
                PageNumber = 1455918545,
                PageSize = 1743032167
            };
            _testClass = new GetStoriesRequest(_dto);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetStoriesRequest(_dto);

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
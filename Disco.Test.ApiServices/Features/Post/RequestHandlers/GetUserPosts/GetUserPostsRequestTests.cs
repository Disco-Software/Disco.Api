namespace Disco.ApiServices.Test.Features.Post.RequestHandlers.GetUserPosts
{
    using System;
    using Disco.ApiServices.Features.Post.RequestHandlers.GetUserPosts;
    using Disco.Business.Interfaces.Dtos.Posts;
    using NUnit.Framework;

    [TestFixture]
    public class GetUserPostsRequestTests
    {
        private GetUserPostsRequest _testClass;
        private GetAllPostsDto _dto;

        [SetUp]
        public void SetUp()
        {
            _dto = new GetAllPostsDto
            {
                PageNumber = 1435862514,
                PageSize = 456258623
            };
            _testClass = new GetUserPostsRequest(_dto);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetUserPostsRequest(_dto);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullDto()
        {
            Assert.Throws<ArgumentNullException>(() => new GetUserPostsRequest(default(GetAllPostsDto)));
        }

        [Test]
        public void DtoIsInitializedCorrectly()
        {
            Assert.That(_testClass.Dto, Is.SameAs(_dto));
        }
    }
}
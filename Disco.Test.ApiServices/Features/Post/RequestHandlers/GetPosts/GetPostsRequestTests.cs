namespace Disco.ApiServices.Test.Features.Post.RequestHandlers.GetPosts
{
    using System;
    using Disco.ApiServices.Features.Post.RequestHandlers.GetPosts;
    using Disco.Business.Interfaces.Dtos.Posts;
    using NUnit.Framework;

    [TestFixture]
    public class GetPostsRequestTests
    {
        private GetPostsRequest _testClass;
        private GetAllPostsDto _dataTransferObject;

        [SetUp]
        public void SetUp()
        {
            _dataTransferObject = new GetAllPostsDto
            {
                PageNumber = 2073167142,
                PageSize = 1518756735
            };
            _testClass = new GetPostsRequest(_dataTransferObject);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetPostsRequest(_dataTransferObject);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullDataTransferObject()
        {
            Assert.Throws<ArgumentNullException>(() => new GetPostsRequest(default(GetAllPostsDto)));
        }

        [Test]
        public void DataTransferObjectIsInitializedCorrectly()
        {
            Assert.That(_testClass.DataTransferObject, Is.SameAs(_dataTransferObject));
        }
    }
}
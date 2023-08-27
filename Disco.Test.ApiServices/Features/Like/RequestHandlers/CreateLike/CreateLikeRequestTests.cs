namespace Disco.ApiServices.Test.Features.Like.RequestHandlers.CreateLike
{
    using System;
    using Disco.ApiServices.Features.Like.RequestHandlers.CreateLike;
    using NUnit.Framework;

    [TestFixture]
    public class CreateLikeRequestTests
    {
        private CreateLikeRequest _testClass;
        private int _postId;

        [SetUp]
        public void SetUp()
        {
            _postId = 920814110;
            _testClass = new CreateLikeRequest(_postId);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new CreateLikeRequest(_postId);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void PostIdIsInitializedCorrectly()
        {
            Assert.That(_testClass.PostId, Is.EqualTo(_postId));
        }
    }
}
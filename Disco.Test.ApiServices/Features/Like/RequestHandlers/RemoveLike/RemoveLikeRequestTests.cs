namespace Disco.ApiServices.Test.Features.Like.RequestHandlers.RemoveLike
{
    using System;
    using Disco.ApiServices.Features.Like.RequestHandlers.RemoveLike;
    using NUnit.Framework;

    [TestFixture]
    public class RemoveLikeRequestTests
    {
        private RemoveLikeRequest _testClass;
        private int _postId;

        [SetUp]
        public void SetUp()
        {
            _postId = 870469637;
            _testClass = new RemoveLikeRequest(_postId);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new RemoveLikeRequest(_postId);

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
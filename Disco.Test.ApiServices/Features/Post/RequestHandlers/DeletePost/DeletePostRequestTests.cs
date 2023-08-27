namespace Disco.ApiServices.Test.Features.Post.RequestHandlers.DeletePost
{
    using System;
    using Disco.ApiServices.Features.Post.RequestHandlers.DeletePost;
    using NUnit.Framework;

    [TestFixture]
    public class DeletePostRequestTests
    {
        private DeletePostRequest _testClass;
        private int _postId;

        [SetUp]
        public void SetUp()
        {
            _postId = 2051183181;
            _testClass = new DeletePostRequest(_postId);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new DeletePostRequest(_postId);

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
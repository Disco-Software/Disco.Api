namespace Disco.ApiServices.Test.Features.Like
{
    using System;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Like;
    using MediatR;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class LikeControllerTests
    {
        private LikeController _testClass;
        private IMediator _mediator;

        [SetUp]
        public void SetUp()
        {
            _mediator = Substitute.For<IMediator>();
            _testClass = new LikeController(_mediator);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new LikeController(_mediator);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullMediator()
        {
            Assert.Throws<ArgumentNullException>(() => new LikeController(default(IMediator)));
        }

        [Test]
        public async Task CanCallCreateLikeAsync()
        {
            // Arrange
            var postId = 2085861925;

            // Act
            var result = await _testClass.CreateLikeAsync(postId);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public async Task CanCallRemoveLikeAsync()
        {
            // Arrange
            var postId = 684786430;

            // Act
            var result = await _testClass.RemoveLikeAsync(postId);

            // Assert
            Assert.Fail("Create or modify test");
        }
    }
}
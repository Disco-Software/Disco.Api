namespace Disco.ApiServices.Test.Features.Post.RequestHandlers.DeletePost
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Post.RequestHandlers.DeletePost;
    using Disco.Business.Interfaces.Interfaces;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class DeletePostRequestHandlerTests
    {
        private DeletePostRequestHandler _testClass;
        private IPostService _postService;

        [SetUp]
        public void SetUp()
        {
            _postService = Substitute.For<IPostService>();
            _testClass = new DeletePostRequestHandler(_postService);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new DeletePostRequestHandler(_postService);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullPostService()
        {
            Assert.Throws<ArgumentNullException>(() => new DeletePostRequestHandler(default(IPostService)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new DeletePostRequest(545607699);
            var cancellationToken = CancellationToken.None;

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _postService.Received().DeletePostAsync(Arg.Any<int>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(DeletePostRequest), CancellationToken.None));
        }
    }
}
namespace Disco.ApiServices.Test.Features.Story.RequestHandlers.DeleteStory
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Story.RequestHandlers.DeleteStory;
    using Disco.Business.Interfaces.Interfaces;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class DeleteStoryRequestHandlerTests
    {
        private DeleteStoryRequestHandler _testClass;
        private IStoryService _storyService;

        [SetUp]
        public void SetUp()
        {
            _storyService = Substitute.For<IStoryService>();
            _testClass = new DeleteStoryRequestHandler(_storyService);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new DeleteStoryRequestHandler(_storyService);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullStoryService()
        {
            Assert.Throws<ArgumentNullException>(() => new DeleteStoryRequestHandler(default(IStoryService)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new DeleteStoryRequest(1162585558);
            var cancellationToken = CancellationToken.None;

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _storyService.Received().DeleteStoryAsync(Arg.Any<int>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(DeleteStoryRequest), CancellationToken.None));
        }
    }
}
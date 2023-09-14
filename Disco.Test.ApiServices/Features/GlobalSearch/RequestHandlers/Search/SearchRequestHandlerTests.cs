namespace Disco.Test.ApiServices.Features.GlobalSearch.RequestHandlers.Search
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.GlobalSearch.RequestHandlers.Search;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class SearchRequestHandlerTests
    {
        private SearchRequestHandler _testClass;
        private IAccountDetailsService _accountDetailsService;
        private IPostService _postService;

        [SetUp]
        public void SetUp()
        {
            _accountDetailsService = Substitute.For<IAccountDetailsService>();
            _postService = Substitute.For<IPostService>();
            _testClass = new SearchRequestHandler(_accountDetailsService, _postService);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new SearchRequestHandler(_accountDetailsService, _postService);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new SearchRequest("TestValue162816594");
            var cancellationToken = CancellationToken.None;

            _accountDetailsService.GetAccountsByNameAsync(Arg.Any<string>()).Returns(new List<Account>());
            _postService.GetPostsByDescriptionAsync(Arg.Any<string>()).Returns(new List<Post>());

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _accountDetailsService.Received().GetAccountsByNameAsync(Arg.Any<string>());
            await _postService.Received().GetPostsByDescriptionAsync(Arg.Any<string>());
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(SearchRequest), CancellationToken.None));
        }
    }
}
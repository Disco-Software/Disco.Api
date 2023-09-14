namespace Disco.Test.ApiServices.Features.GlobalSearch
{
    using System;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.GlobalSearch;
    using MediatR;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class GlobalSearchControllerTests
    {
        private GlobalSearchController _testClass;
        private IMediator _mediator;

        [SetUp]
        public void SetUp()
        {
            _mediator = Substitute.For<IMediator>();
            _testClass = new GlobalSearchController(_mediator);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GlobalSearchController(_mediator);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallSerach()
        {
            // Arrange
            var search = "TestValue814947834";

            // Act
            var result = await _testClass.Serach(search);

            // Assert
            _mediator.Received(1);
        }
    }
}
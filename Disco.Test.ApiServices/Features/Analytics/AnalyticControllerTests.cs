namespace Disco.Test.ApiServices.Features.Analytics
{
    using System;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Analytics;
    using MediatR;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class AnalyticControllerTests
    {
        private AnalyticController _testClass;
        private IMediator _mediator;

        [SetUp]
        public void SetUp()
        {
            _mediator = Substitute.For<IMediator>();
            _testClass = new AnalyticController(_mediator);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new AnalyticController(_mediator);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public async Task CanCallGetAnalitycAsync()
        {
            // Arrange
            var @from = "TestValue440335412";
            var to = "TestValue1254255936";
            var analyticFor = "TestValue874105485";

            // Act
            var result = await _testClass.GetAnalitycAsync(from, to, analyticFor);

            // Assert
            _mediator.Received(1);
        }
    }
}
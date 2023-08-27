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
        public void CannotConstructWithNullMediator()
        {
            Assert.Throws<ArgumentNullException>(() => new AnalyticController(default(IMediator)));
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
            Assert.Fail("Create or modify test");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallGetAnalitycAsyncWithInvalidFrom(string value)
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.GetAnalitycAsync(value, "TestValue136910118", "TestValue1045603502"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallGetAnalitycAsyncWithInvalidTo(string value)
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.GetAnalitycAsync("TestValue1861880235", value, "TestValue930765855"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallGetAnalitycAsyncWithInvalidAnalyticFor(string value)
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.GetAnalitycAsync("TestValue834092227", "TestValue1928067629", value));
        }
    }
}
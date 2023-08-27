namespace Disco.Test.ApiServices.Features.Analytics.GetAnalytic
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Disco.ApiServices.Features.Analytics.GetAnalytic;
    using Disco.ApiServices.Features.Analytics.RequestHandlers.GetAnalytic;
    using Disco.Business.Interfaces.Dtos.Analytic;
    using Disco.Business.Interfaces.Enums;
    using Disco.Business.Interfaces.Interfaces;
    using Disco.Domain.Models.Models;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class GetAnalyticRequestHandlerTests
    {
        private GetAnalyticRequestHandler _testClass;
        private IAnalyticService _analyticService;

        [SetUp]
        public void SetUp()
        {
            _analyticService = Substitute.For<IAnalyticService>();
            _testClass = new GetAnalyticRequestHandler(_analyticService);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetAnalyticRequestHandler(_analyticService);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullAnalyticService()
        {
            Assert.Throws<ArgumentNullException>(() => new GetAnalyticRequestHandler(default(IAnalyticService)));
        }

        [Test]
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new GetAnalyticRequest("TestValue400996110", "TestValue1086908316", "TestValue359941415");
            var cancellationToken = CancellationToken.None;

            _analyticService.GetAnalyticAsync(Arg.Any<DateTime>(), Arg.Any<DateTime>(), Arg.Any<AnalyticFor>()).Returns(new AnalyticDto
            {
                UsersCount = 2067761474,
                NewUsersCount = 1085136557,
                PostsCount = 895317181,
            });

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            await _analyticService.Received().GetAnalyticAsync(Arg.Any<DateTime>(), Arg.Any<DateTime>(), Arg.Any<AnalyticFor>());

            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Handle(default(GetAnalyticRequest), CancellationToken.None));
        }
    }
}
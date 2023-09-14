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
        public async Task CanCallHandle()
        {
            // Arrange
            var request = new GetAnalyticRequest("02.04.2022", "02.04.2022", "Day");
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
        }

        [Test]
        public void CannotCallHandleWithNullRequest()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _testClass.Handle(default(GetAnalyticRequest), CancellationToken.None));
        }
    }
}
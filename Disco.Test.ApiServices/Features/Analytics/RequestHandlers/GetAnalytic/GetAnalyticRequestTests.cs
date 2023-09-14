namespace Disco.Test.ApiServices.Features.Analytics.RequestHandlers.GetAnalytic
{
    using System;
    using Disco.ApiServices.Features.Analytics.RequestHandlers.GetAnalytic;
    using NUnit.Framework;

    [TestFixture]
    public class GetAnalyticRequestTests
    {
        private GetAnalyticRequest _testClass;
        private string _from;
        private string _to;
        private string _analyticFor;

        [SetUp]
        public void SetUp()
        {
            _from = "TestValue816273483";
            _to = "TestValue664537245";
            _analyticFor = "TestValue1144597880";
            _testClass = new GetAnalyticRequest(_from, _to, _analyticFor);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetAnalyticRequest(_from, _to, _analyticFor);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void FromIsInitializedCorrectly()
        {
            Assert.That(_testClass.From, Is.EqualTo(_from));
        }

        [Test]
        public void ToIsInitializedCorrectly()
        {
            Assert.That(_testClass.To, Is.EqualTo(_to));
        }

        [Test]
        public void AnalyticForIsInitializedCorrectly()
        {
            Assert.That(_testClass.AnalyticFor, Is.EqualTo(_analyticFor));
        }
    }
}
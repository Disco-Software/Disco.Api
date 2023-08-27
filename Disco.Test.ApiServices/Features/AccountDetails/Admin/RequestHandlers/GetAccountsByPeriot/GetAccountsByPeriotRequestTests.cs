namespace Disco.Test.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAccountsByPeriot
{
    using System;
    using Disco.ApiServices.Features.AccountDetails.Admin.RequestHandlers.GetAccountsByPeriot;
    using NUnit.Framework;

    [TestFixture]
    public class GetAccountsByPeriotRequestTests
    {
        private GetAccountsByPeriotRequest _testClass;
        private int _periot;

        [SetUp]
        public void SetUp()
        {
            _periot = 988869457;
            _testClass = new GetAccountsByPeriotRequest(_periot);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new GetAccountsByPeriotRequest(_periot);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void PeriotIsInitializedCorrectly()
        {
            Assert.That(_testClass.Periot, Is.EqualTo(_periot));
        }
    }
}
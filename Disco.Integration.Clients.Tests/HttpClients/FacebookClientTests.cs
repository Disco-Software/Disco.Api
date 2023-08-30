namespace Disco.Integration.Clients.Test.HttpClients
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Disco.Integration.Clients.HttpClients;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class FacebookClientTests
    {
        private FacebookClient _testClass;
        private IHttpClientFactory _httpClientFactory;

        [SetUp]
        public void SetUp()
        {
            _httpClientFactory = Substitute.For<IHttpClientFactory>();
            _testClass = new FacebookClient(_httpClientFactory);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new FacebookClient(_httpClientFactory);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullHttpClientFactory()
        {
            Assert.Throws<ArgumentNullException>(() => new FacebookClient(default(IHttpClientFactory)));
        }

        [Test]
        public async Task CanCallGetInfoAsync()
        {
            // Arrange
            var accessToken = "TestValue1506192048";

            // Act
            var result = await _testClass.GetInfoAsync(accessToken);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallGetInfoAsyncWithInvalidAccessToken(string value)
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.GetInfoAsync(value));
        }

        [Test]
        public async Task CanCallValidateAsync()
        {
            // Arrange
            var accessToken = "TestValue908628514";

            // Act
            var result = await _testClass.ValidateAsync(accessToken);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void CannotCallValidateAsyncWithInvalidAccessToken(string value)
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.ValidateAsync(value));
        }
    }
}
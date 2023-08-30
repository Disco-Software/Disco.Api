namespace Disco.Integration.Clients.Test.HttpClients
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Disco.Integration.Clients.HttpClients;
    using Disco.Integration.Interfaces.Dtos.AudD;
    using Microsoft.AspNetCore.Http;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class AudDClientTests
    {
        private AudDClient _testClass;
        private IHttpClientFactory _httpClientFactory;

        [SetUp]
        public void SetUp()
        {
            _httpClientFactory = Substitute.For<IHttpClientFactory>();
            _testClass = new AudDClient(_httpClientFactory);
        }

        [Test]
        public void CanConstruct()
        {
            // Act
            var instance = new AudDClient(_httpClientFactory);

            // Assert
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullHttpClientFactory()
        {
            Assert.Throws<ArgumentNullException>(() => new AudDClient(default(IHttpClientFactory)));
        }

        [Test]
        public async Task CanCallCheckAuthorAsync()
        {
            // Arrange
            var dto = new AudDRequestDto
            {
                api_token = "TestValue1666887783",
                file = Substitute.For<IFormFile>(),
                @return = "TestValue708060717"
            };

            // Act
            var result = await _testClass.CheckAuthorAsync(dto);

            // Assert
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallCheckAuthorAsyncWithNullDto()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.CheckAuthorAsync(default(AudDRequestDto)));
        }
    }
}
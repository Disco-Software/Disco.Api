using System.Net.Http;
using Disco.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Disco.Tests.Tests.Base
{
    [TestClass]
    public class IntegrationTest
    {
        protected readonly HttpClient httpClient;
        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(webHostBuilder => webHostBuilder.ConfigureServices(services => services.AddHttpClient()));
            httpClient = appFactory.CreateClient();
        }
    }
}

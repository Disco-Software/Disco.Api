using Disco.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Disco.Tests.Base
{
    [TestClass]
    public class IntegrationTest
    {
        protected readonly HttpClient httpClient;
        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(webHostBuilder => {
                    webHostBuilder.ConfigureServices(services =>
                    {
                        services.AddHttpClient();
                    });
                });
            httpClient = appFactory.CreateClient();
        }
    }
}

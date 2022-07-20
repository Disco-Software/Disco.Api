using Disco.Api;
using Disco.Business.Interfaces;
using Disco.Business.Dto;
using Disco.Domain.EF;
using Disco.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
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

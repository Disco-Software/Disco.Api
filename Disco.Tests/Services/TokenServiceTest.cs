using Disco.Business.Interfaces;
using Disco.Business.Interfaces.Interfaces;
using Disco.Business.Interfaces.Options;
using Disco.Business.Services;
using Disco.Business.Services.Services;
using Disco.Domain.Models;
using Disco.Domain.Models.Models;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disco.Tests.Services
{
    [TestClass]
    public class TokenServiceTest
    {
        [TestMethod]
        public void GenerateAccessToken_ReturnsStringResponse()
        {
            var user = new User
            {
                UserName = "vasya_pupkin",
                Email = "vasya_pupkin@gmail.com",
                Account = new Account()
                {
                    AccountStatus = new AccountStatus()
                }
            };

            var authenticationOptions = new AuthenticationOptions()
            {
                Issuer = "test",
                Audience = "test",
                ExpiresAfterMitutes = 20,
                SigningKey = "YmxhYmxhYmxh",
            };

            authenticationOptions.SigningKeyBytes
                .ToList()
                .AddRange(Encoding.UTF8.GetBytes(authenticationOptions.SigningKey));


            var mockedOptions = new Mock<IOptions<AuthenticationOptions>>();
            mockedOptions.Setup(options => options.Value)
                .Returns(authenticationOptions);

            var mockedTokenService = new Mock<ITokenService>();
            mockedTokenService.Setup(x => x.GenerateAccessToken(user))
                .Returns("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsIm5iZiI6MTY3NDYzODc2MCwiZXhwIjoxNjc0NzEwNzYwLCJpc3MiOiJkaXNjby1hcGkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0L0Rpc2NvLkFwaSJ9.9KeP-LSVFJ9UB6hNeJpNV1zHqWee_hm6dAmBHTm7LRY");

            var service = new TokenService(mockedOptions.Object);
            var resopnse = service.GenerateAccessToken(user);

            Assert.IsNotNull(resopnse);
        }

        [TestMethod]
        public void GenerateRefreshToken__ReturnsStringResponse()
        {
            string refreshToken = "blablagbla";

            var mockedTokenService = new Mock<ITokenService>();
            mockedTokenService.Setup(options => options.GenerateRefreshToken())
                .Returns(refreshToken);

            var service = new TokenService(null);
            var response = service.GenerateRefreshToken();

            Assert.IsNotNull(response);
        }

    }
}

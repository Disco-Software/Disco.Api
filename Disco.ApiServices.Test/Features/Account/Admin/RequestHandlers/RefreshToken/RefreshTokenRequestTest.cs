using Disco.ApiServices.Features.Account.Admin.RequestHandlers.RefreshToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Test.Features.Account.Admin.RequestHandlers.RefreshToken
{
    [TestFixture]
    public class RefreshTokenRequestTest
    {
        private RefreshTokenRequest _request;

        [Test]
        public void Constructor_WhenValidParams_InitializeRequest()
        {
            //Act
            _request = new RefreshTokenRequest(new Business.Interfaces.Dtos.Account.Admin.RefreshToken.RefreshTokenRequestDto(
                accessToken: Guid.NewGuid().ToString(),
                refreshToken: Guid.NewGuid().ToString()
            ));

            //Assert
            Assert.That(_request, Is.Not.Null);
        }
    }
}

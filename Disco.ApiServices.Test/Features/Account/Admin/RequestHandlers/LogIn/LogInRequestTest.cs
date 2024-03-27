using Disco.ApiServices.Features.Account.Admin.RequestHandlers.LogIn;

namespace Disco.ApiServices.Test.Features.Account.Admin.RequestHandlers.LogIn
{
    [TestFixture]
    public class LogInRequestTest
    {
        private LogInRequest _request;

        [SetUp]
        public void SetUp()
        {
            _request = new LogInRequest(
                new Business.Interfaces.Dtos.Account.Admin.LogIn.LogInRequestDto(
                    "vasya_pupkin@gmail.com",
                    "vasya2023!"));
        }

        [Test]
        public void Constructor_WhenValidParams_CreatesLogInRequest()
        {
            //Arrange
            _request = new LogInRequest(
                new Business.Interfaces.Dtos.Account.Admin.LogIn.LogInRequestDto("vasya_pupkin", "pupkin123!"));

            //Act & Assert
            Assert.That(_request, Is.Not.Null);
        }
    }
}

using Disco.Web.Infrastructure.Interfaces;
using Disco.Web.Infrastructure.Models;
using Newtonsoft.Json;

namespace Disco.Web.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task<UserResponseModel> LogIn(LogInModel model)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var json = JsonConvert
        }

        public Task<UserResponseModel> Register(RegisterModel model)
        {
            throw new NotImplementedException();
        }
    }
}

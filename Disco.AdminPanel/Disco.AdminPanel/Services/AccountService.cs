using Disco.AdminPanel.Interfaces;
using Disco.AdminPanel.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;

namespace Disco.AdminPanel.Services
{
    public class AccountService : IAccountService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<UserResponseModel> Login(LogInModel model)
        {
            var json = JsonConvert.SerializeObject(model);

            var content = new StringContent(json);
          

            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.PostAsJsonAsync("http://localhost/Disco.Api/api/admin/account/log-in", content);

            var result = await response.Content.ReadAsStringAsync();

            var userResponseModel = JsonConvert.DeserializeObject<UserResponseModel>(result);

            return userResponseModel;
        }
    }
}

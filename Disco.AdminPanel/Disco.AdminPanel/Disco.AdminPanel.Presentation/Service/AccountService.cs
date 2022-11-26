using Disco.AdminPanel.Presentation.Interfaces;
using Disco.AdminPanel.Presentation.Models.Account;
using Disco.AdminPanel.Presentation.ViewModels;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace Disco.AdminPanel.Presentation.Service
{
    public class AccountService : IAccountService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<UserResponseModel> LoginAsync(LoginViewModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.PostAsJsonAsync("https://localhost:44302/api/admin/account/log-in");
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserResponseModel>(result);
        }
    }
}

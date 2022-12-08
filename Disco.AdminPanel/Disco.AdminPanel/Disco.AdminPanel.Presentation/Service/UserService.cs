using Disco.AdminPanel.Presentation.Interfaces;
using Disco.AdminPanel.Presentation.Models.Account;
using Newtonsoft.Json;

namespace Disco.AdminPanel.Presentation.Service
{
    public class UserService : IUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<User>> GetAllUsersByRange(int days, string token)
        {
            var httpClient = _httpClientFactory.CreateClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var response = await httpClient.GetAsync($"https://localhost:44302/api/admin/users/periot?periot=${days}");
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<User>>(result);
        }
    }
}

using Disco.Business.Interfaces;
using Disco.Business.Dtos.Facebook;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Disco.Business.Services
{
    public class FacebookAuthService : IFacebookAuthService
    {
        private const string TokenValidationUrl = "https://graph.facebook.com/debug_token?input_token=EAADtYXQf7KkBAAR5BOGX9jZAmWvve4fyWlyBpgqcFAb3jW9yt2XeZAcSFFu3nGEa4n23umKmZBdjx7qwe30uVu5e6o7PmpAp6FfXCdLdYrFb9UrjdE8QMT4Rl9F5clBRpUWKrnIR8VkRZBePb09mWaPG6pNVZBCRU9O5OZBPTgZAtZB4BiqF7jD6lolcx7oZBP718oPIMZB967dgZDZD&access_token=261002815859881|9c4f0fbe6ed89d0c35d1a7cd965de88c";
        private const string UserInfoUrl = "https://graph.facebook.com/v11.0/me?fields=id%2Cname%2Cemail%2Cfirst_name%2Cmiddle_name%2Clast_name%2Cpicture%2Cabout&access_token=EAADtYXQf7KkBAAR5BOGX9jZAmWvve4fyWlyBpgqcFAb3jW9yt2XeZAcSFFu3nGEa4n23umKmZBdjx7qwe30uVu5e6o7PmpAp6FfXCdLdYrFb9UrjdE8QMT4Rl9F5clBRpUWKrnIR8VkRZBePb09mWaPG6pNVZBCRU9O5OZBPTgZAtZB4BiqF7jD6lolcx7oZBP718oPIMZB967dgZDZD";
        private readonly Configurations.FacebookOptions _facebookOptions;
        private readonly IHttpClientFactory _httpClientFactory;

        public FacebookAuthService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _facebookOptions = new Configurations.FacebookOptions
            {
                AppId = configuration["Facebook:AppId"],
                AppSecret = configuration["Facebook:SecretKey"]
            };
            _httpClientFactory = httpClientFactory;
        }

        public async Task<FacebookDto> GetUserInfo(string accessToken)
        {
            var result = await _httpClientFactory.CreateClient().GetAsync($"https://graph.facebook.com/v11.0/me?fields=id%2Cname%2Cemail%2Cfirst_name%2Cmiddle_name%2Clast_name%2Cpicture%2Cabout&access_token={accessToken}");

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var response = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<FacebookDto>(response);
            }
            else
                return null;
        }

        public async Task<TokenValidationResponseModel> TokenValidation(string accessToken)
        {
            var result = await _httpClientFactory.CreateClient().GetAsync($"https://graph.facebook.com/debug_token?input_token={accessToken}&access_token=261002815859881|9c4f0fbe6ed89d0c35d1a7cd965de88c");

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var response = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TokenValidationResponseModel>(response);
            }
            else
                return null;
        }
    }
}

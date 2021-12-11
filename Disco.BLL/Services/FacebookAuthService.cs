using Disco.BLL.DTO;
using Disco.BLL.Interfaces;
using Disco.BLL.Models;
using Disco.BLL.Models.Facebook;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class FacebookAuthService : IFacebookAuthService
    {
        private const string tokenValidationUrl = "https://graph.facebook.com/debug_token?input_token=EAADtYXQf7KkBAAR5BOGX9jZAmWvve4fyWlyBpgqcFAb3jW9yt2XeZAcSFFu3nGEa4n23umKmZBdjx7qwe30uVu5e6o7PmpAp6FfXCdLdYrFb9UrjdE8QMT4Rl9F5clBRpUWKrnIR8VkRZBePb09mWaPG6pNVZBCRU9O5OZBPTgZAtZB4BiqF7jD6lolcx7oZBP718oPIMZB967dgZDZD&access_token=261002815859881|9c4f0fbe6ed89d0c35d1a7cd965de88c";
        private const string userInfoUrl = "https://graph.facebook.com/v11.0/me?fields=id%2Cname%2Cemail%2Cfirst_name%2Cmiddle_name%2Clast_name%2Cpicture%2Cabout&access_token=EAADtYXQf7KkBAAR5BOGX9jZAmWvve4fyWlyBpgqcFAb3jW9yt2XeZAcSFFu3nGEa4n23umKmZBdjx7qwe30uVu5e6o7PmpAp6FfXCdLdYrFb9UrjdE8QMT4Rl9F5clBRpUWKrnIR8VkRZBePb09mWaPG6pNVZBCRU9O5OZBPTgZAtZB4BiqF7jD6lolcx7oZBP718oPIMZB967dgZDZD";
        private readonly BLL.Configurations.FacebookOptions facebookOptions;
        private readonly IHttpClientFactory httpClientFactory;

        public FacebookAuthService(IConfiguration configuration, IHttpClientFactory _httpClientFactory)
        {
            facebookOptions = new Configurations.FacebookOptions
            {
                AppId = configuration["Facebook:AppId"],
                AppSecret = configuration["Facebook:SecretKey"]
            };
            httpClientFactory = _httpClientFactory;
        }

        public async Task<FacebookModel> GetUserInfo(string accessToken)
        {
            var foratedUrl = string.Format(userInfoUrl, accessToken,
                facebookOptions.AppId, facebookOptions.AppSecret);

            var result = await httpClientFactory.CreateClient().GetAsync(foratedUrl);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var response = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<FacebookModel>(response);
            }
            else
                return null;
        }

        public async Task<TokenValidationDTO> TokenValidation(string accessToken)
        {
            var foratedUrl = string.Format(tokenValidationUrl, accessToken,
                facebookOptions.AppId, facebookOptions.AppSecret);

            var result = await httpClientFactory.CreateClient().GetAsync(foratedUrl);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var response = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TokenValidationDTO>(response);
            }
            else
                return null;
        }
    }
}

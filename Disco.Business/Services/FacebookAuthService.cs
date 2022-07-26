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
        private readonly IHttpClientFactory _httpClientFactory;

        public FacebookAuthService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<FacebookDto> GetUserInfo(string accessToken)
        {
            var result = await _httpClientFactory.CreateClient()
                .GetAsync(
                    $"https://graph.facebook.com/v11.0/me?fields=id%2Cname%2Cemail%2Cfirst_name%2Cmiddle_name%2Clast_name%2Cpicture%2Cabout&access_token={accessToken}");

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }
            
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FacebookDto>(response);
        }

        public async Task<TokenValidationResponseModel> TokenValidation(string accessToken)
        {
            var result = await _httpClientFactory.CreateClient().GetAsync($"https://graph.facebook.com/debug_token?input_token={accessToken}&access_token=261002815859881|9c4f0fbe6ed89d0c35d1a7cd965de88c");

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }
            
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TokenValidationResponseModel>(response);
        }
    }
}

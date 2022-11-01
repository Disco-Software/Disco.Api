using Disco.Business.Dtos.AudD;
using Disco.Business.Interfaces;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Disco.Business.Services
{
    public class AudDService : IAudDService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AudDService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<AudDDto> RecognizeAsync(AudDRequestDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json);

            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.PostAsync("https://api.audd.io/recognize", content);
            var result = await response.Content.ReadAsStringAsync();

            if(result == null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<AudDDto>(result);
        }
    }
}

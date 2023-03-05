using Disco.Integration.Interfaces.Dtos.AudD;
using Disco.Integration.Interfaces.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Integration.Clients.HttpClients
{
    public class AudDClient : IAudDClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AudDClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<AudDDto> CheckAuthorAsync(AudDRequestDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);

            using var memoryStream = new MemoryStream();

            await dto.file.CopyToAsync(memoryStream);
            var bytes = memoryStream.ToArray();

            var content = new MultipartFormDataContent();
            content.Add(new StringContent(dto.@return), "return");
            content.Add(new StringContent(dto.api_token), "api_token");
            content.Add(new ByteArrayContent(bytes), "file", dto.file.FileName);

            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.PostAsync("https://api.audd.io/recognize", content);
            var result = await response.Content.ReadAsStringAsync();

            if (result == null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<AudDDto>(result);
        }
    }
}

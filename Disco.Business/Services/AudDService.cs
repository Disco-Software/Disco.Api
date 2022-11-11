using Disco.Business.Dtos.AudD;
using Disco.Business.Interfaces;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

            if(result == null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<AudDDto>(result);
        }
    }
}

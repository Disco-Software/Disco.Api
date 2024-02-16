using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

namespace Disco.Business.Services.Helpers
{
    public static class ByteHepler
    {
        public static byte[] ConvertDateTimeToBytes(DateTime dateTime)
        {
            string jsonString = JsonSerializer.Serialize(dateTime);
            
            return Encoding.UTF8.GetBytes(jsonString);
        }

        public static DateTime ConvertBytesToDateTime(byte[] bytes)
        {
            string jsonString = Encoding.UTF8.GetString(bytes);
            
            return JsonSerializer.Deserialize<DateTime>(jsonString);
        }

        public static async Task<byte[]> ConvertIFormFileToByteArrayAsync(IFormFile formFile)
        {
            if (formFile == null || formFile.Length == 0)
            {
                return null;
            }

            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);

                return memoryStream.ToArray();
            }
        }
    }
}

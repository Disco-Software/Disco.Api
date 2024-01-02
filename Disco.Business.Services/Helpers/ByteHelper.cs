using System.Text;
using System.Text.Json;

namespace Disco.Business.Services.Helpers
{
    public static class ByteHelper
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
    }
}

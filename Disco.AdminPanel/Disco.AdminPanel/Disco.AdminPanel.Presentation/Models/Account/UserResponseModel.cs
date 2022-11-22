using Newtonsoft.Json;

namespace Disco.AdminPanel.Presentation.Models.Account
{
    public class UserResponseModel
    {
        [JsonProperty("user")]
        public User User { get; set; }
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
        [JsonProperty("accessTokenExpirce")]
        public int AccessTokenExpirce { get; set; }
        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }
    }
}

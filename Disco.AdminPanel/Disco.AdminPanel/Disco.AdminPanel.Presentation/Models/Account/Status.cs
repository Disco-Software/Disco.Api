using Newtonsoft.Json;

namespace Disco.AdminPanel.Presentation.Models.Account
{
    public class Status
    {
        [JsonProperty("lastStatus")]
        public string LastStatus { get; set; }
        [JsonProperty("followersCount")]
        public int FollowersCount { get; set; }
        [JsonProperty("nextStatusId")]
        public int NextStatusId { get; set; }
        [JsonProperty("userTarget")]
        public int UserTarget { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}

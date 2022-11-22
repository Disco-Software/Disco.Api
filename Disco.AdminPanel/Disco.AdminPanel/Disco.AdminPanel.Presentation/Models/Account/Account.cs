using Newtonsoft.Json;

namespace Disco.AdminPanel.Presentation.Models.Account
{
    public class Account
    {
        [JsonProperty("status")]
        public Status Status { get; set; }
        [JsonProperty("cread")]
        public string Cread { get; set; }
        [JsonProperty("photo")]
        public string Photo { get; set; }
        [JsonProperty("posts")]
        public List<Post.Post> Posts { get; set; }
        [JsonProperty("comments")]
        public List<object> Comments { get; set; }
        [JsonProperty("likes")]
        public List<object> Likes { get; set; }
        [JsonProperty("followers")]
        public List<object> Followers { get; set; }
        [JsonProperty("following")]
        public List<object> Following { get; set; }
        [JsonProperty("stories")]
        public List<object> Stories { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}

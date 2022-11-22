using Newtonsoft.Json;

namespace Disco.AdminPanel.Presentation.Models.Post
{
    public class Post
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("postImages")]
        public List<object> PostImages { get; set; }
        [JsonProperty("postSongs")]
        public List<object> PostSongs { get; set; }
        [JsonProperty("postVideos")]
        public List<object> PostVideos { get; set; }
        [JsonProperty("likes")]
        public List<object> Likes { get; set; }
        [JsonProperty("comments")]
        public List<object> Comments { get; set; }
        [JsonProperty("dateOfCreation")]
        public DateTime DateOfCreation { get; set; }
        [JsonProperty("accountId")]
        public int AccountId { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}

using Newtonsoft.Json;

namespace Disco.AdminPanel.Models
{
    public class Account
    {
        [JsonProperty("status")]
        public Status Status { get; set; }
        [JsonProperty("cread")]
        public string Cread { get; set; }
        [JsonProperty("photo")]
        public object Photo { get; set; }
        [JsonProperty("posts")]
        public List<Post> Posts { get; set; }
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
        [JsonProperty("dateOfCreation")]
        public DateTime DateOfCreation { get; set; }
        [JsonProperty("accountId")]
        public int AccountId { get; set; }
        [JsonProperty("id")]
        public int id { get; set; }
    }

    public class UserResponseModel
    {
        [JsonProperty("user")]
        public User User { get; set; }
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }
    }

    public class Status
    {
        [JsonProperty("lastStatus")]
        public string LastStatus { get; set; }
        [JsonProperty("followersCount")]
        public int FollowersCount { get; set; }
        [JsonProperty("nextStatusId")]
        public int nextStatusId { get; set; }
        [JsonProperty("userTarget")]
        public int UserTarget { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
    }

    public class User
    {
        [JsonProperty("roleName")]
        public string RoleName { get; set; }
        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }
        [JsonProperty("refreshTokenExpiress")]
        public DateTime RefreshTokenExpiress { get; set; }
        [JsonProperty("dateOfRegister")]
        public DateTime DateOfRegister { get; set; }
        [JsonProperty("accountId")]
        public int AccountId { get; set; }
        [JsonProperty("account")]
        public Account Account { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("userName")]
        public string UserName { get; set; }
        [JsonProperty("normalizedUserName")]
        public string NormalizedUserName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("normalizedEmail")]
        public string NormalizedEmail { get; set; }
        [JsonProperty("emailConfirmed")]
        public bool EmailConfirmed { get; set; }
        [JsonProperty("passwordHash")]
        public string PasswordHash { get; set; }
        [JsonProperty("securityStamp")]
        public string SecurityStamp { get; set; }
        [JsonProperty("concurrencyStamp")]
        public string ConcurrencyStamp { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("phoneNumberConfirmed")]
        public bool PhoneNumberConfirmed { get; set; }
        [JsonProperty("twoFactorEnabled")]
        public bool twoFactorEnabled { get; set; }
        [JsonProperty("lockoutEnd")]
        public object LockoutEnd { get; set; }
        [JsonProperty("lockoutEnabled")]
        public bool LockoutEnabled { get; set; }
        [JsonProperty("accessFailedCount")]
        public int accessFailedCount { get; set; }
    }
}

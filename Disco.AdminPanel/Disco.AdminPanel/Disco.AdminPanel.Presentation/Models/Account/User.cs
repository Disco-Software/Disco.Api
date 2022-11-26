using Newtonsoft.Json;

namespace Disco.AdminPanel.Presentation.Models.Account
{
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
        public bool TwoFactorEnabled { get; set; }
        [JsonProperty("lockoutEnd")]
        public object lockoutEnd { get; set; }
        [JsonProperty("lockoutEnabled")]
        public bool LockoutEnabled { get; set; }
        [JsonProperty("accessFailedCount")]
        public int AccessFailedCount { get; set; }
    }
}

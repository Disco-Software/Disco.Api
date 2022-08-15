namespace Disco.Web.Infrastructure.Models
{
    public class UserResponseModel
    {
        public User User { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}

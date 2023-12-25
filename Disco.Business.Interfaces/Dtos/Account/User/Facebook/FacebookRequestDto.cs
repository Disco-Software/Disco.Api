namespace Disco.Business.Interfaces.Dtos.Account.User.Facebook
{
    public class FacebookRequestDto
    {
        public FacebookRequestDto(
            string facebookAccessToken)
        {
            FacebookAccessToken = facebookAccessToken;
        }

        public string FacebookAccessToken { get; set; }
    }
}

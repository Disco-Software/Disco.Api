namespace Disco.Business.Interfaces.Dtos.Account.User.RefreshToken
{
    public class RefreshTokenRequestDto
    {
        public RefreshTokenRequestDto(
            string refreshToken,
            string accessToken)
        {
            RefreshToken = refreshToken;
            AccessToken = accessToken;
        }

        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
    }
}

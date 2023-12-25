namespace Disco.Business.Interfaces.Dtos.Account.Admin.RefreshToken
{
    public class RefreshTokenRequestDto
    {
        public RefreshTokenRequestDto(
            string accessToken,
            string refreshToken) 
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}

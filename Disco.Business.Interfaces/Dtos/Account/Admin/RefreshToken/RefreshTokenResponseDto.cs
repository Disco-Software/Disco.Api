namespace Disco.Business.Interfaces.Dtos.Account.Admin.RefreshToken
{
    public class RefreshTokenResponseDto
    {
        public RefreshTokenResponseDto() { }
        public RefreshTokenResponseDto(
            UserDto user,
            string accessToken,
            string refreshToken)
        {
            User = user;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public UserDto User { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}

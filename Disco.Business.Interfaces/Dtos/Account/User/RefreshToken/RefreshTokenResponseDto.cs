namespace Disco.Business.Interfaces.Dtos.Account.User.RefreshToken
{
    public class RefreshTokenResponseDto
    {
        public RefreshTokenResponseDto(
            UserDto user,
            string refreshToken,
            string accessToken)
        {
            User = user;
            RefreshToken = refreshToken;
            AccessToken = accessToken;
        }

        public UserDto User { get; set; }
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
    }
}

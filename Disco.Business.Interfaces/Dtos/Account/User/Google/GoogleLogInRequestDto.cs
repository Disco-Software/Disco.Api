namespace Disco.Business.Interfaces.Dtos.Account.User.Google
{
    public class GoogleLogInRequestDto
    {
        public GoogleLogInRequestDto(
            string email,
            string userName,
            string photo,
            string id,
            string idToken,
            string serverAuthCode)
        {
            Email = email;
            UserName = userName;
            Photo = photo;
            Id = id;
            IdToken = idToken;
            ServerAuthCode = serverAuthCode;
        }

        public string Email { get; set; }
        public string UserName { get;  set; }
        public string Photo { get; set; }
        public string Id { get; set; }
        public string IdToken { get; set; }
        public string ServerAuthCode { get; set; }
    }
}

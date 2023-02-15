namespace Disco.Business.Interfaces.Dtos.Google
{
    public class GoogleLogInDto
    {
        public string Email { get; set; }
        public string UserName { get;  set; }
        public string Photo { get; set; }
        public string Id { get; set; }
        public string IdToken { get; set; }
        public string ServerAuthCode { get; set; }
    }
}

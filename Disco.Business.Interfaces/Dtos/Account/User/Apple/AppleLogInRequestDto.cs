namespace Disco.Business.Interfaces.Dtos.Account.User.Apple
{
    public class AppleLogInRequestDto
    {
        public AppleLogInRequestDto(
            string name,
            string email,
            string appleId,
            string appleIdCode)
        {
            Name = name;
            Email = email;
            AppleId = appleId;
            AppleIdCode = appleIdCode;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string AppleId { get; set; }
        public string AppleIdCode { get; set; }
    }
}

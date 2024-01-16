namespace Disco.Business.Interfaces.Dtos.AccountDetails.Admin.CreateAccount
{
    public class CreateAccountResponseDto
    {
        public CreateAccountResponseDto() { }
        public CreateAccountResponseDto(UserDto user)
        {
            User = user;
        }

        public UserDto User { get; set; }
    }
}

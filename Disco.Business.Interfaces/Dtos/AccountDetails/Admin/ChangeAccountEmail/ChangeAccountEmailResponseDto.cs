namespace Disco.Business.Interfaces.Dtos.AccountDetails.Admin.ChangeAccountEmail
{
    public class ChangeAccountEmailResponseDto
    {
        public ChangeAccountEmailResponseDto() { }
        public ChangeAccountEmailResponseDto(
            AccountDto account)
        {
            Account = account;
        }

        public AccountDto Account { get; set; }
    }
}

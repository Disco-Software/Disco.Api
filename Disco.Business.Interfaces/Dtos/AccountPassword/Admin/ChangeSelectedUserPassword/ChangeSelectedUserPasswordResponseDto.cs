namespace Disco.Business.Interfaces.Dtos.AccountPassword.Admin.ChangeSelectedUserPassword
{
    public class ChangeSelectedUserPasswordResponseDto
    {
        public ChangeSelectedUserPasswordResponseDto(
            AccountDto account)
        {
            Account = account;
        }

        public AccountDto Account { get; set; }
    }
}

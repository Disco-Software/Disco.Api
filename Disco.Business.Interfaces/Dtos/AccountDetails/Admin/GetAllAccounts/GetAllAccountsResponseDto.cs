namespace Disco.Business.Interfaces.Dtos.AccountDetails.Admin.GetAllAccounts
{
    public class GetAllAccountsResponseDto
    {
        public GetAllAccountsResponseDto(
            AccountDto account)
        {
            Account = account;
        }

        public AccountDto Account { get; set; }
    }
}

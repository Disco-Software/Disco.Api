namespace Disco.Business.Interfaces.Dtos.AccountDetails.Admin.SearchAccounts
{
    public class SearchAccountsResponseDto
    {
        public SearchAccountsResponseDto() { }
        public SearchAccountsResponseDto(
            AccountDto account)
        {
            Account = account;
        }

        public AccountDto Account { get; set; }
    }
}

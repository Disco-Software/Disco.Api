namespace Disco.Business.Interfaces.Dtos.AccountDetails.Admin.GetAccount
{
    public class GetAccountResponseDto
    {
        public GetAccountResponseDto() { }
        public GetAccountResponseDto(
            AccountDto account)
        {
            Account = account;
        }

        public AccountDto Account { get; set; }
    }
}

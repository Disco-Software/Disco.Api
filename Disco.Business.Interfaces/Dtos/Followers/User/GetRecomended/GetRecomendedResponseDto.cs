namespace Disco.Business.Interfaces.Dtos.Followers.User.GetRecomended
{
    public class GetRecomendedResponseDto
    {
        public GetRecomendedResponseDto(AccountDto account)
        {
            Account = account;
        }

        public AccountDto Account { get; set; }
    }
}

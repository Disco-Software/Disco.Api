namespace Disco.Business.Interfaces.Dtos.AccountDetails.Admin.SearchAccounts
{
    public class AccountDto
    {
        public AccountDto(
            string photo,
            string cread,
            UserDto user)
        {
            Photo = photo;
            Cread = cread;
            User = user;
        }

        public string Photo {  get; set; }
        public string Cread {  get; set; }
        public UserDto User { get; set; }
    }
}

namespace Disco.Business.Interfaces.Dtos.AccountDetails.Admin.SearchAccounts
{
    public class AccountDto
    {
        public AccountDto(
            int id,
            string photo,
            string cread,
            UserDto user)
        {
            Id = id;
            Photo = photo;
            Cread = cread;
            User = user;
        }

        public int Id {  get; set; }
        public string Photo {  get; set; }
        public string Cread {  get; set; }
        public UserDto User { get; set; }
    }
}

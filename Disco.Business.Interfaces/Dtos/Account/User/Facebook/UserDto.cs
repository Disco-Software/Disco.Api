namespace Disco.Business.Interfaces.Dtos.Account.User.Facebook
{
    public class UserDto
    {
        public UserDto(
            int id,
            string userName,
            string email,
            AccountDto account)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Account = account;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public AccountDto Account { get; set; }
    }
}

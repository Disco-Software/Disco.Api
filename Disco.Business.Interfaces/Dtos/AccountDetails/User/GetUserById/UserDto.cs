namespace Disco.Business.Interfaces.Dtos.AccountDetails.User.GetUserById
{
    public class UserDto
    {
        public UserDto(
            string userName,
            string email,
            AccountDto account)
        {
            UserName = userName;
            Email = email;
            Account = account;
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public AccountDto Account { get; set; }
    }
}

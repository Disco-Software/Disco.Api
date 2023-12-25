namespace Disco.Business.Interfaces.Dtos.Account.Admin.LogIn
{
    public class UserDto
    {
        public UserDto(
            int id,
            string roleName,
            string userName,
            string email,
            AccountDto account)
        {
            Id = id;
            RoleName = roleName;
            UserName = userName;
            Email = email;
            Account = account;
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public AccountDto Account { get; set; }
    }
}

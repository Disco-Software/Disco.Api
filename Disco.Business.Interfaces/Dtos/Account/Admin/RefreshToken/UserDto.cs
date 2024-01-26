using Disco.Business.Utils.Guards;

namespace Disco.Business.Interfaces.Dtos.Account.Admin.RefreshToken
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

            DefaultGuard.ArgumentNull(id);
            DefaultGuard.ArgumentNull(userName);
            DefaultGuard.ArgumentNull(email);
            DefaultGuard.ArgumentNull<AccountDto>(account);
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public AccountDto Account { get; set; }
    }
}

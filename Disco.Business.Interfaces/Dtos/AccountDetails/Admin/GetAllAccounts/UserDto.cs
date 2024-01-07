namespace Disco.Business.Interfaces.Dtos.AccountDetails.Admin.GetAllAccounts
{
    public class UserDto
    {
        public UserDto(
            string roleName,
            string userName,
            string email)
        {
            RoleName = roleName;
            UserName = userName;
            Email = email;
        }

        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

    }
}

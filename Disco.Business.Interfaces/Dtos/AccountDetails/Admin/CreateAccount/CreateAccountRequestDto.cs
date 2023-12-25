namespace Disco.Business.Interfaces.Dtos.AccountDetails.Admin.CreateAccount
{
    public class CreateAccountRequestDto
    {
        public CreateAccountRequestDto(
            string userName,
            string email,
            string password,
            string confirmPassword)
        {
            UserName = userName;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

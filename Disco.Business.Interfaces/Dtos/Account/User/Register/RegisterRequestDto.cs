namespace Disco.Business.Interfaces.Dtos.Account.User.Register
{
    public class RegisterRequestDto
    {
        public RegisterRequestDto() { }
        public RegisterRequestDto(
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

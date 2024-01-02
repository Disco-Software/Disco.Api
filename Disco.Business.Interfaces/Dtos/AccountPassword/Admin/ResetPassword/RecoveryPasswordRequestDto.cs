namespace Disco.Business.Interfaces.Dtos.AccountPassword.Admin.ResetPassword
{
    public class RecoveryPasswordRequestDto
    {
        public RecoveryPasswordRequestDto(
            string email,
            string password,
            string confirmPassword,
            bool isValidPasswordRecoveryCode)
        {
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            IsValidPasswordRecoveryCode = isValidPasswordRecoveryCode;
        }

        public string Email { get; }
        public string Password { get; }
        public string ConfirmPassword { get; }
        public bool IsValidPasswordRecoveryCode {  get; }
    }
}

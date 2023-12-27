namespace Disco.Business.Interfaces.Dtos.AccountPassword.Admin.ChangeSelectedUserPassword
{
    public class ChangeSelectedUserPasswordRequestDto
    {
        public ChangeSelectedUserPasswordRequestDto() { }
        public ChangeSelectedUserPasswordRequestDto(
            int id, 
            string password)
        {
            Id = id;
            Password = password;
        }

        public int Id { get; set; }
        public string Password { get; set; }
    }
}

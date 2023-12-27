namespace Disco.Business.Interfaces.Dtos.AccountDetails.Admin.ChangeAccountEmail
{
    public class ChangeAccountEmailRequestDto
    {
        public ChangeAccountEmailRequestDto(
            int id,
            string email)
        {
            Id = id;
            Email = email;
        }

        public int Id {  get; set; }
        public string Email { get; set; }
    }
}

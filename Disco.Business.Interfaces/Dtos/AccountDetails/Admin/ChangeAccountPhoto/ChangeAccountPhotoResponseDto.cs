namespace Disco.Business.Interfaces.Dtos.AccountDetails.Admin.ChangeAccountPhoto
{
    public class ChangeAccountPhotoResponseDto
    {
        public ChangeAccountPhotoResponseDto() { }
        public ChangeAccountPhotoResponseDto(
            AccountDto account)
        {
            Account = account;
        }

        public AccountDto Account { get; set; }
    }
}

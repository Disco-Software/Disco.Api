namespace Disco.Business.Interfaces.Dtos.Roles.Admin.ChangeAccountRole
{
    public class ChangeAccountRoleResponseDto
    {
        public ChangeAccountRoleResponseDto(
            AccountDto account)
        {
            Account = account;
        }

        public AccountDto Account { get; set; }
    }
}

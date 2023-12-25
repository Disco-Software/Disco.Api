namespace Disco.Business.Interfaces.Dtos.Group.User.CreateGroup
{
    public class CreateGroupResponseDto
    {
        public CreateGroupResponseDto() { }
        public CreateGroupResponseDto(
            int id,
            string name,
            IEnumerable<AccountDto> accounts)
        {
            Id = id;
            Accounts = accounts;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<AccountDto> Accounts { get; set; }
    }
}

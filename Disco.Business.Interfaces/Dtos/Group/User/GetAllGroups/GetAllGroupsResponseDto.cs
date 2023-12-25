namespace Disco.Business.Interfaces.Dtos.Group.User.GetAllGroups
{
    public class GetAllGroupsResponseDto
    {
        public GetAllGroupsResponseDto() { }
        public GetAllGroupsResponseDto(
            int id,
            string name, 
            MessageDto? lastMessage,
            List<AccountDto> accounts)
        {
            Id = id;
            Name = name;
            LastMessage = lastMessage;
            Accounts = accounts;
        }

        public int Id { get; set; }

        public string Name { get; set; }
        
        public MessageDto? LastMessage { get; set; }

        public List<AccountDto> Accounts { get; set; }
    }
}

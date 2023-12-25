namespace Disco.Business.Interfaces.Dtos.Group.User.GetAllGroupMessages
{
    public class GetAllGroupMessagesResponseDto
    {
        public GetAllGroupMessagesResponseDto() { }
        public GetAllGroupMessagesResponseDto(
            string description, 
            DateTime createDate, 
            AccountDto account)
        {
            Description = description;
            CreateDate = createDate;
            Account = account;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        
        public DateTime CreateDate { get; set; }

        public AccountDto Account { get; set; }
    }
}

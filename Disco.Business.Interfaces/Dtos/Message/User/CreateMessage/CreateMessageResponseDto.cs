namespace Disco.Business.Interfaces.Dtos.Message.User.CreateMessage
{
    public class CreateMessageResponseDto
    {
        public CreateMessageResponseDto(
            string description, 
            DateTime? createdDate, 
            AccountDto account)
        {
            Description = description;
            CreatedDate = createdDate;
            Account = account;
        }

        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }

        public AccountDto Account { get; set; }
    }
}

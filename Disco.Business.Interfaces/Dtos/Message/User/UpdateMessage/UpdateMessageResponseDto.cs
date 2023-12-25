namespace Disco.Business.Interfaces.Dtos.Message.User.UpdateMessage
{
    public class UpdateMessageResponseDto
    {
        public UpdateMessageResponseDto(
            string description, 
            DateTime createdDate, 
            AccountDto account)
        {
            Description = description;
            CreatedDate = createdDate;
            Account = account;
        }

        public string Description {  get; set; }
        
        public DateTime CreatedDate {  get; set; }

        public AccountDto Account { get; set; }
    }
}

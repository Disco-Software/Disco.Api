namespace Disco.Business.Interfaces.Dtos.TicketMessage.GetAllMessages
{
    public class GetAllMessagesResponseDto
    {
        public GetAllMessagesResponseDto() { }
        public GetAllMessagesResponseDto(
            int id,
            string message,
            DateTime createdDate,
            AccountDto account)
        {
            Id = id;
            Message = message;
            CreatedDate = createdDate;
            Account = account;
        }

        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public AccountDto Account { get; set; }
    }
}

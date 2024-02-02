namespace Disco.Business.Interfaces.Dtos.TicketMessage.CreateMessage
{
    public class SendMessageResponseDto
    {
        public SendMessageResponseDto() { }
        public SendMessageResponseDto(
            int id,
            string message,
            DateTime created,
            AccountDto account)
        {
            Id = id;
            Message = message;
            Created = created;
            Account = account;
        }

        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        public AccountDto Account { get; set; }
    }
}

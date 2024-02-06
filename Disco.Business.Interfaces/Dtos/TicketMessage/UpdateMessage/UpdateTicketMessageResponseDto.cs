namespace Disco.Business.Interfaces.Dtos.TicketMessage.UpdateMessage
{
    public class UpdateTicketMessageResponseDto
    {
        public UpdateTicketMessageResponseDto() { }
        public UpdateTicketMessageResponseDto(
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

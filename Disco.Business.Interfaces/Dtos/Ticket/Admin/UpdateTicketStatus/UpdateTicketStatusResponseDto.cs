namespace Disco.Business.Interfaces.Dtos.Ticket.Admin.UpdateTicketStatus
{
    public class UpdateTicketStatusResponseDto
    {
        public UpdateTicketStatusResponseDto() { }
        public UpdateTicketStatusResponseDto(
            int id,
            AccountDto owner,
            DateTime createdDate,
            string priority,
            string status)
        {
            Id = id; 
            Owner = owner;
            CreatedDate = createdDate;
            Priority = priority;
            Status = status;
        }

        public int Id { get; set; }
        public AccountDto Owner { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
    }
}

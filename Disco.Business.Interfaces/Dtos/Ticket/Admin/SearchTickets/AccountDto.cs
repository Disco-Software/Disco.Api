namespace Disco.Business.Interfaces.Dtos.Ticket.Admin.SearchTickets
{
    public class AccountDto
    {
        public AccountDto() { }
        public AccountDto(
            string photo,
            string userName)
        {
            UserName = userName;
            Photo = photo;
        }

        public string Photo { get; set; }
        public string UserName { get; set; }
    }
}

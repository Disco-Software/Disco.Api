namespace Disco.Business.Interfaces.Dtos.Ticket.Admin.GetAllTickets
{
    public class AccountDto
    {
        public AccountDto() { }
        public AccountDto(
            string photo,
            string userName)
        {
            Photo = photo;
            UserName = userName;
        }

        public string Photo {  get; set; }
        public string UserName { get; set; }
    }
}

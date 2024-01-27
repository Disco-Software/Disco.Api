namespace Disco.Business.Interfaces.Dtos.Ticket.Admin.GetAllTickets
{
    public class AccountDto
    {
        public AccountDto(
            string photo,
            UserDto user)
        {
            Photo = photo;
            User = user;
        }

        public string Photo {  get; set; }
        public UserDto User { get; set; }
    }
}

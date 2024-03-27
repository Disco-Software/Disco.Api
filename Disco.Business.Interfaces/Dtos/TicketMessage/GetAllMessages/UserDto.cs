namespace Disco.Business.Interfaces.Dtos.TicketMessage.GetAllMessages
{
    public class UserDto
    {
        public UserDto(
            int id, 
            string userName, 
            string email)
        {
            Id = id;
            UserName = userName;
            Email = email;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email {  get; set; }
    }
}

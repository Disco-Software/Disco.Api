namespace Disco.Business.Interfaces.Dtos.TicketMessage.CreateMessage
{
    public class UserDto
    {
        public UserDto(
            int id,
            string roleName,
            string userName,
            string email)
        {
            Id = id;
            RoleName = roleName;
            UserName = userName;
            Email = email;
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}

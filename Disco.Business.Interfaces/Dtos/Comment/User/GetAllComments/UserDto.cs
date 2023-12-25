namespace Disco.Business.Interfaces.Dtos.Comment.User.GetAllComments
{
    public class UserDto
    {
        public UserDto(
            string userName,
            string email)
        {
            UserName = userName;
            Email = email;
        }

        public string UserName { get; set; }
        public string Email { get; set; }
    }
}

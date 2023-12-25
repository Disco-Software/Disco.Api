namespace Disco.Business.Interfaces.Dtos.Group.User.CreateGroup
{
    public class CreateGroupRequestDto
    {
        public CreateGroupRequestDto(
            int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}

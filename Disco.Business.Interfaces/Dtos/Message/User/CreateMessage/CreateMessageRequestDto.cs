namespace Disco.Business.Interfaces.Dtos.Message.User.CreateMessage
{
    public class CreateMessageRequestDto
    {
        public CreateMessageRequestDto(
            string description)
        {
            Description = description;
        }

        public string Description { get; set; }
    }
}

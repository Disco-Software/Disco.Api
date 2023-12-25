namespace Disco.Business.Interfaces.Dtos.Message.User.UpdateMessage
{
    public class UpdateMessageRequestDto
    {
        public UpdateMessageRequestDto(
            string description, 
            int messageId)
        {
            Description = description;
            MessageId = messageId;
        }

        public string Description { get; set; }
        public int MessageId { get; set; }
    }
}

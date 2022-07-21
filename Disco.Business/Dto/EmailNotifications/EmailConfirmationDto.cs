namespace Disco.Business.Dto.EmailNotifications
{
    public class EmailConfirmationDto
    {
        public string ToEmail { get; set; }
        public string Name { get; set; }
        public string MessageHeader { get; set; }
        public string MessageBody { get; set; }
        public bool IsHtmlTemplate { get; set; }
    }
}

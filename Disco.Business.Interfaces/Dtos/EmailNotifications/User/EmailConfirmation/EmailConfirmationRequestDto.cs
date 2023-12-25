namespace Disco.Business.Interfaces.Dtos.EmailNotifications.User.EmailConfirmation
{
    public class EmailConfirmationRequestDto
    {
        public EmailConfirmationRequestDto(
            string toEmail,
            string name,
            string messageHeader,
            string messageBody,
            int code,
            bool isHtmlTemplate)
        {
            ToEmail = toEmail;
            Name = name;
            MessageHeader = messageHeader;
            MessageBody = messageBody;
            Code = code;
            IsHtmlTemplate = isHtmlTemplate;
        }

        public string ToEmail { get; set; }
        public string Name { get; set; }
        public string MessageHeader { get; set; }
        public string MessageBody { get; set; }
        public int Code { get; set; }
        public bool IsHtmlTemplate { get; set; }
    }
}

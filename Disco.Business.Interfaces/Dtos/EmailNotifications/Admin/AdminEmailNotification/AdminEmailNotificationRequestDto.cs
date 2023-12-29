namespace Disco.Business.Interfaces.Dtos.EmailNotifications.Admin.AdminEmailNotification
{
    public class AdminEmailNotificationRequestDto
    {
        public AdminEmailNotificationRequestDto(
            IEnumerable<string> toEmails, 
            string name,
            string title, 
            string body, 
            bool isHtml)
        {
            ToEmails = toEmails;
            Name = name;
            Title = title;
            Body = body;         
            IsHtml = isHtml;
        }

        public IEnumerable<string> ToEmails {  get; set; }
        public string Name {  get; set; }
        public string Title {  get; set; }
        public string Body {  get; set; }
        public bool IsHtml {  get; set; }
    }
}

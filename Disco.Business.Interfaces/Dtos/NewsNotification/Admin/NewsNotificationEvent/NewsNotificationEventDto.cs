namespace Disco.Business.Interfaces.Dtos.NewsNotification.Admin.NewsNotificationEvent
{
    public class NewsNotificationEventDto
    {
        public NewsNotificationEventDto() { }
        public NewsNotificationEventDto(
            string title, 
            string body, 
            string payload)
        {
            Title = title;
            Body = body;
            Payload = payload;
        }

        public string Title {  get; set; }
        public string Body { get; set; }
        public string Payload { get; set; }
    }
}

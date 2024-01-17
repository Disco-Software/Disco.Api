namespace Disco.Business.Interfaces.Dtos.PushNotifications
{
    public class PushNotificationBaseDto
    {
        public PushNotificationBaseDto() { }
        public PushNotificationBaseDto(
            string title,
            string body,
            bool silent)
        {
            Title = title;
            Body = body;
            Silent = silent;
        }

        public string Title { get; set; }
        public string Body { get; set; }
        public bool Silent { get; set; }
    }
}

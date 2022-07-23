namespace Disco.Business.Dtos.PushNotifications
{
    public class PushNotificationBaseDto
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Id { get; set; }
        public string Tag { get; set; }
        public string NotificationType { get; set; }
    }
}

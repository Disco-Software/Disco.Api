namespace Disco.Business.Dtos.PushNotifications
{
    public class PushNotificationBaseDto
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Id { get; set; }
        public string[] Tags { get; set; }
        public bool Silent { get; set; }
    }
}

namespace Disco.Business.Dto.PushNotifications
{
    public class NewFriendNotificationDto
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Id { get; set; }
        public string Tags { get; set; }
        public string NotificationType { get; set; }
        public int FriendId { get; set; }

    }
}

namespace Disco.Business.Dtos.Friends
{
    public class ConfirmationFriendDto
    {
        public int FriendId { get; set; }
        public int FriendProfileId { get; set; }
        public bool IsConfirmed { get; set; }
        public string InstalationId { get; set; }
    }
}

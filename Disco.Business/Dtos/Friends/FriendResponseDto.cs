namespace Disco.Business.Dtos.Friends
{
    public class FriendResponseDto
    {
        public Domain.Models.Account UserProfile { get; set; }
        public Domain.Models.Account FriendProfile { get; set; }
        public int FriendId { get; set; }
        public bool IsConfirmed { get; set; }
    }
}

namespace Disco.Business.Dtos.Friends
{
    public class FriendResponseDto
    {
        public Domain.Models.Account UserAccount { get; set; }
        public Domain.Models.Account FollowerAccount { get; set; }
        public int FriendId { get; set; }
        public bool IsConfirmed { get; set; }
    }
}

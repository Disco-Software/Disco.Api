namespace Disco.Business.Dtos.Followers
{
    public class FollowerResponseDto
    {
        public Domain.Models.Account UserAccount { get; set; }
        public Domain.Models.Account FollowerAccount { get; set; }
        public int FriendId { get; set; }
        public bool IsConfirmed { get; set; }
    }
}

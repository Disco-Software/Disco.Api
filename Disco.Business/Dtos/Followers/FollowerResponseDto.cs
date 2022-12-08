namespace Disco.Business.Dtos.Followers
{
    public class FollowerResponseDto
    {
        public Domain.Models.Account FollowingAccount { get; set; }
        public Domain.Models.Account FollowerAccount { get; set; }
        public bool IsFollowing { get; set; }
    }
}

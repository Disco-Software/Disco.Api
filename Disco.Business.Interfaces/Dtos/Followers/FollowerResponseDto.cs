namespace Disco.Business.Interfaces.Dtos.Followers
{
    public class FollowerResponseDto
    {
        public Domain.Models.Models.Account FollowingAccount { get; set; }
        public Domain.Models.Models.Account FollowerAccount { get; set; }
        public bool IsFollowing { get; set; }
    }
}

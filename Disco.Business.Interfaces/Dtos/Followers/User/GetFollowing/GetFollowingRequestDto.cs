namespace Disco.Business.Interfaces.Dtos.Followers.User.GetFollowing
{
    public class GetFollowingRequestDto
    {
        public int UserId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}

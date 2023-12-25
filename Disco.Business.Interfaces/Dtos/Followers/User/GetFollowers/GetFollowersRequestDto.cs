namespace Disco.Business.Interfaces.Dtos.Followers.User.GetFollowers
{
    public class GetFollowersRequestDto
    {
        public int UserId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}

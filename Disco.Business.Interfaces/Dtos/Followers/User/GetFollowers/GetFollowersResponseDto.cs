namespace Disco.Business.Interfaces.Dtos.Followers.User.GetFollowers
{
    public class GetFollowersResponseDto
    {
        public GetFollowersResponseDto() { }
        public GetFollowersResponseDto(
            AccountDto follower, 
            AccountDto following, 
            bool isFollowing)
        {
            Follower = follower;
            Following = following;
            IsFollowing = isFollowing;
        }

        public AccountDto Follower { get; set; }
        public AccountDto Following { get; set; }
        public bool IsFollowing { get; set; }
    }
}

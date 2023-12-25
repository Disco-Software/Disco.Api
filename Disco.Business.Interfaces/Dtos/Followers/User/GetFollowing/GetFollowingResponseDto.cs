namespace Disco.Business.Interfaces.Dtos.Followers.User.GetFollowing
{
    public class GetFollowingResponseDto
    {
        public GetFollowingResponseDto() { }
        public GetFollowingResponseDto(
            AccountDto follower, 
            AccountDto following, 
            bool? isFollowing)
        {
            Follower = follower;
            Following = following;
            IsFollowing = isFollowing;
        }

        public AccountDto Follower { get; set; }
        public AccountDto Following { get; set; }
        public bool? IsFollowing { get; set; }
    }
}

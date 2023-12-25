namespace Disco.Business.Interfaces.Dtos.Followers.User.GetFollower
{
    public class GetFollowerResponseDto
    {
        public GetFollowerResponseDto() { }
        public GetFollowerResponseDto(
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

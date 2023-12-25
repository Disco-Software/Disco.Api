namespace Disco.Business.Interfaces.Dtos.Followers.User.CreateFollower
{
    public class CreateFollowerResponseDto
    {
        public CreateFollowerResponseDto() { }
        public CreateFollowerResponseDto(
            AccountDto following, 
            AccountDto follower, 
            bool isFollowing)
        {
            Following = following;
            Follower = follower;
            IsFollowing = isFollowing;
        }

        public AccountDto Following {  get; set; }
        public AccountDto Follower { get; set; }
        public bool IsFollowing { get; set; }
    }
}

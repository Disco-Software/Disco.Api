namespace Disco.Business.Interfaces.Dtos.AccountDetails.Admin.ChangeAccountPhoto
{
    public class AccountDto
    {
        public AccountDto(
            string photo, 
            string cread, 
            int followersCount, 
            int followingCount, 
            int postsCount, 
            int storiesCount, 
            UserDto user)
        {
            Photo = photo;
            Cread = cread;
            FollowersCount = followersCount;
            FollowingCount = followingCount;
            PostsCount = postsCount;
            StoriesCount = storiesCount;
            User = user;
        }

        public string Photo {  get; set; }
        public string Cread {  get; set; }
        public int FollowersCount {  get; set; }
        public int FollowingCount {  get; set; }
        public int PostsCount { get; set; }
        public int StoriesCount {  get; set; }
        public UserDto User { get; set; }
    }
}

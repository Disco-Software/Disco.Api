namespace Disco.Business.Interfaces.Dtos.AccountDetails.Admin.ChangeAccountEmail
{
    public class AccountDto
    {
        public AccountDto() { }
        public AccountDto(
            string photo, 
            string cread, 
            int followersCount, 
            int followingsCount,
            int postsCount,
            int storiesCount,
            UserDto user)
        {
            Photo = photo;
            Cread = cread;
            FollowersCount = followersCount;
            FollowingsCount = followingsCount;
            PostsCount = postsCount;
            StoriesCount = storiesCount;
            User = user;
        }

        public string Photo { get; set; }
        public string Cread {  get; set; }
        public int FollowersCount {  get; set; }
        public int FollowingsCount {  get; set; }
        public int PostsCount { get; set; }
        public int StoriesCount {  get; set; }
        public UserDto User { get; set; }
    }
}

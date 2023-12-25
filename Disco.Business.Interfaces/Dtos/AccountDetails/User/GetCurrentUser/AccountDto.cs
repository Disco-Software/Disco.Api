namespace Disco.Business.Interfaces.Dtos.AccountDetails.User.GetCurrentUser
{
    public class AccountDto
    {
        public AccountDto(
            string photo, 
            string cread,
            int followersCount,
            int followingsCount)
        {
            Photo = photo;
            Cread = cread;
            FollowersCount = followersCount;
            FollowingsCount = followingsCount;
        }

        public string Photo { get; set; }
        public string Cread { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingsCount {  get; set; }
    }
}

using Disco.Domain.Models.Base;

namespace Disco.Domain.Models.Models
{
    public class AccountReating : BaseModel<int>
    {
        public int FollowersCount {  get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int AccountRecommendedId {  get; set; }
        public Account AccountRecommended { get; set; }
    }
}

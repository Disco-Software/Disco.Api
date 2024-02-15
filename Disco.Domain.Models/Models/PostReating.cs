using Disco.Domain.Models.Base;

namespace Disco.Domain.Models.Models
{
    public class PostReating : BaseModel<int>
    {
        public PostReating() { }
        public PostReating(
            int likesCount,
            int commentsCount,
            int postId,
            Post post,
            int accountId,
            Account account)
        {
            LikesCount = likesCount;
            CommentsCount = commentsCount;
            Account = account;
            Account = account;
            PostId = postId;
            Post = post;
        }

        public int LikesCount {  get; set; }
        public int CommentsCount {  get; set; }

        public int PostId {  get; set; }
        public Post Post { get; set; }

        public int AccountId {  get; set; }
        public Account Account { get; set; }
    }
}

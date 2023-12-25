namespace Disco.Business.Interfaces.Dtos.Comment.User.UpdateComment
{
    public class PostDto
    {
        public PostDto(int postId)
        {
            PostId = postId;
        }

        public int PostId { get; set; }
    }
}

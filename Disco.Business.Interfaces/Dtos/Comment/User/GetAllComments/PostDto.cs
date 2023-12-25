namespace Disco.Business.Interfaces.Dtos.Comment.User.GetAllComments
{
    public class PostDto
    {
        public PostDto(
            int postId)
        {
            PostId = postId;
        }

        public int PostId { get; set; }
    }
}

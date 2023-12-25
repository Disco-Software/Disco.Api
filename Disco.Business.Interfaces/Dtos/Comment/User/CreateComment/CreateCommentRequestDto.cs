namespace Disco.Business.Interfaces.Dtos.Comment.User.CreateComment
{
    public class CreateCommentRequestDto
    {
        public CreateCommentRequestDto(
            string description,
            int postId)
        {
            Description = description;
            PostId = postId;
        }

        public string Description { get; set; }
        public int PostId { get; set; }
    }
}

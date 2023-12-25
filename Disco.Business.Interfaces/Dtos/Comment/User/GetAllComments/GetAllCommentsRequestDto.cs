namespace Disco.Business.Interfaces.Dtos.Comment.User.GetAllComments
{
    public class GetAllCommentsRequestDto
    {
        public GetAllCommentsRequestDto(
            int postId,
            int pageNumber,
            int pageSize)
        {
            PostId = postId;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PostId { get; set; }
        public int PageNumber {  get; set; }
        public int PageSize { get; set; }
    }
}

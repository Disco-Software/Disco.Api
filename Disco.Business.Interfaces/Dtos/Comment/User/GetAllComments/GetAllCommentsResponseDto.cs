namespace Disco.Business.Interfaces.Dtos.Comment.User.GetAllComments
{
    public class GetAllCommentsResponseDto
    {
        public GetAllCommentsResponseDto(
            string description, 
            DateTime? createdAt, 
            PostDto post, 
            AccountDto account)
        {
            Description = description;
            CreatedAt = createdAt;
            Post = post;
            Account = account;
        }

        public string Description {  get; set; }
        public DateTime? CreatedAt { get; set; }
        public PostDto Post { get; set; }
        public AccountDto Account { get; set; }
    }
}

namespace Disco.Business.Interfaces.Dtos.Like.User.CreateLike
{
    public class CreateLikeResponseDto
    {
        public CreateLikeResponseDto() { }
        public CreateLikeResponseDto(
            int id, 
            AccountDto account, 
            PostDto post)
        {
            Id = id;
            Account = account;
            Post = post;
        }

        public int Id { get; set; }
        public AccountDto Account { get; set; }
        public PostDto Post { get; set; }
    }
}

namespace Disco.Business.Dtos.Friends
{
    public class GetAllFriendsDto
    {
        public int UserId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}

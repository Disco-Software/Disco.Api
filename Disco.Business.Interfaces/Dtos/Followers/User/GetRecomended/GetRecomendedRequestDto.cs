namespace Disco.Business.Interfaces.Dtos.Followers.User.GetRecomended
{
    public class GetRecomendedRequestDto
    {
        public GetRecomendedRequestDto(
            int userId,
            int pageNumber,
            int pageSize)
        {
            UserId = userId;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int UserId {  get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}

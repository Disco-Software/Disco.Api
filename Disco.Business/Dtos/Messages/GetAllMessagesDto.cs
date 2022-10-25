namespace Disco.Business.Dtos.Messages
{
    public class GetAllMessagesDto
    {
        public int UserId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}

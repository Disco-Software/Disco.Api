namespace Disco.Business.Interfaces.Dtos.Group.User.GetAllGroups
{
    public class MessageDto
    {
        public MessageDto(
            string description, 
            DateTime? createdDate, 
            int accountId)
        {
            Description = description;
            CreatedDate = createdDate;
            AccountId = accountId;
        }

        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int AccountId {  get; set; }
    }
}

using Disco.Domain.Models.Base;

namespace Disco.Domain.Models.Models
{
    public class Notification : BaseModel<int>
    {
        public Notification() { }
        public Notification(
            string title,
            string body,
            string payload,
            int accountId,
            Account account)
        {
            Title = title; 
            Body = body; 
            Payload = payload; 
            AccountId = accountId;
            Account = account;
        }

        public string Title {  get; set; }
        public string Body {  get; set; }
        public string Payload {  get; set; }

        public int AccountId {  get; set; }
        public Account Account { get; set; }
    }
}

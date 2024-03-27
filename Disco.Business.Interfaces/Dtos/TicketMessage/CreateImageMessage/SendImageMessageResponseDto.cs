using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.TicketMessage.CreateImageMessage
{
    public class SendImageMessageResponseDto
    {
        public SendImageMessageResponseDto() { }
        public SendImageMessageResponseDto(
            int id,
            string message,
            DateTime created,
            AccountDto account)
        {
            Id = id;
            Message = message;
            Created = created;
            Account = account;
        }

        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        public AccountDto Account { get; set; }


    }
}

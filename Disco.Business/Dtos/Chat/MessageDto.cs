using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Dtos.Chat
{
    public class MessageDto
    {
        public int MessageId { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        public int GroupId { get; set; }
        public AccountDto Account { get; set; }
    }
}

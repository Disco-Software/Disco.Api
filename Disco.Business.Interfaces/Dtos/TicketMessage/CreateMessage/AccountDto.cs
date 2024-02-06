using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.TicketMessage.CreateMessage
{
    public class AccountDto
    {
        public AccountDto(
            string photo,
            string cread,
            UserDto user)
        {
            Photo = photo;
            Cread = cread;
            User = user;
        }

        public string Photo { get; set; }
        public string Cread { get; set; }
        public UserDto User { get; set; }
    }
}

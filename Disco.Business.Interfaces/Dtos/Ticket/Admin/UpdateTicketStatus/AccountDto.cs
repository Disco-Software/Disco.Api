using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.Ticket.Admin.UpdateTicketStatus
{
    public class AccountDto
    {
        public AccountDto() { }
        public AccountDto(
            string photo,
            string userName)
        {
            Photo = photo;
            UserName = userName;
        }

        public string Photo { get; set; }
        public string UserName { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.Ticket.Admin.GetAllTickets
{
    public class UserDto
    {
        public UserDto(string userName)
        {
            UserName = userName;
        }

        public string UserName {  get; set; }
    }
}

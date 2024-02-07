using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.Business.Interfaces.Dtos.Ticket.Admin.GetAllTickets
{
    public class GetAllTicketsResponseDto
    {
        public GetAllTicketsResponseDto() { }
        public GetAllTicketsResponseDto(
            int id,
            AccountDto owner,
            DateTime createdDate,
            string priority,
            string status)
        {
            Id = id;
            Owner = owner;
            CreatedDate = createdDate;
            Priority = priority;
            Status = status;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public AccountDto Owner {  get; set; }
        public DateTime CreatedDate { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
    }
}

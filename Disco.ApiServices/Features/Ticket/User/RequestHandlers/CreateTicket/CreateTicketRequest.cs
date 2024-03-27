using Disco.Business.Interfaces.Dtos.Ticket.User.CreateTicket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Ticket.User.RequestHandlers.CreateTicket
{
    public class CreateTicketRequest : IRequest
    {
        public CreateTicketRequest(
            CreateTicketRequestDto dto)
        {
            Dto = dto;
        }

        public CreateTicketRequestDto Dto { get; set; }
    }
}

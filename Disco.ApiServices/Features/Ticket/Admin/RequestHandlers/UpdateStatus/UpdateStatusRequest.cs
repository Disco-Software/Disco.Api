using Disco.Business.Interfaces.Dtos.Ticket.Admin.UpdateTicketStatus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disco.ApiServices.Features.Ticket.Admin.RequestHandlers.UpdateStatus
{
    public class UpdateStatusRequest : IRequest<UpdateTicketStatusResponseDto>
    {
        public UpdateStatusRequest(
            string status,
            int id)
        {
            Status = status;
            Id = id;
        }

        public int Id {  get; }
        public string Status {  get; }
    }
}
